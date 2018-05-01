using System;
using System.Collections.Generic;

public abstract class Recipe
{
    public abstract Dictionary<Type, int> GetRequiredMaterials();

    private Dictionary<Type, int> CreateMapFromProvidedMaterials(List<Material> materials)
    {
        var providedMaterials = new Dictionary<Type, int>();
        foreach (var material in materials)
        {
            var materialType = material.GetType();
            if (providedMaterials.ContainsKey(materialType))
            {
                int requiredCount = providedMaterials[materialType];
                providedMaterials.Add(materialType, requiredCount + 1);
            }
            else
            {
                providedMaterials.Add(materialType, 1);
            }
        }
        return providedMaterials;
    }

    public bool CanCraft(List<Material> materials)
    {
        var providedMaterials = CreateMapFromProvidedMaterials(materials);

        Dictionary<Type, int> requiredMaterials = GetRequiredMaterials();
        foreach (var pair in requiredMaterials)
        {
            if (providedMaterials.ContainsKey(pair.Key) && providedMaterials[pair.Key] == pair.Value)
            {
                providedMaterials.Remove(pair.Key);
            }
        }

        return providedMaterials.Count == 0 ? true : false;
    }

    public abstract Equipment Craft(List<Material> materials);
}