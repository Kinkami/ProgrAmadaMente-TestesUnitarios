using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyClasses.PersonClasses;
using System.Collections.Generic;

namespace MyClassesTest
{
    [TestClass]
    public class CollectionAssertClassTest
    {
        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void AreCollectionEqualFailBecauseNoComparerTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Fernando", LastName = "Leme" });
            peopleExpected.Add(new Person() { FirstName = "Daiana", LastName = "Leme" });
            peopleExpected.Add(new Person() { FirstName = "Runa", LastName = "Leme" });

            peopleActual = PerMgr.GetPeople();

            //irá falhar em AreEqual compara até se é o mesmo objeto
            //Este passa ok: peopleActual = peopleExpected;

            CollectionAssert.AreNotEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void AreCollectionEqualWithComparerTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Fernando", LastName = "Leme" });
            peopleExpected.Add(new Person() { FirstName = "Daiana", LastName = "Leme" });
            peopleExpected.Add(new Person() { FirstName = "Runa", LastName = "Leme" });

            peopleActual = PerMgr.GetPeople();

            //Com o comparer ele força a ler os dados ao inves de ler se o objeto é o mesmo

            CollectionAssert.AreEqual(peopleExpected, peopleActual,
                Comparer<Person>.Create((x, y) => x.FirstName == y.FirstName && x.LastName == y.LastName ? 0 : 1));
        }

        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void AreCollectionEquivalentTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = PerMgr.GetPeople();

            peopleExpected.Add(peopleActual[1]);
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);


            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("Fernando Henrique Leme")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager PerMgr = new PersonManager();
            List<Person> peopleActual = new List<Person>();

            peopleActual = PerMgr.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(peopleActual, typeof(Supervisor));
        }
    }
}
