﻿using Business;
using Business.BusinessObjects;
using DataContracts;
using DataContracts.DataObjects;
using Mediator;
using Mediator.Components;

namespace Application;

public class ProgramInteraction
{
    
    private static UserData NowUserData { get; set; }
    private static ProjectData nowProjectData { get; set; }


    public static readonly DataFacade _dataFacade = new DataFacade();
    public static readonly SubscribeTo _subscribeTo = new SubscribeTo(NowUserData, nowProjectData);
    public static readonly AdminBusinessObject _adminBusinessObject = new AdminBusinessObject();
    public static readonly LeaderBusinessObject _leaderBusinessObject = new LeaderBusinessObject();
    public static readonly UserBusinessObject _userBusinessObject = new UserBusinessObject();
    public static ConcreteMediator ConcreteMediatorInteraction = new ConcreteMediator(
        _dataFacade,
        _subscribeTo,
        _adminBusinessObject,
        _leaderBusinessObject,
        _userBusinessObject);

    public static void Menu()
    {
        //TEST IMPLEMENTATION
        //---------------------------------------
        do
        {
            Console.WriteLine("Menu:\n" +
                              "0. New registration\n" +
                              "1. Logging\n" +
                              "2. Add new project\n" +
                              "3. Show a list of projects\n" +
                              "4. ");
            switch (Console.ReadLine())
            {
                case "1":
                    RegisterNewUser();
                    break;
                case "2":
                    //Program.LoginUser = DataFacadeInteraction.LoginingUserData();
                    break;

            }
        } while (true);
        //---------------------------------------
    }

    public static bool RegisterNewUser()
    {
        Console.Write("Enter username: ");
        string userName = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        Console.Write("Enter access role:\n" +
                      "0. Admin\n" +
                      "1. Leader\n" +
                      "2. User");
        Enums.AccessRoles role = new Enums.AccessRoles();
        switch (Console.ReadLine())
        {
            case "0":
                Console.WriteLine("Role selected: Admin");
                role = Enums.AccessRoles.Admin;
                break;
            case "1":
                Console.WriteLine("Role selected: Leader");
                role = Enums.AccessRoles.Leader;
                break;
            case "2":
                Console.WriteLine("Role selected: User");
                role = Enums.AccessRoles.User;
                break;
            default:
                Console.WriteLine(
                    "Incorrectly selected value!" +
                    " Default role selected: User");
                role = Enums.AccessRoles.User;
                break;
        }
        _adminBusinessObject.CreateUserData();
        return true;
    }

    public static bool NewProjectData()
    {
        Console.Write("Enter project name: ");
        string projectName = Console.ReadLine();

        _adminBusinessObject.CreateProjectData();

        return true;
    }

    public static void Print(List<UserData> userData)
    {
        foreach (var user in userData)
        {
            Console.WriteLine("User: {0}", user.User.Username);
            Console.WriteLine("---------------------------------");
            if (user.SubmittedTime.Any())
            {
                foreach (var timeTrackEntry in user.SubmittedTime)
                {
                    Console.WriteLine(timeTrackEntry.Date);
                }
            }
            else
            {
                Console.WriteLine("Empty submitted time list");
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
        }
    }

    public static void Print(List<ProjectData> projectDatas)
    {
        foreach (var project in projectDatas)
        {
            Console.WriteLine("Project: {0}", project.Project.Name);
            Console.WriteLine("---------------------------------");
            if (project.EmployeesList.Any())
            {
                foreach (var employ in project.EmployeesList)
                {
                    Console.WriteLine(employ.Id);
                }
            }
            else
            {
                Console.WriteLine("Empty employees list");
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------------------------------");
        }
    }
}