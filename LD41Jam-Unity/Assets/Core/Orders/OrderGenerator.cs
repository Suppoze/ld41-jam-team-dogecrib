using System;
using System.Collections.Generic;

namespace Assets.Core.Orders
{
    public class OrderGenerator
    {
        private static readonly Random Rng = new Random();

        private static readonly IList<Item> PossibleItems = new List<Item>
        {
            new Item
            {
                Artwork = null,
                Grade = Grade.Normal,
                Name = "TestItem"
            }
        };

        public static Order NewOrder(int timeLimitForOrder, Action<bool, Order> onOrderCompleted)
        {
            var orderedItem = PossibleItems[Rng.Next(0, PossibleItems.Count)];
            return new Order(orderedItem, timeLimitForOrder, onOrderCompleted);
        }
    }
}