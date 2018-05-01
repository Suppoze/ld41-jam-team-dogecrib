using System.Collections;
using System.Collections.Generic;
using Assets.Core.Orders;
using UnityEngine;

public class OrderContainerUI : MonoBehaviour
{
    public OrderCardUI OrderCardUiObject;

    private Dictionary<Order, OrderCardUI> _orderCardMap;
    private ISet<Order> _flaggedForRemoval;

    private void Awake()
    {
        _orderCardMap = new Dictionary<Order, OrderCardUI>();
        _flaggedForRemoval = new HashSet<Order>();
    }

    private void Start()
    {
        StartCoroutine(RemovalCoroutine());
    }

    public void CreateOrderCardFrom(Order order)
    {
        var newOrderCard = Instantiate(OrderCardUiObject, transform);
        newOrderCard.Initialize(order);

        if (_orderCardMap.ContainsKey(order)) return;
        _orderCardMap.Add(order, newOrderCard);
    }

    public void FlagOrderCardForRemovalFor(Order order)
    {
        _flaggedForRemoval.Add(order);
    }

    private IEnumerator RemovalCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5F);
            if (_flaggedForRemoval.Count <= 0) continue;

            foreach (var order in _flaggedForRemoval)
            {
                RemoveOrder(order);
            }
        }
    }

    private void RemoveOrder(Order order)
    {
        if (!_orderCardMap.ContainsKey(order)) return;

        OrderCardUI orderCardUi;
        _orderCardMap.TryGetValue(order, out orderCardUi);
        if (orderCardUi == null) return;

        _orderCardMap.Remove(order);
        Destroy(orderCardUi.gameObject);
    }
}