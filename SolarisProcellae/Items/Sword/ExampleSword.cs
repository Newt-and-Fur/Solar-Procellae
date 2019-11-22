using Terraria.ID;
using Terraria.ModLoader;

namespace SolarisProcellae.Items.Sword
{
	public class ExampleSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Beispielschwert"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Das ist ein Beispielschwert");
		}

		public override void SetDefaults() 
		{
			item.damage = 1500;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 100;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ExampleProjectile"); //Fügt dem Schwert ein Projektil hinzu
			item.shootSpeed = 8f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ExampleItem>(), 10);
			recipe.AddTile(tileID: TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}