using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Deus.Content.Projectiles.HallowProj
{

    public class CrystalClusterProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 13;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 150;
            Projectile.height = 275;

           Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 999;
            Projectile.light = 1;
            Projectile.penetrate = -1;
        }
        Vector2 mouseFirstPos = Vector2.Zero;
        public override void AI()
        {
            
           
            
            if (Projectile.timeLeft == 999)
            {
                mouseFirstPos = Main.MouseWorld;
            }
            CheckFrame();
            Player player = Main.player[Projectile.owner];
            Projectile.spriteDirection = (player.Center.X - mouseFirstPos.X) > 0 ? -1 : 1;
            Projectile.Center = player.Center - Vector2.UnitX.RotatedBy((player.Center - mouseFirstPos).ToRotation()) * 60;
            float rotation = Projectile.spriteDirection == 1 ? MathHelper.Pi : 0;
            Projectile.rotation = (player.Center - mouseFirstPos).ToRotation() + rotation;
        }
        private void CheckFrame()
        {
            if (++Projectile.frameCounter >= 4f)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                    Projectile.Kill();
                }
            }
        }
    }
}
