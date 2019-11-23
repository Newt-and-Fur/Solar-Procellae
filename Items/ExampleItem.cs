using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SolarisProcellae.Items
{
    public class ExampleItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Das ist ein Beispiel Item");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 1;
            // Set other item.X values here
        }

        public override void AddRecipes()
        {
            // Recipes here. See Basic Recipe Guide
        }
    }
}