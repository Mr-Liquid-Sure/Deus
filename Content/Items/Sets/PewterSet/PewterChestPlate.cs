using Terraria.ID;
using Terraria;
using Terraria.ModLoader;


namespace Deus.Content.Items.Sets.PewterSet
{
    [AutoloadEquip(EquipType.Body)]
    public class PewterChestPlate : ModItem
    {

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.02f;
        }
        public override void SetDefaults()
        {
            Item.value = 60;
            Item.rare = ItemRarityID.Green;
            Item.defense = 5;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PewterBar>(), 13);
            recipe.AddTile(TileID.Anvils);
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }

    }
}
