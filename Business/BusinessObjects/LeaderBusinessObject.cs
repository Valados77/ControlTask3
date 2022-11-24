
using Business.Mediator;
using Mediator.Components;

namespace Business.BusinessObjects
{
    public class LeaderBusinessObject : UserBusinessObject
    {
        public void DoReturnMaxHoursPerMonth(string name)
        {
            this._mediator.Notify(this,
                Interactions.DoReturnMaxHoursPerMonth,
                name);
        }

        public void DoSetMaxHoursPerMonth(string name, string hours)
        {
            this._mediator.Notify(this,
                Interactions.DoSetMaxHoursPerMonth,
                name,
                hours);
        }
    }
}
