using Deus.Core.DeusPlayer;
using Deus.Common.Systems;
using Deus.TestingMayContainOtherPeopleCode.UITest;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Deus.Content.Items.BookUI.Book1
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
            Item.maxStack = 1;
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

                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override bool? UseItem(Player player)
        {
            if (ModContent.GetInstance<UiSystem>().MainUserInterface.CurrentState == null && player.whoAmI == Main.myPlayer)
            {
                ModContent.GetInstance<UiSystem>().ShowMyUI();
                SoundEngine.PlaySound(SoundID.MenuOpen);
                return true;
            }else if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                ModContent.GetInstance<UiSystem>().HideMyUI();
                return true;
            }

            ModContent.GetInstance<UiSystem>().ShowMyUI();
            
            
            SoundEngine.PlaySound(SoundID.MenuOpen);

            return base.UseItem(player);
        }
    }
}