using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace Deus.Content.Items.Sets.PewterSet
{
    [AutoloadEquip(EquipType.Head)]
    public class PewterHelmet : ModItem
    {

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee)+= 0.02f;
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
            recipe.AddIngredient(ModContent.ItemType<PewterBar>(), 8);
            recipe.AddTile(TileID.Anvils);
            //recipe.AddCondition(conditions: Condition.InGraveyard);
            recipe.Register();
        }

       /* public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<PewterChestPlate>() && legs.type == ModContent.ItemType<CartilageLeggings>();
        }*/

        public override void UpdateArmorSet(Player player)
        {
           /* player.GetDamage<Bonecursed>() += 0.1f;
            player.AddBuff(ModContent.BuffType<CartilageBuff>(), 1);
            player.setBonus = "";*/
        }
    }
}
