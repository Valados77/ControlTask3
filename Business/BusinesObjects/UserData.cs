using DataContracts;

namespace Business.BusinesObjects
{
    public class UserData
    {
        public delegate void IsActiveChangedHandler(string msg);
        public event IsActiveChangedHandler? IsActiveChanged;
        public User User { get; private set; }
        public List<TimeTrackEntry> SubmittedTime { get; private set; }
        public int SumOfSubmittedTime { get; private set; }

        public UserData(User user)
        {
            User = user;
            SumOfSubmittedTime = 0;
        }

        public void AddTimeTrackEntry(TimeTrackEntry newTimeTrackEntry)
        {
            SubmittedTime.Add(newTimeTrackEntry);
            SumOfSubmittedTime += newTimeTrackEntry.Value;
            IsActiveChanged?.Invoke($"Add new TimeTrackEntry for the {User.Username}");
        }
    }
}
