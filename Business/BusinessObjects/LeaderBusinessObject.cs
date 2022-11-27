
using Business.Mediator;
using Mediator.Components;

namespace Business.BusinessObjects
{
    public class LeaderBusinessObject : UserBusinessObject
    {
        public void DoGetMaxHoursPerMonth(string name)
        {
            this._mediator.Notify(
                Interactions.DoGetMaxHoursPerMonth,
                name);
        }

        public void DoSetMaxHoursPerMonth(string name, string hours)
        {
            this._mediator.Notify(
                Interactions.DoSetMaxHoursPerMonth,
                name,
                hours);
        }
    }
}
