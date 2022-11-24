namespace Business.Mediator;

public enum Interactions
{
    DoLoginUser,
    DoLogoutUser,
    DoReturnAllProjectForUser,
    DoReturnSubmitDateTime,
    DoSetViewingDateTime,
    DoReturnMaxHoursPerMonth,
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