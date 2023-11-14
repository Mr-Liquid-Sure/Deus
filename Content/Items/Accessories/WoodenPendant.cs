using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Audio;
using Deus.Content.Buffs.PreHM;
using Terraria.UI;

namespace Deus.Content.Items.Accessories
{
    internal class WoodenPendant : ModItem
    {
        

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
            player.GetModPlayer<WoodenPendantEffect>().SpecialSetBonus = true;
            // TestUiSystem uiSystemInstance = ModContent.GetInstance<TestUiSystem>();
            // uiSystemInstance._menuBar.SetState(uiSystemInstance.TestUiBar);

            //ModContent.GetInstance<TestUiBar>().ShowMyUI();
            Lighting.AddLight(player.position, r: 0.6f, 0.3f, b: 1f);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.Wood, 30)
            .AddTile(TileID.WorkBenches)
            .Register();
        }

    }
    public class WoodenPendantEffect : ModPlayer
    {


        public const int PressUp = 1;


        public const int Cooldown = 1400;
        public const int Duration = 30;


        public const float Thing = 10f;


        public int Dir = -1;


        public bool SpecialSetBonus;
        public int Delay = 0;
        public int Timer = 0;

        public override void ResetEffects()
        {

            SpecialSetBonus = false;

            if (Player.controlUp && Player.releaseUp && Player.doubleTapCardinalTimer[PressUp] < 15)
            {
                Dir = PressUp;
            }

            else
            {
                Dir = -1;
            }
        }
        public override void PreUpdateMovement()
        {


            if (CanUseDash() && Dir != -1 && Delay == 0)
            {


                switch (Dir)
                {

                    case PressUp when Player.velocity.Y > -Thing:
                        {
                            Player.AddBuff(ModContent.BuffType<WoodenPendantBuff>(), 750);
                            SoundEngine.PlaySound(SoundID.MaxMana, Player.position);
                            break;

                        }
                    default:
                        return;
                }
             

                Delay = Cooldown;
                Timer = Duration;



            }

            if (Delay > 0)
                Delay--;
            
          
            if (Timer > 0)
            {



                Timer--;
            }
        }
        



        private bool CanUseDash()
        {
            return SpecialSetBonus

                && !Player.mount.Active; 
        }
    }
}