using Terraria.ID;
using Terraria.ModLoader;

namespace SolarisProcellae.Items.Gun
{
    public class ExampleGun : ModItem
    {
		public override void SetStaticDefaults() 
            {
                DisplayName.SetDefault("Beispielwaffe");
                Tooltip.SetDefault("Dies ist eine Beispielwaffe");
            }
        

        public override void SetDefaults() 
		{
			item.damage = 1500;
            item.ranged = true;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 5;
            item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
            item.shoot = 10;
			item.shoot = mod.ProjectileType("ExampleProjectile"); //Fügt dem Schwert ein Projektil hinzu
			item.shootSpeed = 16f;
		}

        public override void AddRecipes()  //How to craft this gun
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ExampleItem>(), 10);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}