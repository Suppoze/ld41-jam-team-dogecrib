using System.Collections.Generic;

public class Forge : ProcessorStation
{
    protected override List<Processor> GetProcessors()
    {
        return new List<Processor>
        {
            Injector.Instance.CopperProcessor()
        };
    }
}