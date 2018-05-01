public class CopperOre : Material
{
    public CopperOre(Grade grade) : base(grade) { }

    public override string Name => "Copper Ore";
}

public class Copper : Material
{
    public Copper(Grade grade) : base(grade) { }

    public override string Name => "Copper";
}