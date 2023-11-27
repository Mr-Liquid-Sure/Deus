
using Deus.Content.Tiles.EdenSanctuaryTiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Deus.Content.Items.Sets.EdenSanctuary
{
    public class EdenStoneWall : ModItem
    {
        public override void SetDefaults()
        {
            

            Item.DefaultToPlaceableWall(ModContent.WallType<Content.Tiles.EdenSanctuaryTiles.EdenStoneWallT>());
        }
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 78;
        }
       
    }
}