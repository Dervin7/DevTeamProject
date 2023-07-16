public class DevRepo
{
    private readonly List<Dev> _devs = new List<Dev>();

    public List<Dev> GetAllDevs()
    {
        return _devs;
    }

    public Dev? GetDev(int id)
    {
        foreach (Dev dev in _devs)
        {
            if (dev.Id == id) return dev;
        }
        return default;

    }
    public Dev? GetDev(string email)
    {
        return _devs.FirstOrDefault(d => d.Email == email);
    }

    public bool AddDev(Dev dev)
    {
        if (string.IsNullOrEmpty(dev.Email))
            return false;

        _devs.Add(dev);
        return true;
    }

    public void Seed()
    {
        Dev dev = new Dev();
        dev.Email = "someone@email.com";
        dev.Name = "someone";
        _devs.Add(dev);

        Dev caroline = new Dev();
        caroline.Email = "caroline@girlfriend.com";
        caroline.Name = "Caroline";
        caroline.HasPluralSight = true;
        _devs.Add(caroline);

        Dev john = new Dev();
        john.Email = "john@company.com";
        john.Name = "John";
        john.HasPluralSight = true;
        _devs.Add(john);

        Dev david = new Dev();
        david.Email = "daervin777@gmail.com";
        david.Name = "David";
        _devs.Add(david);
    }
}