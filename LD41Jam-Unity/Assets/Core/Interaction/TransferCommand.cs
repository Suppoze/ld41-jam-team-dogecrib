using System;

namespace Core.Interaction
{
    public class TransferCommand : Command
    {
        private Action OnFailure { get; set; }
        
        private readonly Inventory _initiator;
        private readonly Inventory _receiver;

        public TransferCommand(Inventory initiator, Inventory receiver)
        {
            _initiator = initiator;
            _receiver = receiver;
        }
        
        public void Execute()
        {
            if (_receiver.IsFull || _initiator.IsEmpty)
            {
                OnFailure?.Invoke();
                return;
            }
            
            _receiver.Push(_initiator.Pop());
        }

        public TransferCommand WithFailureCallback(Action onFailure)
        {
            OnFailure = onFailure;
            return this;
        }
    }
}