using System.Collections.Generic;

public class CarpenterTable : ProcessorStation
{
    protected override List<Processor> GetProcessors()
    {
        return new List<Processor>
        {
            Injector.Instance.WoodProcessor()
        };
    }
}