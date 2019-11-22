using Terraria.ID;
using Terraria.ModLoader;

namespace SolarisProcellae.Items.Sword
{
	public class MightyHerosword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mächtiges Heldenschwert"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("[c/8904B1:Ein mächtiges Schwert eines längst vergessenes Heldens... ]");
		}

		public override void SetDefaults() 
		{
			item.damage = 160;
			item.melee = true;
			item.width = 55;
			item.height = 55;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 550000;
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("Tester");
			item.shootSpeed = 8f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}