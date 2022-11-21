using Business;
using Business.BusinessObjects;
using DataContracts;

namespace Mediator.Components
{
    public class SubscribeTo : BaseComponent, IDisposable
    {
        private readonly UserData _userData;
        private readonly ProjectData _projectData;

        public SubscribeTo(UserData userData, ProjectData projectData)
        {
            _userData = userData;
            _projectData = projectData;
            _userData.IsActiveChanged += DisplayMessage;
            _projectData.IsActiveChanged += DisplayMessage;
        }

        public void Dispose()
        {
            _userData.IsActiveChanged -= DisplayMessage;
            _projectData.IsActiveChanged -= DisplayMessage;
        }

        public string DisplayMessage(string msg)
        {
            return msg;
        }
    }
}
