using System.ComponentModel.DataAnnotations;

namespace WorldAPI.Model
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(10)]
        public string countryCode { get; set; }
    }
}
