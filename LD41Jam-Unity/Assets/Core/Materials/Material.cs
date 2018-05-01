using Assets.Core.Common;

public enum Grade
{
    LOW,
    NORMAL,
    HIGH
}

public abstract class Material : ITransferable
{
    public Material(Grade grade)
    {
        Grade = grade;
    }

    private Grade _grade;
    public Grade Grade
    {
        get
        {
            return _grade;
        }

        set
        {
            _grade = value;
        }
    }

    public abstract string Name { get; }
}