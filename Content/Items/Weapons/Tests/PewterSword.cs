using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Deus.Content.Items.Weapons.Tests
{
    public class PewterSword : ModItem
    {
        public int attackType = 0; 
        public int comboExpireTimer = 0; 

        public override void SetDefaults()
        {
           
            Item.width = 46;
            Item.height = 48;
            Item.value = Item.sellPrice(gold: 2, silver: 50);
            Item.rare = ItemRarityID.Green;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 7; 
            Item.autoReuse = true; 
            Item.damage = 62; 
            Item.DamageType = DamageClass.Melee; 
            Item.noMelee = true;  
            Item.noUseGraphic = true; 
            Item.shoot = ModContent.ProjectileType<PewterSwordProjectile>(); 
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, Main.myPlayer, attackType);
            attackType = (attackType + 1) % 2;
            comboExpireTimer = 0; 
            return false; 
        }

        public override void UpdateInventory(Player player)
        {
            if (comboExpireTimer++ >= 120) 
                attackType = 0;
        }

        public override bool MeleePrefix()
        {
            return true; 
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 12)

                .AddTile(TileID.Anvils)
                .Register();
        }
    }
    public class PewterSwordProjectile : ModProjectile
    {
        private const float SWINGRANGE = 1.67f * (float)Math.PI; 
        private const float FIRSTHALFSWING = 0.45f; 
        private const float SPINRANGE = 1.5f * (float)Math.PI; 
        private const float WINDUP = 0.15f; 
        private const float UNWIND = 0.4f; 
        private const float SPINTIME = 1.5f; 

        private enum AttackType 
        {
            
            
            Swing,
            
            Spin,
        }

        private enum AttackStage 
        {
            Prepare,
            Execute,
            Unwind
        }

        
        private AttackType CurrentAttack
        {
            get => (AttackType)Projectile.ai[0];
            set => Projectile.ai[0] = (float)value;
        }

        private AttackStage CurrentStage
        {
            get => (AttackStage)Projectile.localAI[0];
            set
            {
                Projectile.localAI[0] = (float)value;
                Timer = 0; 
            }
        }

    
        private ref float InitialAngle => ref Projectile.ai[1]; 
        private ref float Timer => ref Projectile.ai[2]; 
        private ref float Progress => ref Projectile.localAI[1]; 
        private ref float Size => ref Projectile.localAI[2]; 
        private float prepTime => 12f / Owner.GetTotalAttackSpeed(Projectile.DamageType);
        private float execTime => 12f / Owner.GetTotalAttackSpeed(Projectile.DamageType);
        private float hideTime => 12f / Owner.GetTotalAttackSpeed(Projectile.DamageType);

        public override string Texture => "Deus/Content/Items/Weapons/Tests/PewterSword"; 
        private Player Owner => Main.player[Projectile.owner];

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.HeldProjDoesNotUsePlayerGfxOffY[Type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 46; 
            Projectile.height = 48; 
            Projectile.friendly = true; 
            Projectile.timeLeft = 10000; 
            Projectile.penetrate = -1; 
            Projectile.tileCollide = false; 
            Projectile.usesLocalNPCImmunity = true; 
            Projectile.localNPCHitCooldown = -1; 
            Projectile.ownerHitCheck = true; 
            Projectile.DamageType = DamageClass.Melee; 
        }
        public override void OnSpawn(IEntitySource source)
        {
            Projectile.spriteDirection = Main.MouseWorld.X > Owner.MountedCenter.X ? 1 : -1;
            float targetAngle = (Main.MouseWorld - Owner.MountedCenter).ToRotation();

            if (CurrentAttack == AttackType.Spin)
            {
                InitialAngle = (float)(-Math.PI / 2 - Math.PI * 1 / 3 * Projectile.spriteDirection); 
            }
            else
            {
                if (Projectile.spriteDirection == 1)
                {
                    targetAngle = MathHelper.Clamp(targetAngle, (float)-Math.PI * 1 / 3, (float)Math.PI * 1 / 6);
                }
                else
                {
                    if (targetAngle < 0)
                    {
                        targetAngle += 2 * (float)Math.PI; 
                    }

                    targetAngle = MathHelper.Clamp(targetAngle, (float)Math.PI * 5 / 6, (float)Math.PI * 4 / 3);
                }

                InitialAngle = targetAngle - FIRSTHALFSWING * SWINGRANGE * Projectile.spriteDirection; 
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write((sbyte)Projectile.spriteDirection);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            Projectile.spriteDirection = reader.ReadSByte();
        }

        public override void AI()
        {
            Owner.itemAnimation = 2;
            Owner.itemTime = 2;

            if (!Owner.active || Owner.dead || Owner.noItems || Owner.CCed)
            {
                Projectile.Kill();
                return;
            }
            switch (CurrentStage)
            {
                case AttackStage.Prepare:
                    PrepareStrike();
                    break;
                case AttackStage.Execute:
                    ExecuteStrike();
                    break;
                default:
                    UnwindStrike();
                    break;
            }

            SetSwordPosition();
            Timer++;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 origin;
            float rotationOffset;
            SpriteEffects effects;

            if (Projectile.spriteDirection > 0)
            {
                origin = new Vector2(0, Projectile.height);
                rotationOffset = MathHelper.ToRadians(45f);
                effects = SpriteEffects.None;
            }
            else
            {
                origin = new Vector2(Projectile.width, Projectile.height);
                rotationOffset = MathHelper.ToRadians(135f);
                effects = SpriteEffects.FlipHorizontally;
            }

            Texture2D texture = ModContent.Request<Texture2D>(Texture).Value;

            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, default, lightColor * Projectile.Opacity, Projectile.rotation + rotationOffset, origin, Projectile.scale, effects, 0);

           
            return false;
        }

        
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 start = Owner.MountedCenter;
            Vector2 end = start + Projectile.rotation.ToRotationVector2() * ((Projectile.Size.Length()) * Projectile.scale);
            float collisionPoint = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), start, end, 15f * Projectile.scale, ref collisionPoint);
        }

       
        public override void CutTiles()
        {
            Vector2 start = Owner.MountedCenter;
            Vector2 end = start + Projectile.rotation.ToRotationVector2() * (Projectile.Size.Length() * Projectile.scale);
            Utils.PlotTileLine(start, end, 15 * Projectile.scale, DelegateMethods.CutTiles);
        }

        
        public override bool? CanDamage()
        {
            if (CurrentStage == AttackStage.Prepare)
                return false;
            return base.CanDamage();
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            
            modifiers.HitDirectionOverride = target.position.X > Owner.MountedCenter.X ? 1 : -1;

           
            if (CurrentAttack == AttackType.Spin)
                modifiers.Knockback += 1;
        }

      
        public void SetSwordPosition()
        {
            Projectile.rotation = InitialAngle + Projectile.spriteDirection * Progress; 

            
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.ToRadians(90f)); 
            Vector2 armPosition = Owner.GetFrontHandPosition(Player.CompositeArmStretchAmount.Full, Projectile.rotation - (float)Math.PI / 2); 

            armPosition.Y += Owner.gfxOffY;
            Projectile.Center = armPosition; 
            Projectile.scale = Size * 1.2f * Owner.GetAdjustedItemScale(Owner.HeldItem); 

            Owner.heldProj = Projectile.whoAmI; 
        }

      
        private void PrepareStrike()
        {
            Progress = WINDUP * SWINGRANGE * (1f - Timer / prepTime); 
            Size = MathHelper.SmoothStep(0, 1, Timer / prepTime); 

            if (Timer >= prepTime)
            {
                SoundEngine.PlaySound(SoundID.Item1); 
                CurrentStage = AttackStage.Execute; 
            }
        }


        private void ExecuteStrike()
        {
            if (CurrentAttack == AttackType.Swing)
            {
                Progress = MathHelper.SmoothStep(0, SWINGRANGE, (1f - UNWIND) * Timer / execTime);

                if (Timer >= execTime)
                {
                    CurrentStage = AttackStage.Unwind;
                }
            }
            else
            {
                Progress = MathHelper.SmoothStep(0, SPINRANGE, (1f - UNWIND / 2) * Timer / (execTime * SPINTIME));

                if (Timer == (int)(execTime * SPINTIME * 3 / 4))
                {
                    
                    Projectile.ResetLocalNPCHitImmunity(); 
                }

                if (Timer >= execTime * SPINTIME)
                {
                    CurrentStage = AttackStage.Unwind;
                }
            }
        }


        private void UnwindStrike()
        {
            if (CurrentAttack == AttackType.Swing)
            {
                Progress = MathHelper.SmoothStep(0, SWINGRANGE, (1f - UNWIND) + UNWIND * Timer / hideTime);
                Size = 1f - MathHelper.SmoothStep(0, 1, Timer / hideTime); 

                if (Timer >= hideTime)
                {
                    Projectile.Kill();
                }
            }
            else
            {
                Progress = MathHelper.SmoothStep(0, SPINRANGE, (1f - UNWIND / 2) + UNWIND / 2 * Timer / (hideTime * SPINTIME / 2));
                Size = 1f - MathHelper.SmoothStep(0, 1, Timer / (hideTime * SPINTIME / 2));

                if (Timer >= hideTime * SPINTIME / 2)
                {
                    Projectile.Kill();
                }
            }
        }
    }
}


