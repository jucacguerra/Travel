using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Web.Data.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public CountryEntity Country { get; set; }
        public ICollection<TripEntity> Trips { get; set; }
    }
}
