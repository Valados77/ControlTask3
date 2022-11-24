﻿
using Business.Mediator;
using DataContracts;

namespace Business.BusinessObjects
{
    public class AdminBusinessObject : LeaderBusinessObject
    {
        public void DoCreateUserData(
            string userName, 
            string password,
            Enums.AccessRoles role)
        {
            this._mediator.Notify(this,
                Interactions.DoCreateUserData, 
                userName, 
                password,
                role);
        }

        public void DoCreateProjectData(string name)
        {
            this._mediator.Notify(this,
                Interactions.DoCreateProjectData,
                name);
        }

        public void DoReadUserDataById(string id)
        {
            this._mediator.Notify(this,
                Interactions.DoReadUserDataById,
                id);
        }

        public void DoReadProjectDataById(string id)
        {
            this._mediator.Notify(this,
                Interactions.DoReadProjectDataById,
                id);
        }

        public void DoDeleteUserDataById(string id)
        {
            this._mediator.Notify(this,
                Interactions.DoDeleteUserDataById, 
                id);
        }

        public void DoDeleteProjectDataById(string id)
        {
            this._mediator.Notify(this,
                Interactions.DoDeleteProjectDataById,
                id);
        }

        public void DoAssignProjectForUser(
            string userName,
            string projectName)
        {
            this._mediator.Notify(this,
                Interactions.DoAssignProjectForUser,
                userName,
                projectName);
        }

        public void DoAssignProjectLeader(
            string userName,
            string projectName)
        {
            this._mediator.Notify(this,
                Interactions.DoAssignProjectLeader,
                userName,
                projectName);
        }
    }
}
