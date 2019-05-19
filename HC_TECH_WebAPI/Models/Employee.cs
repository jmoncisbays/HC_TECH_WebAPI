using System.ComponentModel.DataAnnotations;

namespace HC_TECH_WebAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "FullName should be maximum of 150 characters")]
        public string FullName { get; set; }
        [Required]
        [Range(1, 75, ErrorMessage = "Age should be between 1 and 75")]
        public int Age { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "CityCode should be maximum of 3 characters")]
        public string CityCode { get; set; }
        [MaxLength(150, ErrorMessage = "Email should be maximum of 150 characters")]
        public string Email { get; set; }
        [Required]
        [Range(100, 10000, ErrorMessage = "Salary should be between 100 and 10,000")]
        public decimal Salary { get; set; }
        public string PictureBase64 { get; set; }
    }
}
