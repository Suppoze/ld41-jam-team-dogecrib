public class Wool : Material
{
    public Wool(Grade grade) : base(grade) { }

    public override string Name => "Wool";
}

public class WoolCloth : Material
{
    public WoolCloth(Grade grade) : base(grade) { }

    public override string Name => "Wool Cloth";
}