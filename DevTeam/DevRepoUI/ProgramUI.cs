public class ProgramUI
{
    private DevRepo _devRepo;
    private DevTeamRepo _teamRepo;

    public ProgramUI(DevRepo devRepo, DevTeamRepo teamRepo)
    {

        _devRepo = devRepo;
        _teamRepo = teamRepo;
    }

    public void Run()
    {

        Menu();
    }
    private void Menu()
    {
        bool continueToRun = true;

        while (continueToRun)
        {
            Console.Clear();
            Console.WriteLine("Please select an option:\n" +
                "1. List all Devs\n" +
                "2. List all Teams\n" +
                "3. Add Dev to Team\n" +
                "4. Remove Dev from Team\n" +
                "5. Exit\n");

            string selection = Console.ReadLine();

            switch (selection)
            {
                case "1":
                    ListAllDevs();
                    break;
                case "2":
                    ListAllTeams();
                    break;
                case "3":
                    AddDevToTeam();
                    break;
                case "4":
                    RemoveDevFromTeam();
                    break;
                case "5":
                    continueToRun = false;
                    Exit();
                    break;
                default:
                    break;
            }
        }
    }

    private void ListAllDevs()
    {
        Console.Clear();
        ListDevs();
        PauseAndContinue();
    }
    private void ListDevs()
    {
        foreach (Dev dev in _devRepo.GetAllDevs())
            Console.WriteLine(dev);
    }
    private void ListAllTeams()
    {
        Console.Clear();
        ListTeams();
        PauseAndContinue();
    }
    private void ListTeams()
    {
        foreach (DevTeam team in _teamRepo.GetTeams())
        {
            Console.WriteLine($"{team.Id} - {team.Name}");
            foreach (Dev member in team.GetTeamMembers())
            {
                Console.WriteLine("    " + member);
            }
        }
    }

    private void AddDevToTeam()
    {
        Console.Clear();
        Console.WriteLine("Choose a team to add to.");
        ListTeams();
        Console.Write("\nId: ");
        string teamChoice = Console.ReadLine();

        DevTeam team = _teamRepo.GetTeamById(Convert.ToInt32(teamChoice));
        if (team == null)
        {
            ShowError("Invalid Team ID!");
            PauseAndContinue();
            return;
        }

        Console.WriteLine("Choose which dev to add to this team.");

        foreach (Dev dev in _devRepo.GetAllDevs())
            if (!team.IsDevOnTeam(dev))
                Console.WriteLine(dev);

        Console.Write("\nId: ");
        string devChoice = Console.ReadLine();
        int devId = Convert.ToInt32(devChoice);
        Dev developer = _devRepo.GetDev(devId);
        if (developer == null)
        {
            ShowError("Invalid Developer ID!");
            PauseAndContinue();
            return;
        }
        team.AddMember(developer);

        Console.WriteLine("Dev was successfully added to the team!");

        PauseAndContinue();
    }

    public void RemoveDevFromTeam()
    {
        Console.Clear();
        Console.WriteLine("Choose a Team to remove from.");
        ListTeams();
        Console.Write("\nId: ");
        string teamChoice = Console.ReadLine();

        DevTeam team = _teamRepo.GetTeamById(Convert.ToInt32(teamChoice));
        if (team == null)
        {
            ShowError("Invalid Team ID!");
            PauseAndContinue();
            return;
        }

        Console.WriteLine("Choose which dev to remove from this team");

        foreach (Dev dev in _devRepo.GetAllDevs())
            if (team.IsDevOnTeam(dev))
                Console.WriteLine(dev);

        Console.Write("\nId: ");
        string devChoice = Console.ReadLine();
        int devId = Convert.ToInt32(devChoice);
        Dev developer = _devRepo.GetDev(devId);
        if (developer == null)
        {
            ShowError("Invalid Developer ID!");
            PauseAndContinue();
            return;
        }
        team.RemoveDevFromTeam(developer);

        Console.WriteLine("Dev was successfully removed from the team!");

        PauseAndContinue();
    }

    private void Exit()
    {
        Console.Clear();
        Console.WriteLine("\n\n      Goodbye!\n\n");
        Thread.Sleep(1000);
    }
    private void PauseAndContinue()
    {
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}