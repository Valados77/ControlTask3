using Business.Mediator;
using DataContracts;

namespace Business.BusinessObjects
{
    public class AdminBusinessObject : LeaderBusinessObject
    {
        public string DoCreateUserData(
            string? userName,
            string? password,
            Enums.AccessRoles role)
        {
            if (userName == null || password == null)
            {
                return "error";
            }
            return (string)Mediator.Notify(this,
                Interactions.DoCreateUserData,
                userName,
                password,
                role)!;
        }

        public string DoCreateProjectData(string? name)
        {
            if (name == null)
            {
                return "error";
            }
            return (string)Mediator.Notify(this,
                Interactions.DoCreateProjectData,
                name)!;
        }

        public UserData DoReadUserDataById(string id)
        {
            return (UserData)Mediator.Notify(this,
                 Interactions.DoReadUserDataById,
                 id)!;
        }

        public ProjectData DoReadProjectDataById(string id)
        {
            return (ProjectData)Mediator.Notify(this,
                Interactions.DoReadProjectDataById,
                id)!;
        }

        public bool DoDeleteUserDataById(string id)
        {
            return (bool)Mediator.Notify(this,
                Interactions.DoDeleteUserDataById,
                id)!;
        }

        public bool DoDeleteProjectDataById(string id)
        {
            return (bool)Mediator.Notify(this,
                 Interactions.DoDeleteProjectDataById,
                 id)!;
        }

        public string DoAssignProjectForUser(
            string userName,
            string projectName)
        {
            return (string)Mediator.Notify(this,
                Interactions.DoAssignProjectForUser,
                userName,
                projectName)!;
        }

        public string DoAssignProjectLeader(
            string userName,
            string projectName)
        {
            return (string)Mediator.Notify(this,
                Interactions.DoAssignProjectLeader,
                userName,
                projectName)!;
        }
    }
}
