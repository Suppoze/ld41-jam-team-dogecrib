using System.Collections.Generic;

public class Loom : ProcessorStation
{
    protected override List<Processor> GetProcessors()
    {
        return new List<Processor>
        {
            Injector.Instance.WoolProcessor()
        };
    }
}
