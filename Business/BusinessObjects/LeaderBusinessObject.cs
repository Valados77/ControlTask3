
using Mediator.Components;

namespace Business.BusinessObjects
{
    public class LeaderBusinessObject : UserBusinessObject
    {
        public void DoReturnMaxHoursPerMonth()
        {
            this._mediator.Notify(this, "DoReturnMaxHoursPerMonth");
        }

        public void DoSetMaxHoursPerMonth()
        {
            this._mediator.Notify(this, "DoSetMaxHoursPerMonth");
        }
    }
}
