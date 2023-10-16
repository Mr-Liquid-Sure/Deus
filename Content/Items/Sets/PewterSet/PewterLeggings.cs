using Terraria.ID;
using Terraria;
using Terraria.ModLoader;


namespace Deus.Content.Items.Sets.PewterSet
{
    [AutoloadEquip(EquipType.Legs)]
    public class PewterLeggings : ModItem
    {

        public override void UpdateEquip(Player player)
        {
            player.GetAttackSpeed(DamageClass.Melee) += 0.02f;
        }
        public override void SetDefaults()
        {
            Item.value = 60;
            Item.rare = ItemRarityID.Green;
            Item.defense = 4;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PewterBar>(), 5);
            recipe.AddTile(TileID.Anvils);

            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }

    }
}
