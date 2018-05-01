using System;
using System.Collections;
using Assets.Core.Orders;
using UnityEngine;

public class OrderController : MonoBehaviour
{
    public OrderContainerUI OrderContainerUi;

    public int TimeLimitForLevel = 60;
    public double TimeLimitDecreaseRateByLevel = 1;

    public int OrdersByLevel = 3;
    public int OrdersIncreaseRateByLevel = 1;

    public void PlacerOrders(int levelCount)
    {
        for (var currentOrder = 0; currentOrder < OrdersByLevel; currentOrder++)
        {
            var startDelay = TimeLimitForLevel / OrdersByLevel * currentOrder;
            var timeLimitForOrder = TimeLimitForLevel / OrdersByLevel;
            StartCoroutine(PlaceOrderDelayed(startDelay, timeLimitForOrder));
        }
    }

    private IEnumerator PlaceOrderDelayed(int startDelay, int timeLimitForOrder)
    {
        yield return new WaitForSeconds(startDelay);
        var order = OrderGenerator.NewOrder(timeLimitForOrder, OnOrderCompleted);
        OrderContainerUi.CreateOrderCardFrom(order);
        order.StartCountDown();
    }

    private void OnOrderCompleted(bool completed, Order order)
    {
        OrderContainerUi.FlagOrderCardForRemovalFor(order);
    }
}