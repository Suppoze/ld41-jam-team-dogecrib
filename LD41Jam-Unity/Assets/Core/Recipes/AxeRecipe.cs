using System;
using System.Collections.Generic;

public class CopperAxeRecipe : Recipe
{
    public override Equipment Craft(List<Material> materials)
    {
        if (CanCraft(materials)) return new CopperAxe();
        else return null;
    }

    public override Dictionary<Type, int> GetRequiredMaterials()
    {
        return new Dictionary<Type, int>
        {
            { typeof(Copper), 3 },
            { typeof(Plank), 2 }
        };
    }
}

public class WoodenAxeRecipe : Recipe
{
    public override Equipment Craft(List<Material> materials)
    {
        if (CanCraft(materials)) return new WoodenAxe();
        else return null;
    }

    public override Dictionary<Type, int> GetRequiredMaterials()
    {
        return new Dictionary<Type, int>
        {
            { typeof(Plank), 5 }
        };
    }
}