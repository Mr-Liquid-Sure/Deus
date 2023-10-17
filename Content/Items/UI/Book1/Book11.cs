using Deus.Core.Systems;
using Deus.TestingMayContainOtherPeopleCode.UITest;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Deus.Content.Items.UI.Book1
{
    public class Book11 : ModItem
    {
        public override void SetStaticDefaults()
        {
    

        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            //Item.rare = ModContent.RarityType<ModRarities>();
            Item.maxStack = 1;
            //Item.UseSound = rorAudio.SFX_Scroll;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 1;
            Item.useTime = 1;
            Item.autoReuse = false;
            Item.reuseDelay = 29;
            Item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
              //  .AddIngredient(ModContent.ItemType<Parchment>(), 15)

                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override bool? UseItem(Player player)
        {
            ModContent.GetInstance<UiSystem>().ShowMyUI();
            SoundEngine.PlaySound(SoundID.MenuOpen);
            return base.UseItem(player);
        }
    }
}