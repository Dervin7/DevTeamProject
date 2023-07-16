public class DevTeam
{
    private static int _count = 0;

    private readonly List<Dev> _members = new List<Dev>();
    public int Id { get; private set; }
    public string Name { get; set; }

    public DevTeam()
    {
        Id = ++_count;
    }


    public List<Dev> GetTeamMembers()
    {
        return _members;
    }

    public bool AddMember(Dev dev)
    {
        if (dev == null) return false;

        _members.Add(dev);
        return true;
    }
    public bool IsDevOnTeam(Dev dev)
    {
        return _members.Contains(dev);
    }

    public bool RemoveDevFromTeam(Dev dev)
    {
        if (dev == null) return false;

        _members.Remove(dev);
        return true;
    }
}