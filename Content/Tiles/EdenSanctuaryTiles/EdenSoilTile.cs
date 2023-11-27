﻿﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Deus.Content.Tiles.EdenSanctuaryTiles
{
    internal class EdenSoilTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileMergeDirt[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(218, 219, 221), name);

        }

    }
}