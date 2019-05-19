using Xunit;
using HC_TECH_WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HC_TECH_WebAPI.Test
{
    public class EmployeesUnitTestController
    {
        private Repositories.JSONEmployeeRepository repo;

        public EmployeesUnitTestController()
        {
            repo = new Repositories.JSONEmployeeRepository();
        }

        #region Get(id)
        [Fact]
        public void Task_GetById_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(repo);
            int employeeId = 1;

            //Act
            IActionResult actionResult = controller.Get(employeeId);
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Models.Employee model = Assert.IsType<Models.Employee>(okObjectResult.Value);
            Assert.Equal(employeeId, model.Id);
        }

        [Fact]
        public void Task_GetById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new EmployeesController(repo);
            int employeeId = 100;

            //Act
            IActionResult actionResult = controller.Get(employeeId);
            NotFoundResult notFoundObjectResult = Assert.IsType<NotFoundResult>(actionResult);
            Assert.IsType<NotFoundResult>(notFoundObjectResult);
        }
        #endregion

        #region Add
        [Fact]
        public void Task_Add_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(repo);
            Models.Employee model = new Models.Employee() { Id = 0, FullName = "John Doe", Age = 30, CityCode = "CA", Email = "email@someserver.com", Salary = 100, PictureBase64 = "data:image/jpeg;base64," };

            //Act
            IActionResult actionResult = controller.Post(model);
            OkResult okResult = Assert.IsType<OkResult>(actionResult);
            Assert.IsType<OkResult>(okResult);
        }
        #endregion


        #region Delete
        [Fact]
        public void Task_Delete_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeesController(repo);
            int employeeId = 2;

            //Act
            IActionResult actionResult = controller.Delete(employeeId);
            OkResult okResult = Assert.IsType<OkResult>(actionResult);
            Assert.IsType<OkResult>(okResult);
        }

        [Fact]
        public void Task_Delete_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new EmployeesController(repo);
            int employeeId = 100;

            //Act
            IActionResult actionResult = controller.Delete(employeeId);
            NotFoundResult notFoundObjectResult = Assert.IsType<NotFoundResult>(actionResult);
            Assert.IsType<NotFoundResult>(notFoundObjectResult);
        }
        #endregion
    }
}
