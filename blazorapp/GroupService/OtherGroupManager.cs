namespace blazorapp.GroupService;

public interface IGroupManagementService
{
    void CreateGroup(string groupName);
    bool ValidateGroupKey(string groupKey);
    void AddUser(string groupName, string user);
    void RemoveUser(string groupName, string user);
    void displayEverything();
    List<string> getUsers(string groupName);
}

public class GroupManagementService : IGroupManagementService
{
    public struct Room
    {
        public string groupName;
        public List<string> users;
    }
    private readonly static List<Room> groups = new List<Room>();

    public void displayEverything() {
        foreach(Room group in groups) {
            Console.WriteLine(group.groupName);
            foreach(string user in group.users) {
                Console.WriteLine(user);
            }
        }
    }

    public List<string> getUsers(string groupName) {
        foreach (Room group in groups)
        {
            if (groupName == group.groupName)
            {
                return group.users;
            }
        }
        return new List<string>();
    }

    public void CreateGroup(string groupName)
    {
        // Generate a unique key for the group
        string groupKey = GenerateUniqueKey();

        // In a real-world scenario, you might want to store the group information in a database.
        // For simplicity, we are just storing the key in-memory in this example.
        Room room = new Room();
        room.groupName = groupName;
        room.users = new List<string>();
        groups.Add(room);

    }

    public void AddUser(string groupName, string user)
    {
        foreach (Room group in groups)
        {
            if (groupName == group.groupName)
            {
                group.users.Add(user);
                break;
            }
        }
    }

    public void RemoveUser(string? groupName, string? user)
    {
        foreach (Room group in groups)
        {
            if (groupName == group.groupName)
            {
                group.users.Remove(user);
            }
        }
    }

    public bool ValidateGroupKey(string groupKey)
    {
        foreach (Room group in groups)
        {
            if (group.groupName.Equals(groupKey))
            {
                return true;
            }
        }
        return false;
        // Check if the provided groupKey exists in the mapping
        //return groups.Contains(groupKey);
    }

    private string GenerateUniqueKey()
    {
        // Generate a random string for simplicity
        // In a production scenario, you might want to use a more sophisticated method
        return Guid.NewGuid().ToString("N").Substring(0, 8);
    }
}
