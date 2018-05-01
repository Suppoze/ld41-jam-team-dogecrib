using System;
using System.Collections.Generic;
using Assets.Core.Common;

namespace Assets.Core.Orders
{
    public class OrderGenerator
    {
        private static readonly Random Rng = new Random();

        private static readonly IList<INamed> PossibleItems = new List<INamed>()
        {
            // TODO: collect possible items / types?
            new Wood(Grade.NORMAL),
            new Wool(Grade.NORMAL),
            new Silk(Grade.NORMAL),
            new Copper(Grade.NORMAL)
        };

        public static Order NewOrder(int timeLimitForOrder, Action<bool, Order> onOrderCompleted)
        {
            var orderedItem = PossibleItems[Rng.Next(0, PossibleItems.Count)];
            return new Order(orderedItem, timeLimitForOrder, onOrderCompleted);
        }
    }
}