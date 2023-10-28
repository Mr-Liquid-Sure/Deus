using Deus.Common.DamageClasses;
using Deus.Content.Items.BookUI.Book1;
using Deus.Content.Projectiles.HolyProj;
using Deus.Core.UI.CrossUi;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Deus.Content.Items.Weapons.PreHM.Holy
{
    public class ChippedWoodenCross : ModItem
    {
        bool set = false;
        Vector2 mouse;
        int Wood = 0;
        int Perc = 0;

        public override void SetStaticDefaults()
        {
            

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = ModContent.GetInstance<Heretic>();
            Item.width = 32;
            Item.height = 36;
            Item.useTime = 50;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 3f;
            Item.value = Item.buyPrice(0, 0, 87, 34);
            Item.rare = ItemRarityID.Blue;
            Item.useTurn = true;
            Item.crit = 2;
            Item.UseSound = SoundID.Item2;
        }

        public override bool? UseItem(Player pro)
        {
            if (Wood > 0)
            {
                Wood--;
            }

            if (set == false)
            {
                set = true;
                mouse = Main.MouseWorld;
            }
            for (int i = 1; i < 6; i++)
            {
                if (Wood == 0)
                {
                    Wood = 8;
                    Perc++;

                    SoundEngine.PlaySound(SoundID.Item9, pro.position);
                    Vector2 SpawnLoc = new Vector2(mouse.X - 96, mouse.Y - 900);
                    int select = Main.rand.Next(2, 5);
                    if (select == 1)
                    {
                        Projectile.NewProjectile(pro.GetSource_FromThis(), new Vector2(SpawnLoc.X + Main.rand.Next(1, 193), SpawnLoc.Y), new Vector2(0, 9f), ModContent.ProjectileType<WoodenCrossProj>(), Item.damage, 6f, Main.myPlayer);
                    }
                 
                    
                }

            }


            set = false;
            return false;
        }
        public void Charge(Player player)
        {
            if (ModContent.GetInstance<CrossUISystem>().InterUI.CurrentState == null && player.whoAmI == Main.myPlayer)
            {
                ModContent.GetInstance<CrossUISystem>().ShowMyUI();
                SoundEngine.PlaySound(SoundID.MenuOpen);
                
            }
            else if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                ModContent.GetInstance<CrossUISystem>().HideMyUI();
                
            }
            ModContent.GetInstance<CrossUISystem>().ShowMyUI();

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            
           

            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}