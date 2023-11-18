﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Deus.Content.Tiles.EdenSanctuaryTiles
{
    internal class EdenSoilGrassTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileMergeDirt[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            
            RegisterItemDrop(ModContent.ItemType<Content.Items.Sets.EdenSanctuary.EdenSoil>());

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(155, 127, 111));


        }

    }
}