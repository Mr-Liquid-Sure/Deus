﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Deus.Content.Tiles.TudorHouseTiles
{
    internal class PewterOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 950;
            Main.tileShine2[Type] = true;
            Main.tileLighted[Type] = true;

            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 350;

            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(218, 219, 221), name);

            DustType = DustID.Silver;

            HitSound = new SoundStyle($"{nameof(Deus)}/Assets/Sounds/PewterTink");
            MineResist = 1f;
            MinPick = 30;
        }
        
    }
}