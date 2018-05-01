using System;

public interface Processor
{
    Material Process(Material material);
    bool CanProcess(Material material);
}

public class WoodProcessor : Processor
{
    public bool CanProcess(Material material)
    {
        if (material is Wood) return true;
        return false;
    }

    public Material Process(Material material)
    {
        if (CanProcess(material)) return new Plank(material.Grade);
        else throw new NotImplementedException();
    }
}

public class WoolProcessor : Processor
{
    public bool CanProcess(Material material)
    {
        if (material is Wool) return true;
        return false;
    }

    public Material Process(Material material)
    {
        if (CanProcess(material)) return new WoolCloth(material.Grade);
        else throw new NotImplementedException();
    }
}

public class CopperProcessor : Processor
{
    public bool CanProcess(Material material)
    {
        if (material is CopperOre) return true;
        return false;
    }

    public Material Process(Material material)
    {
        if (CanProcess(material)) return new Copper(material.Grade);
        else throw new NotImplementedException();
    }
}