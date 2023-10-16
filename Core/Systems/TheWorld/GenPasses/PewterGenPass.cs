using Deus.Content.Tiles.TudorHouseTiles;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Deus.Core.Systems.TheWorld.GenPasses
{
    internal class PewterGenPass : GenPass
    {
        public PewterGenPass(string name, float weight) : base(name, weight) { }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spawning Pewter Ore";

            // TutorialOre
            int maxToSpawn = (int)(Main.maxTilesX * Main.maxTilesY * 6E-05);
            for (int i = 0; i < maxToSpawn; i++)
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)GenVars.worldSurface, Main.maxTilesY - 300);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 5), ModContent.TileType<PewterOreTile>());
            }

        }
    }
}