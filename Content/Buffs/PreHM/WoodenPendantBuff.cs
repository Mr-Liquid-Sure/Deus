using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
using Deus.Common.Systems.ParticleSystem;
using Deus.Content.Particles;

namespace Deus.Content.Buffs.PreHM
{
    class WoodenPendantBuff : ModBuff
    {
        public override void SetStaticDefaults() {
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
        public override LocalizedText Description => base.Description;
        public override void Update(Player player, ref int buffIndex)
        {
            float distance = 100;
            /*for (int i = 0; i < 90; i++) 
            {
                 
                 double deg = i * 4;
                 double rad = (deg) * (Math.PI / 180);
                 float xd = player.Center.X - (float)(Math.Cos(rad) * distance);
                 float yd = player.Center.Y - (float)(Math.Sin(rad) * distance);
                 int dust = Dust.NewDust(new Vector2(xd, yd), 3, 3, DustID.JungleTorch, 0f, 0f, 0, new Color(175, 160, 120), 1f);
                 Main.dust[dust].noGravity = true;

            }*/
            for (int i = 0; i < 2; i++)
            {
                float dist = Main.rand.NextFloat(distance - 10, distance + 10);
                float rot = Main.rand.NextFloat(0, MathHelper.TwoPi);
                Vector2 pos = player.Center + rot.ToRotationVector2() * dist;
                Vector2 vel = (pos - player.Center).SafeNormalize(Vector2.Zero).RotatedBy(MathHelper.PiOver2) * Main.rand.NextFloat(10f, 14f);
                Particle.NewParticle<Wind>(pos, vel, Color.Green, 1f, 1f, 0f, player.whoAmI, player.velocity.X, player.velocity.Y);

                if (Main.rand.NextBool(10) && Collision.CanHitLine(player.Center, 0, 0, pos, 0, 0))
                {
                    Gore.NewGore(null, pos, vel, GoreID.TreeLeaf_Normal, 0.7f);
                }
            }
            for (int i = 0; i<200; i++){
                if (((Main.npc[i].Center.X-player.Center.X)*(Main.npc[i].Center.X-player.Center.X))+((Main.npc[i].Center.Y-player.Center.Y)*(Main.npc[i].Center.Y-player.Center.Y))<(distance *distance)){
                    Main.npc[i].AddBuff(ModContent.BuffType<WoodenPendantDebuff>(),180);
                }
            }
        }
    }
}