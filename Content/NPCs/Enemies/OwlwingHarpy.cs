
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.UI;

namespace Deus.Content.NPCs.Enemies
{
    public class OwlwingHarpy : ModNPC
    {

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 8;
            NPCID.Sets.TrailCacheLength[NPC.type] = 3;
            NPCID.Sets.TrailingMode[NPC.type] = 0;
            var value = new NPCID.Sets.NPCBestiaryDrawModifiers()
            { // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);

        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
          //  bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
            //       BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
             //                   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
            //    new FlavorTextBestiaryInfoElement(""),
         //   });
        }

        public override void SetDefaults()
        {
            NPC.width = 43;
            NPC.height = 29;
            NPC.damage = 10;
            NPC.defense = 2;
            NPC.lifeMax = 58;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath44;
            NPC.value = Item.buyPrice(0, 0, 2, 15);
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) => spawnInfo.SpawnTileY < Main.rockLayer ? SpawnCondition.OverworldNightMonster.Chance * 0.12f : 0f;
        //This code ahead is probably increadibly unpractible
        
        private enum ActionState
        {
            AttackFly,
            HoverFly
        }
        public ref float AI_State => ref NPC.ai[0];
        public ref float AI_Timer => ref NPC.ai[1];

        public ref float AI_Timmersss => ref NPC.ai[2];

        public override void AI()
        {
            switch (AI_State)
            {
                case (float)ActionState.AttackFly:
                    Attacking();
                    break;
                case (float)ActionState.HoverFly:
                    Hover();
                    break;

                    /*Player target = Main.player[NPC.target];
                    NPC.TargetClosest();
                    if (Flying)
                    {


                        AIType = 205;
                        NPC.aiStyle = 5;
                    }
                    if (Timer % 200 == 0)
                    {
                        Flying = false;//after 200 ticks or whatever it switches state to not flying
                    }
                    if (!Flying)
                    {

                        if (Timer2 % 100 == 0)//tbh idk if this works
                        {
                            Flying = true;
                        }
                    }*/

            }
        }
        private void Attacking()
        {

            NPC.TargetClosest(true);
            AI_Timer++;
            NPC.aiStyle = 5;
            AIType = NPCID.Harpy;
            if (AI_Timer == 1 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                AI_Timmersss = Main.rand.NextBool() ? 200 : 150;
                NPC.netUpdate = true;
            }
            if (AI_Timer > AI_Timmersss)
            {
                AI_State = (float)ActionState.HoverFly;
                AI_Timer = 0;
            }
            //AI_State = (float)ActionState.HoverFly;
            // AI_Timer = 0;

        }
        
        private void Hover()
        {
            AI_Timer++;

            if (AI_Timer == 1)
            {
               
            }
            else if (AI_Timer > 40)
            {
                // after .66 seconds, we go to the hover state. //TODO, gravity?
                AI_State = (float)ActionState.AttackFly;
                AI_Timer = 0;
            }
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0 && Main.netMode != NetmodeID.Server)
            {
               
            }
            for (int k = 0; k < 14; k++)
            {
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 0.3f;
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            int frame = (int)NPC.frameCounter;
            NPC.frame.Y = frame * frameHeight;
        }




    }
}
