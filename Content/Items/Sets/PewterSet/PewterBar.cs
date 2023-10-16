using Deus.Content.Items.Placeables.TudorHouseStuff;
using Deus.Content.Tiles.TudorHouseTiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Deus.Content.Items.Sets.PewterSet
{
    public class PewterBar : ModItem
    {
        public override void SetDefaults()
        {


            Item.width = 15;
            Item.height = 12;

            Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useStyle = ItemUseStyleID.Swing;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.consumable = true;
            Item.material = true;

            Item.maxStack = 9999;

            Item.createTile = ModContent.TileType<PewterBarTile>();
            Item.rare = ItemRarityID.Orange;
        }
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PewterOre>(), 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}