using System;
using NUnit.Framework;

namespace TestingDemo.Test
{
    [TestFixture]
    public class TestBasicStuff
    {
        [SetUp]
        public void SetUp()
        {
            //_employeeRepository = Substitute.For<IEmployeeRepository>();
        }

        [Test]
        public void TestNothing()
        {
            // ARRANGE

            // ACT

            // ASSERT
            Assert.True(true);
        }
    }
}


/*
_employeeRepository
    .GetEmployees()
    .Returns(new List<Employee> { new Employee { Id = 1, FirstName = "Kalle", LastName = "Anka", Department = Departments.Development, MonthlySalary = 10000 } });

_employeeRepository.Received().AddEmployee(Arg.Any<Employee>());
_employeeRepository.DidNotReceive().AddEmployee(Arg.Any<Employee>());  

[TestCase(1, 1, 20, 20, true)] // Correct
[TestCase(1, 1, 19, 20, false)] // To few working hours
public void TestGetAllEmployees(int employeeId, int weekNumber, int numberOfHoursWorked, int numberOfHoursAbsence, bool isValid)
*/
