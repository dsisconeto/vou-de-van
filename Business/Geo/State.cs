using System.ComponentModel.DataAnnotations;
using Business.Support;

namespace Business.Geo
{
    public class State : DefaultEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(2)]
        public string Initials { get; set; }
    }
}
