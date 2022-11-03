using DataContracts.DataObjects;

namespace Business.BusinesObjects
{
    public class UserData
    {
        public delegate string IsActiveChangedHandler(string msg);
        public event IsActiveChangedHandler? IsActiveChanged;
        public User User { get; private set; }
        public List<TimeTrackEntry> SubmittedTime = new List<TimeTrackEntry>();
        public int SumOfSubmittedTime { get; private set; }

        public UserData(User user, List<TimeTrackEntry>? submittedTime = null)
        {
            User = user;
            SubmittedTime = submittedTime ?? new List<TimeTrackEntry>();
            SumOfSubmittedTime = 0;
        }

        public void AddTimeTrackEntry(TimeTrackEntry newTimeTrackEntry)
        {
            SubmittedTime?.Add(newTimeTrackEntry);
            SumOfSubmittedTime += newTimeTrackEntry.Value;
            IsActiveChanged?.Invoke($"Add new TimeTrackEntry for the {User.Username}");
        }
    }
}
