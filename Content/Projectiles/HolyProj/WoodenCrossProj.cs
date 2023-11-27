using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Deus.Content.Projectiles.HolyProj
{
    public class WoodenCrossProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 8;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = 0;
            Projectile.light = 0.2f;
            Projectile.timeLeft = 2400;
            Projectile.penetrate = 1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
        }

    

        

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
            Main.dust[dust].scale = 1.3f;
            Main.dust[dust].noGravity = true;
            int dust1 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.WoodFurniture);
            Main.dust[dust1].scale = 1.2f;
            Main.dust[dust1].noGravity = true;
            if (++Projectile.frameCounter >= 5)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
        }

        public override void Kill(int timeLeft)
        {
            int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.WoodFurniture);
            Main.dust[dust3].noGravity = true;
            Dust dust2 = Main.dust[dust3];
            dust2.velocity -= Projectile.velocity * 0.5f;
            SoundEngine.PlaySound(SoundID.NPCHit1, Projectile.position);
        }
    }
}