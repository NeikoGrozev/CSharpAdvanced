namespace Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    public class ExtendedDatabaseTests
    {
        [Test]
        public void ConstructorShouldBeAddCorrectData()
        {
            long id = 1234567890;
            string name = "Pesho";

            Person person = new Person(id, name);

            Assert.IsNotNull(person);
        }

        [Test]
        public void GetCorrectIdToPerson()
        {

            long id = 1234567890;
            string name = "Pesho";

            Person person = new Person(id, name);

            Assert.That(id, Is.EqualTo(person.Id));
        }

        [Test]
        public void GetCorrectNameToPerson()
        {

            long id = 1234567890;
            string name = "Pesho";

            Person person = new Person(id, name);

            Assert.That(name, Is.EqualTo(person.UserName));
        }

        [Test]
        public void ConstructorShouldBeCorrect16Persons()
        {
            Person person = new Person(1, "Pesho");
            Person person2 = new Person(2, "Gosho");

            Person[] persons = new Person[] { person, person2 };

            ExtendedDatabase ext = new ExtendedDatabase(persons);

            Assert.AreEqual(persons.Length, ext.Count);
        }

        [Test]
        public void ConstructorShouldBeThrowArgumentExseptionWith17Persons()
        {
            Person[] persons = new Person[17];

            for (int i = 0; i < 17; i++)
            {
                persons[i] = new Person(i, "");
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));
        }

        [Test]
        public void AddMethodShouldBeThrowInvalidOperationExceptionWithOver1Person()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i, "Pesho" + i);
            }

            ExtendedDatabase ext = new ExtendedDatabase(persons);

            Person person = new Person(17, "Ivan");

            Assert.Throws<InvalidOperationException>(() => ext.Add(person));
        }

        [Test]
        public void AddMethodShouldBeThrowInvalidOperationExceptionWhenRepeadedUserName()
        {
            Person person = new Person(11, "Pesho");

            ExtendedDatabase ext = new ExtendedDatabase(person);

            Person anotherPerson = new Person(10, "Pesho");

            Assert.Throws<InvalidOperationException>(() => ext.Add(anotherPerson));
        }

        [Test]
        public void AddMethodShouldBeThrowInvalidOperationExceptionWhenRepeadedId()
        {
            Person person = new Person(11, "Ivan");

            ExtendedDatabase ext = new ExtendedDatabase(person);

            Person anotherPerson = new Person(11, "Nikolay");

            Assert.Throws<InvalidOperationException>(() => ext.Add(anotherPerson));
        }

        [Test]
        public void RemoveMethodShouldBeWorkCorrect()
        {

            Person person = new Person(1, "Pesho");
            Person person2 = new Person(2, "Gosho");

            Person[] persons = new Person[] { person, person2 };

            ExtendedDatabase ext = new ExtendedDatabase(persons);

            Assert.That(2, Is.EqualTo(ext.Count));

            ext.Remove();

            Assert.That(1, Is.EqualTo(ext.Count));
        }

        [Test]
        public void RemoveMethodShouldBeThrowInvalidOperationException()
        {
            Person person = new Person(1, "Pesho");

            ExtendedDatabase ext = new ExtendedDatabase(person);
            ext.Remove();

            Assert.Throws<InvalidOperationException>(() => ext.Remove());
        }

        [Test]
        public void FindByUserNAmeGetCorrectPerson()
        {
            Person person = new Person(1, "Pesho");

            ExtendedDatabase ext = new ExtendedDatabase(person);

            string userName = "Pesho";

            Assert.AreEqual(person, ext.FindByUsername(userName));
        }

        [Test]
        public void FindByUserNameThrowArgumentNullExceptionWithEmptyName()
        {
            string personName = "";

            Person person = new Person(1, "Pesho");

            ExtendedDatabase ext = new ExtendedDatabase(person);

            Assert.Throws<ArgumentNullException>(() => ext.FindByUsername(personName));
        }

        [Test]
        public void FindByUserNameThrowInvalidOperationExceptionWithNotFoundName()
        {

            string personName = "Gosho";

            Person person = new Person(1, "Pesho");

            ExtendedDatabase ext = new ExtendedDatabase(person);

            Assert.Throws<InvalidOperationException>(() => ext.FindByUsername(personName));
        }

        [Test]
        public void FindByIdGetCorrectId()
        {
            Person person = new Person(11, "Pesho");

            ExtendedDatabase ext = new ExtendedDatabase(person);

            long Id = 11;

            Assert.AreEqual(person, ext.FindById(Id));
        }

        [Test]
        public void FindByIdThrowArgumentOutOfRangeException()
        {
            Person person = new Person(1, "Pesho");

            ExtendedDatabase ext = new ExtendedDatabase(person);

            long negativeId = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => ext.FindById(negativeId));
        }

        [Test]
        public void FindByIdThrowInvalidOperationExceptionWithNotFoundId()
        {
            Person person = new Person(1, "Pesho");

            ExtendedDatabase ext = new ExtendedDatabase(person);

            long Id = 100;

            Assert.Throws<InvalidOperationException>(() => ext.FindById(Id));
        }
    }
}