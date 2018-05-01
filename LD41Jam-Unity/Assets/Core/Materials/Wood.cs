public class Wood : Material
{
    public Wood(Grade grade) : base(grade) { }

    public override string Name => "Wood";
}

public class Plank : Material
{
    public Plank(Grade grade) : base(grade) { }

    public override string Name => "Plank";
}