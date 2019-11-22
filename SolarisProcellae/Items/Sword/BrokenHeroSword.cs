using Terraria.ID;
using Terraria.ModLoader;

namespace SolarisProcellae.Items.Sword
{
	public class BrokenHeroSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Gebrochenes Heldenschwert"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Das Gebrochene Heldenschwert");
		}


		public override void SetDefaults() 
		{
			item.damage = 1501;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 100;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 300);
			recipe.AddIngredient(ItemID.FragmentSolar, 300);
			recipe.AddIngredient(ItemID.FragmentStardust, 300);
			recipe.AddIngredient(ItemID.FragmentVortex, 300);
			recipe.AddIngredient(ItemID.LunarTabletFragment, 20);
			recipe.AddIngredient(itemID: ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.Minishark);
			recipe.AddIngredient(ItemID.LastPrism);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.Meowmere);
			recipe.AddIngredient(ItemID.LunarBar, 100);
			recipe.AddIngredient(ItemID.PlatinumCoin, 100);
			recipe.AddTile(tileID: TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}