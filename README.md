- This is a Web API - ASP.NET Core Web Application project which contains an Employees controller.
- The collection of Employees are stored in /FileStorage/employees.json.
- The project implements the Repository pattern (/Repositories/IEmployeeRepository.cs).
- The project uses Depenency Injection:
```
public void ConfigureServices(IServiceCollection services)
{
   ...
   services.AddSingleton<IEmployeeRepository, JSONEmployeeRepository>();
   ...
}
```
- The project includes model/entity validation by adding Data Annotations to the Employee model:
```
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
```
You can use Postman to try such validation by doing a POST to http://localhost:60951/api/employees and including the following body:
```
{
	"age": "43",
	"cityCode": "GDLX",
	"salary": 90
}
```
You should get the following response (400 Bad Request):
```
{
    "Salary": [
        "Salary should be between 100 and 10,000"
    ],
    "CityCode": [
        "CityCode should be maximum of 3 characters"
    ],
    "FullName": [
        "The FullName field is required."
    ]
}
```
