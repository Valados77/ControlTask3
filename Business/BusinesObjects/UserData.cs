using DataContracts.DataObjects;

namespace Business.BusinesObjects
{
    public class UserData
    {
        public delegate string IsActiveChangedHandler(string msg);
        public event IsActiveChangedHandler? IsActiveChanged;
        public User User { get; private set; }
        public List<TimeTrackEntry> submittedTime = new List<TimeTrackEntry>();
        public int SumOfSubmittedTime { get; private set; }

        public UserData(User user, List<TimeTrackEntry>? submittedTime = null)
        {
            User = user;
            this.submittedTime = submittedTime ?? new List<TimeTrackEntry>();
            SumOfSubmittedTime = 0;
        }

        public void AddTimeTrackEntry(TimeTrackEntry newTimeTrackEntry)
        {
            submittedTime?.Add(newTimeTrackEntry);
            SumOfSubmittedTime += newTimeTrackEntry.Value;
            IsActiveChanged?.Invoke($"Add new TimeTrackEntry for the {User.Username}");
        }
    }
}
