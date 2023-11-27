using Terraria;

namespace Deus.Common.Utils;

public partial class DeusUtils
{
    //To use this,,,
    //In a tile's SetStaticDefaults....
    //(Mod Solution name).tileMerge[Type, Mod.Find<ModTile>("{TILE_NAME}").Type] = true; (Without the curly brackets)
    //Deus.tileMerge[Type, Mod.Find<ModTile>("{TILE_NAME}").Type] = true;
    //Repeat this if you want specific modded blocks to merge together.
    // - Zero
    public static void Merge(int tile, int tile2)
    {
        Main.tileMerge[tile][tile2] = true;
        Main.tileMerge[tile2][tile] = true;
    }
}
