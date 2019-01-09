using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class EmployeeControllerTests
    {
        [Test]
        public void DeleteEmployee_WhenDeletes_ShouldBeRemoved()
        {
            var employeeRepo = new Mock<IEmployeeStorage>();
            EmployeeController employeeController = new EmployeeController(employeeRepo.Object);
            employeeRepo.Setup(e => e.DeleteEmployee(It.IsAny<int>()));
            var result = employeeController.DeleteEmployee(1);
            employeeRepo.Verify(e => e.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_WhenDeletes_ShouldReturnActionResult()
        {
            var employeeRepo = new Mock<IEmployeeStorage>();
            EmployeeController employeeController = new EmployeeController(employeeRepo.Object);
            employeeRepo.Setup(e => e.DeleteEmployee(It.IsAny<int>()));
            var result = employeeController.DeleteEmployee(1);
            Assert.That(result, Is.TypeOf<ActionResult>());
        }
    }
}
