using Business.Mediator;

namespace Business.BusinessObjects
{
    public class LeaderBusinessObject : UserBusinessObject
    {
        public int DoGetMaxHoursPerMonth(string name)
        {
            return (int)Mediator.Notify(
                Interactions.DoGetMaxHoursPerMonth,
                name)!;
        }

        public string DoSetMaxHoursPerMonth(string name, string hours)
        {
            return (string)Mediator.Notify(
                Interactions.DoSetMaxHoursPerMonth,
                name, hours)!;
        }
    }
}
