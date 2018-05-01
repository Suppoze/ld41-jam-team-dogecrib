using System;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Core.Orders
{
    public class Order
    {
        public Item Item { get; }
        public Action<long> OnRemainingMillisUpdated { get; set; }

        private readonly Action<bool, Order> _orderResultCallback;

        private readonly int _timeLimitInSeconds;
        private Task _orderTask;
        private CancellationTokenSource _cancellationTokenSource;

        public Order(Item item, int timeLimitInSeconds, Action<bool, Order> orderResultCallback)
        {
            Item = item;
            _timeLimitInSeconds = timeLimitInSeconds;
            _orderResultCallback = orderResultCallback;
        }

        public void StartCountDown()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _orderTask = Task.Factory.StartNew(OrderDelay, _cancellationTokenSource.Token);
        }

        private async void OrderDelay()
        {
            for (var second = 1; second <= _timeLimitInSeconds; second++)
            {
                HandleCompletedOrder();
                await Task.Delay(1000);
                OnRemainingMillisUpdated?.Invoke(CalculateRemainingMillis(_timeLimitInSeconds, second));
            }

            _orderResultCallback(false, this);
        }

        private void HandleCompletedOrder()
        {
            if (!_cancellationTokenSource.IsCancellationRequested) return;

            _orderResultCallback(true, this);
            _cancellationTokenSource.Cancel(true);
        }

        public void CompleteOrder()
        {
            if (_orderTask.Status == TaskStatus.Running)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        private static int CalculateRemainingMillis(int timeLimitInSeconds, int second)
        {
            return (timeLimitInSeconds - second) * 1000;
        }
    }
}