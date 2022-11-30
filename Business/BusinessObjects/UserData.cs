using DataContracts.DataObjects;

namespace Business.BusinessObjects
{
    public class UserData
    {
        public delegate string IsActiveChangedHandlerUser(string msg);
        public event IsActiveChangedHandlerUser? IsActiveChanged;

        public User? User { get; private set; }
        public List<TimeTrackEntry> SubmittedTime;
        public int SumOfSubmittedTime { get; private set; }

        public UserData(User? user, List<TimeTrackEntry>? submittedTime = null)
        {
            User = user;
            SubmittedTime = submittedTime ?? new List<TimeTrackEntry>();
            SumOfSubmittedTime = 0;
        }

        public void AddTimeTrackEntry(TimeTrackEntry newTimeTrackEntry)
        {
            SubmittedTime?.Add(newTimeTrackEntry);
            SumOfSubmittedTime += newTimeTrackEntry.Value;
            IsActiveChanged?.Invoke($"Add new TimeTrackEntry for the {User?.Username}");
        }
    }
}