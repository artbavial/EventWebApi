using System.ComponentModel.DataAnnotations;

namespace EventWebApi.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int id { get; set; }
    }
}
