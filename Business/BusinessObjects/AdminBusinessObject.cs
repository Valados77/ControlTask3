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
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return "error";
            }
            return (string)Mediator.Notify(
                Interactions.DoCreateUserData,
                userName,
                password,
                role)!;
        }

        public string DoCreateProjectData(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return "error";
            }
            return (string)Mediator.Notify(
                Interactions.DoCreateProjectData,
                name)!;
        }

        public UserData DoReadUserDataById(string id)
        {
            return (UserData)Mediator.Notify(
                 Interactions.DoReadUserDataById,
                 id)!;
        }

        public ProjectData DoReadProjectDataById(string id)
        {
            return (ProjectData)Mediator.Notify(
                Interactions.DoReadProjectDataById,
                id)!;
        }

        public bool DoDeleteUserDataById(string id)
        {
            return (bool)Mediator.Notify(
                Interactions.DoDeleteUserDataById,
                id)!;
        }

        public bool DoDeleteProjectDataById(string id)
        {
            return (bool)Mediator.Notify(
                 Interactions.DoDeleteProjectDataById,
                 id)!;
        }

        public string DoAssignProjectForUser(
            string userName,
            string projectName)
        {
            return (string)Mediator.Notify(
                Interactions.DoAssignProjectForUser,
                userName,
                projectName)!;
        }

        public string DoAssignProjectLeader(
            string userName,
            string projectName)
        {
            return (string)Mediator.Notify(
                Interactions.DoAssignProjectLeader,
                userName,
                projectName)!;
        }
    }
}
