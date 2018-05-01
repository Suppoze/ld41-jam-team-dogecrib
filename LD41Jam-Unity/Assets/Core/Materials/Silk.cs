public class Silk : Material
{
    public Silk(Grade grade) : base(grade) { }

    public override string Name => "Silk";
}

public class SilkCloth : Material
{
    public SilkCloth(Grade grade) : base(grade) { }

    public override string Name => "Silk Cloth";
}