
using Deus.Content.Projectiles.HallowProj;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Deus.Content.Items.Weapons.HardMode.Hallow
{
    public class CrystalClusterBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Melee;
            Item.autoReuse = false;
            Item.width = 32;
            Item.height = 36;
            Item.useTime = 43;
            Item.useAnimation = 43;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 3f;
            Item.value = Item.buyPrice(0, 0, 87, 34);
            Item.rare = ItemRarityID.Blue;
            Item.crit = 2;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<CrystalClusterProj>();
            Item.noUseGraphic = true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}