using System.Collections.Generic;
using System.Linq;
using Core.Interaction;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayerInteractor : MonoBehaviour
{
    public PlayerController Player;

    private LineRenderer _lineRenderer;
    private ISet<GameObject> _inRange;
    private InRangeListener _active;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _inRange = new HashSet<GameObject>();
    }

    private void Start()
    {
        _lineRenderer.enabled = false;
        _lineRenderer.startColor = _lineRenderer.endColor = Player.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        UpdateActiveInteractable();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var other = otherCollider.gameObject;
        if (other.layer == LayerMask.NameToLayer("Interactable"))
        {
            _inRange.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        var other = otherCollider.gameObject;
        if (other.layer == LayerMask.NameToLayer("Interactable"))
        {
            _inRange.Remove(other);
        }
    }

    public void PushToActiveInteractable()
    {
        if (_active == null) return;
        new TransferCommand(
                Player.Inventory,
                _active.gameObject.GetComponent<Inventory>())
            .WithFailureCallback(PushFailure)
            .Execute();
    }

    private void PushFailure()
    {
        throw new System.NotImplementedException();
    }

    public void PopFromActiveInteractable()
    {
        if (_active == null) return;
        new TransferCommand(
            _active.gameObject.GetComponent<Inventory>(),
            Player.Inventory)
            .WithFailureCallback(PopFailure)
            .Execute();
    }

    private void PopFailure()
    {
        throw new System.NotImplementedException();
    }

    public void UseActiveInteractable()
    {
        if (_active == null) return;
        _active.GetComponent<UseListener>().Use();
    }

    private void UpdateActiveInteractable()
    {
        var closest = GetClosestInteractable(_inRange, transform);

        if (closest != null)
        {
            _active = closest.GetComponent<InRangeListener>();
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, closest.transform.position);
            _lineRenderer.enabled = true;
        }
        else
        {
            _active = null;
            _lineRenderer.enabled = false;
        }

        InteractionController.Instance.NotifyActiveChanged(this, _active);
    }

    private static GameObject GetClosestInteractable(IEnumerable<GameObject> enemies, Transform fromThis)
    {
        GameObject bestTarget = null;
        var closestDistanceSqr = Mathf.Infinity;
        var currentPosition = fromThis.position;

        foreach (var potentialTarget in enemies)
        {
            var distance = Vector2.Distance(potentialTarget.transform.position, currentPosition);
            if (!(distance < closestDistanceSqr)) continue;

            closestDistanceSqr = distance;
            bestTarget = potentialTarget;
        }

        return bestTarget;
    }
}