using Deus.Common.DamageClasses;
using Deus.Content.Items.BookUI.Book1;
using Deus.Content.Projectiles.CrimsonProj;
using Deus.Content.Projectiles.HolyProj;
using Deus.Core.UI.CrossUi;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Deus.Content.Items.Weapons.PreHM.Crimson
{
    public class Ventriciser : ModItem
    {

        public override void SetStaticDefaults()
        {
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            ItemID.Sets.Spears[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 10); 
            Item.useStyle = ItemUseStyleID.Shoot; 
            Item.useAnimation = 12; 
            Item.useTime = 18; 
            Item.UseSound = SoundID.Item1; 
            Item.autoReuse = true; 
            Item.damage = 9;
            Item.knockBack = 0f;
            Item.noUseGraphic = true; 
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true; 
            Item.shootSpeed = 3.7f; 
            Item.shoot = ModContent.ProjectileType<VetSpearProj>(); 
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<VetSpike>(), damage, knockback, player.whoAmI);
            
            for (int i = 0; i < 80; i++)
            {
                int dust1 = Dust.NewDust(position, 0, 0, DustID.Crimson);
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].position += Main.rand.NextVector2CircularEdge(12.5f, 4.5f).RotatedBy(velocity.ToRotation() + MathHelper.PiOver2) * 2;
                Main.dust[dust1].velocity = velocity * .35f;
                Main.dust[dust1].fadeIn = 1f;

            }
            return true;

        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ && Item.UseSound.HasValue)
            {
                SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            }

            return null;
        }

        



    }
}