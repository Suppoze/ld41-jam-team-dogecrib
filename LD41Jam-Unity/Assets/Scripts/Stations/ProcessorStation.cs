using UnityEngine;

public abstract class ProcessorStation : MonoBehaviour
{
    /*protected abstract List<Processor> GetProcessors();
    
    private Inventory _inventory;
    private InRangeListener _inRangeListener;
    private PushListener _pushListener;
    private PopListener _popListener;

    private bool _processing;

    private void Awake()
    {
        _inventory = GetComponent<Inventory>();
        _inRangeListener = GetComponent<InRangeListener>();
        _pushListener = GetComponent<PushListener>();
        _popListener = GetComponent<PopListener>();

        Assert.IsNotNull(_inventory);
        Assert.IsNotNull(_inRangeListener);
        Assert.IsNotNull(_pushListener);
        Assert.IsNotNull(_popListener);
    }

    private void Start()
    {
        _pushListener.OnPushReceived = item => PutDown(item);
        _popListener.OnPopReceived = () => PickUp();
    }

    private bool CanProcess(Material material)
    {
        List<Processor> processors = GetProcessors();
        foreach (Processor processor in processors)
        {
            if (processor.CanProcess(material)) return true;
        }
        return false;
    }

    private Material Process(Material material)
    {
        if (!CanProcess(material)) return null;

        List<Processor> processors = GetProcessors();
        foreach (Processor processor in processors)
        {
            if (processor.CanProcess(material)) return processor.Process(material);
        }
        return null;
    }

    protected bool PutDown(ITransferable element)
    {
        Debug.Log("Put down element");
        if (_inventory.IsFull) return false;

        if (!(element is Material)) return false;
        
        if (CanProcess(element as Material))
        {
            _inventory.Push(element);
            StartCoroutine("ProcessMaterial");
            return true;
        }
        return false;
    }

    protected ITransferable PickUp()
    {
        Debug.Log("Pick up element");
        if (_inventory.IsEmpty) return null;
        else
        {
            if (_processing) StopCoroutine("ProcessMaterial");
            return _inventory.Pop();
        }
    }
    
    System.Collections.IEnumerator ProcessMaterial()
    {
        _processing = true;
        yield return new WaitForSeconds(3f);
        ITransferable element = _inventory.Pop();
        Material material = element as Material;
        Material processedMaterial = Process(material);
        _inventory.Push(processedMaterial);
    }*/

}