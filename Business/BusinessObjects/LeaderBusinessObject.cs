using Business.Mediator;

namespace Business.BusinessObjects
{
    public class LeaderBusinessObject : UserBusinessObject
    {
        public int DoGetMaxHoursPerMonth(string name)
        {
            return (int)Mediator.Notify(this,
                Interactions.DoGetMaxHoursPerMonth,
                name)!;
        }

        public string DoSetMaxHoursPerMonth(string name, string hours)
        {
            return (string)Mediator.Notify(this,
                Interactions.DoSetMaxHoursPerMonth,
                name, hours)!;
        }
    }
}
