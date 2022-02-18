using System.ComponentModel.DataAnnotations;

namespace EventWebApi.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
