public class DevTeamRepo
{
    private readonly List<DevTeam> _teams = new List<DevTeam>();

    public DevTeamRepo() { }
    public DevTeamRepo(List<DevTeam> teams)
    {
        _teams = teams;
    }

    public void Seed(DevRepo devRepo)
    {
        string teamName = "The Breakfast Club";
        AddTeam(teamName);
        DevTeam team = GetTeamByName(teamName);
        team.AddMember(devRepo.GetDev(1));
        team.AddMember(devRepo.GetDev(2));

        string otherTeamName = "The Code Squad";
        AddTeam(otherTeamName);
        DevTeam otherTeam = GetTeamByName(otherTeamName);
        otherTeam.AddMember(devRepo.GetDev(3));
        otherTeam.AddMember(devRepo.GetDev(4));
    }

    public List<DevTeam> GetTeams()
    {
        return _teams;
    }
    public DevTeam? GetTeamByName(string name)
    {
        return _teams.FirstOrDefault(t => t.Name == name);
    }
    public DevTeam? GetTeamById(int id)
    {
        return _teams.FirstOrDefault(t => t.Id == id);
    }

    public bool AddTeam(string name)
    {
        if (string.IsNullOrEmpty(name)) return false;

        DevTeam team = new();
        team.Name = name;

        _teams.Add(team);
        return true;
    }
    public bool AddTeam(string name, List<Dev> members)
    {
        if (string.IsNullOrEmpty(name)) return false;

        DevTeam team = new();
        team.Name = name;

        foreach (Dev dev in members)
        {
            team.AddMember(dev);
        }

        return true;
    }

    public bool RemoveTeam(string name)
    {
        if (string.IsNullOrEmpty(name)) return false;

        DevTeam team = new();
        team.Name = name;

        _teams.Remove(team);
        return true;
    }

    public bool RemoveTeam(string name, List<Dev> members)
    {
        if (string.IsNullOrEmpty(name)) return false;

        DevTeam team = new();
        team.Name = name;

        foreach (Dev dev in members)
        {
            team.RemoveDevFromTeam(dev);
        }

        return true;
    }
}