using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Deus.Content.Tiles.TudorHouseTiles
{
    public class WoodenPileTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Properties
            Main.tileSolidTop[Type] = false;

            Main.tileSpelunker[Type] = false;
            
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;

            HitSound = SoundID.Item1;

            MineResist = 1f;
            MinPick = 1;

            DustType = DustID.WoodFurniture;

            // Names
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 16 };


            // Placement


            //      ChestDrop = ModContent.ItemType<TatteredBarrelItem>();



            TileObjectData.addTile(Type);
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.2f;
            g = 0.2f;
            b = 0.2f;
        }


        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }

        public override void KillMultiTile(int x, int y, int frameX, int frameY)
        {
            //   Item.NewItem(new EntitySource_TileBreak(x, y), x * 16, y * 16, 48, 32, ModContent.ItemType<RizzStatueItem>(), Main.rand.Next(1, 1));

            if (Main.netMode != NetmodeID.Server)
            {

                

                var entitySource = new EntitySource_TileBreak(x, y);

                // We don't want Mod.Find<ModGore> to run on servers as it will crash because gores are not loaded on servers

                
                for (int i = 0; i < 1; i++)
                {


                }
            }


        }
    }
}