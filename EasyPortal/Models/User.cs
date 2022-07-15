using System.Text.Json;

namespace EasyPortal.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PortalItem[]? PortalItems { get; set; }

        public override string ToString() => JsonSerializer.Serialize<User>(this);
    }

}
