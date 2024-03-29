using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Deus.Content.Buffs.PreHM;
using Deus.Content.Items.Sets.PewterSet;
using Deus.Content.Items.Materials;

namespace Deus.Content.Items.Accessories
{
    internal class LunarLense : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 10));
            ItemID.Sets.AnimatesAsSoul[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 19;
            Item.value = 12000;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.defense = 1;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Generic) += 5;
            player.AddBuff(BuffID.NightOwl,60);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Lens, 1)
            .AddIngredient(ModContent.ItemType<OwlfeatherPlume>(), 3)
            .AddTile(TileID.WorkBenches)
            .Register();
        }

    }
}