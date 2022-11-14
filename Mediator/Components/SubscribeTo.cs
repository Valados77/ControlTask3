using Business;
using DataContracts;

namespace Mediator.Components
{
    public class SubscribeTo : BaseComponent
    {

        public List<string> ActionList { get; set; }

        public SubscribeTo()
        {
            ActionList = new List<string>();
        }

        public void SubscribeToSomething(Action action)
        {
            ActionList.Add($"Add new action");
            this._mediator.Notify(this, "new action");
        }
    }
}
