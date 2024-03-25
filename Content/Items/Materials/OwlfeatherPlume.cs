using Deus.Content.Items.Placeables.TudorHouseStuff;
using Deus.Content.Tiles.TudorHouseTiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Deus.Content.Items.Materials
{
    public class OwlfeatherPlume : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 16;        
            Item.material = true;
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Gray;
        }
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }
        
    }
}