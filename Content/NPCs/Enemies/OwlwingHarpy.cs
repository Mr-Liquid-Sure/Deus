using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

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

            NPC.noGravity = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo) => spawnInfo.SpawnTileY < Main.rockLayer ? SpawnCondition.OverworldNightMonster.Chance * 0.12f : 0f;
        //This code ahead is probably increadibly unpractible
        private double Timer;//Timer for flying state
        private double Timer2;//Timer for when its not flying
        bool Flying = true;//flying state
        public override void OnSpawn(IEntitySource source)
        {
            Timer = 0;
            Flying = true;
        }

        public override void AI()
        {
            Player target = Main.player[NPC.target];
            NPC.TargetClosest();
            if (Flying)
            {
                Vector2 center = NPC.Center;
                Timer++;
                //Were the code for the flying state will be,
                //Should fly over the players head, by around 20 blocks, and shoot feathers at the player


            }
            if (Timer % 200 == 0)
            {
                Flying = false;//after 200 ticks or whatever it switches state to not flying
            }
            if (!Flying)
            {
                Timer2 = 0;
                Timer++;
               //bacicaly its just a short dash at the player, this code heavily needs optimising
                if (Timer2 % 100 == 0)//tbh idk if this works
                {
                    Flying = true;
                }
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
