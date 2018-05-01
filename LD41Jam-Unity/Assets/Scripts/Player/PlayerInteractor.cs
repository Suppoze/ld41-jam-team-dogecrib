using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public PlayerController Player;

    private List<GameObject> _inRange;
    private GameObject _active;

    private void Awake()
    {
        _inRange = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        if (_inRange.Count == 0)
        {
            if (_active == null) return;

            _active.GetComponent<InRangeListener>().NotifyOutOfRange(Player.PlayerIndex);
            _active = null;

            return;
        }

        if (_inRange.Count == 1)
        {
            _active = _inRange.Single();
            SwitchClosestInteractableTo(_active);
            return;
        }

        _active = GetClosestInteractable(_inRange, transform);
        SwitchClosestInteractableTo(_active);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var other = collider.gameObject;
        if (other.layer == LayerMask.NameToLayer("Interactable"))
        {
            _inRange.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var other = collider.gameObject;
        if (other.layer == LayerMask.NameToLayer("Interactable"))
        {
            var interactable = other.GetComponent<InRangeListener>();
            interactable.NotifyOutOfRange(Player.PlayerIndex);
            _inRange.Remove(other);
        }
    }

    public void PushToActiveInteractable()
    {
        if (_active == null) return;
        _active.GetComponent<PushListener>().Push(Player.PopFromPlayer());
    }

    public void PopFromActiveInteractable()
    {
        if (_active == null) return;
        Player.PushToPlayer(_active.GetComponent<PopListener>().Pop());
    }

    public void UseActiveInteractable()
    {
        if (_active == null) return;
        _active.GetComponent<UseListener>().Use();
    }

    private void SwitchClosestInteractableTo(GameObject reachableObject)
    {
        if (_active != null)
        {
            _active.GetComponent<InRangeListener>().NotifyOutOfRange(Player.PlayerIndex);
        }

        reachableObject.GetComponent<InRangeListener>().NotifyInRange(Player.PlayerIndex);
        _active = reachableObject;
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