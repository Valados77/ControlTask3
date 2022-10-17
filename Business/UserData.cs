using DataContracts;

namespace Business
{
    public class UserData
    {
        public delegate void IsActiveChanged(string msg);
        public event IsActiveChanged? Notify;
        public User User { get; private set; }
        public List<TimeTrackEntry> SubmittedTime { get; private set; }
        public int sumOfSubmittedTime = 0;

        public UserData(User user)
        {
            User = user;
        }

        public void AddTimeTrackEntry(TimeTrackEntry newTimeTrackEntry)
        {
            SubmittedTime.Add(newTimeTrackEntry);
            sumOfSubmittedTime += newTimeTrackEntry.Value;
            Notify?.Invoke($"Add new TimeTrackEntry for the {User.Username}");
        }
    }
}
