using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travel.Web.Data.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public ICollection<CityEntity> Cities { get; set; }
    }
}
