using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
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
            double distance = 50;
            for (int i = 0; i < 90; i++) 
            {
                 
                 double deg = i * 4;
                 double rad = (deg) * (Math.PI / 180);
                 float xd = player.Center.X - (float)(Math.Cos(rad) * distance);
                 float yd = player.Center.Y - (float)(Math.Sin(rad) * distance);
                 int dust = Dust.NewDust(new Vector2(xd, yd), 3, 3, DustID.JungleTorch, 0f, 0f, 0, new Color(175, 160, 120), 1f);
                 Main.dust[dust].noGravity = true;

                //Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
               // var d = Dust.NewDustPerfect(Main.player[i].Center, DustID.Grass, speed * 5, Scale: 3f);
               // ;
               // d.noGravity = true;
                
            }
            for (int i = 0; i<200; i++){
                if (((Main.npc[i].Center.X-player.Center.X)*(Main.npc[i].Center.X-player.Center.X))+((Main.npc[i].Center.Y-player.Center.Y)*(Main.npc[i].Center.Y-player.Center.Y))<(distance *distance)){
                    Main.npc[i].AddBuff(ModContent.BuffType<WoodenPendantDebuff>(),180);
                }
            }
        }
    }
}