using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Audio;
using Deus.Content.Buffs.PreHM;
using Terraria.UI;
using System;
using Deus.Content.Items.Sets.PewterSet;
using Deus.Content.Items.Materials;
using Deus.Common.Systems;
using Terraria.GameInput;
using Humanizer;
using Mono.Cecil;
using static Humanizer.On;

namespace Deus.Content.Items.Accessories
{
    internal class MoonshadowCloak : ModItem
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


        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<OwlfeatherPlume>(), 5)
            .AddTile(TileID.WorkBenches)
            .Register();
        }

    }
  



    

}