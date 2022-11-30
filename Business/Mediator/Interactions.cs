namespace Business.Mediator;

public enum Interactions
{
    DoLoginUser,
    DoLogoutUser,
    DoGetAllProjectForUser,
    DoGetSubmitDateTime,
    DoSetViewingDateTime,
    DoGetMaxHoursPerMonth,
    DoSetMaxHoursPerMonth,
    DoCreateUserData,
    DoCreateProjectData,
    DoReadUserDataById,
    DoReadProjectDataById,
    DoDeleteUserDataById,
    DoDeleteProjectDataById,
    DoAssignProjectForUser,
    DoAssignProjectLeader
}