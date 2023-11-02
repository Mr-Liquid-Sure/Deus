using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            Projectile.width = 148;
            Projectile.height = 262;

            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 104;
            Projectile.light = 1;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            Projectile.scale = 1.5f;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            if (++Projectile.frameCounter >= 8f)
            {
                Projectile.frameCounter = 0;

                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
            var swingangle = new Vector2(Projectile.ai[0], Projectile.ai[1]);
            Projectile.rotation = swingangle.ToRotation();
            Projectile.position = player.Center + swingangle - new Vector2(Projectile.width / 2, Projectile.height / 2);
            Projectile.spriteDirection = Projectile.direction;


        }

        public override bool PreDraw(ref Color lightColor)
        {
            Vector2 drawPosition = Projectile.Center;
            Color color = Color.Cyan;
            _ = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            var texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;

            var sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

            Vector2 origin = sourceRectangle.Size() / 2f;
            Color drawColor = Projectile.GetAlpha(lightColor);
            Main.EntitySpriteDraw(texture,
                Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
                sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);
            
            return false;
        }
    }
}
