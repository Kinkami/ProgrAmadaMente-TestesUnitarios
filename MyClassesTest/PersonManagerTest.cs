using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class PersonManagerTest
    {
        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void CreatePerson_ofTypeEmployeeTest()
        {
            PersonManager PerMgr = new PersonManager();
            Person per;

            per = PerMgr.CreatePerson("Fernando","Leme", false);

            Assert.IsInstanceOfType(per, typeof(Employee));

        }



        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void InstanceOfTypeTest()
        {
            PersonManager personManager = new PersonManager();
            Person person;

            person = personManager.CreatePerson("Fernando", "Leme", true);

            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }

        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void DoEmployeeExistTest()
        {
            Supervisor super = new Supervisor();

            super.Employees = new List<Employee>();
            super.Employees.Add(new Employee() { FirstName = "Fernando", LastName = "Leme" });


            Assert.IsTrue(super.Employees.Count > 0);
        }




    }
}
