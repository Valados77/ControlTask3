using DataContracts;
using Mediator.Components;

namespace Business.BusinessObjects
{
    public class AdminBusinessObject : LeaderBusinessObject
    {
        public void CreateUserData()
        {
            this._mediator.Notify(this, "DoCreateUserData");
        }

        public void CreateProjectData()
        {
            this._mediator.Notify(this, "DoCreateProjectData");
        }

        public void ReadUserData()
        {
            this._mediator.Notify(this, "DoReadUserData");
        }

        public void ReadProjectData()
        {
            this._mediator.Notify(this, "DoReadProjectData");
        }

        public void DeleteUserData()
        {
            this._mediator.Notify(this, "DoDeleteUserData");
        }

        public void DeleteProjectData()
        {
            this._mediator.Notify(this, "DoDeleteProjectData");
        }

        public void AssignProjectForUser()
        {
            this._mediator.Notify(this, "DoAssignProjectForUser");
        }

        public void AssignProjectLeader()
        {
            this._mediator.Notify(this, "DoAssignProjectLeader");
        }
    }
}
