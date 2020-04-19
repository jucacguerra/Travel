using System.ComponentModel.DataAnnotations;

namespace Travel.Web.Data.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

    }
}
