namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        Phone phone;

        [SetUp]
        public void Setup()
        {
            string make = "HP";
            string model = "11027";

            phone = new Phone(make, model);
        }
       
        [Test]
        public void CreateCorrectPhone()
        {          

            Assert.DoesNotThrow(() => Setup());
        }

        [Test]
        public void GetMakeShoudBeCorrectData()
        {
            string make = "HP";

            Assert.AreEqual(make, phone.Make);
        }

        [Test]
        public void SetMakeShouldBeThrowArgumentExceptionWithNullValue()
        {
            string make = null;
            string model = "1100";

            Assert.Throws<ArgumentException>(() => new Phone(make, model));
        }

        [Test]
        public void GetModelShouldBeCorrectData()
        {
            string model = "11027";

            Assert.AreEqual(model, phone.Model);
        }

        [Test]
        public void SetModelShouldBeThrowArgumentExceptionWithNullValue()
        {
            string make = "HP";
            string model = null;

            Assert.Throws<ArgumentException>(() => new Phone(make, model));
        }

        [Test]
        public void GetCountOnPhonebookShouldBeCorrect()
        {
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void AddContactInPhonebookShouldBeCorrect()
        {
            string name = "Pesho";
            string phoneNumber = "0888 111 888";

            phone.AddContact(name, phoneNumber);

            Assert.AreEqual(1, phone.Count);
        }

        [Test]
        public void AddContactWithSomeNameShouldBeThrowInvalidOperationException()
        {
            string name = "Pesho";
            string phoneNumber = "0888 111 888";

            phone.AddContact(name, phoneNumber);

            Assert.Throws<InvalidOperationException>(() => phone.AddContact(name, phoneNumber));
        }

       [Test]
        public void CallMethodShouldBeFindingNameAndReportCoorectData()
        {            
            string name = "Pesho";
            string phoneNumber = "0888 111 888";

            phone.AddContact(name, phoneNumber);

            string number = phone.Call(name);

            Assert.AreEqual($"Calling {name} - {phoneNumber}...", number);
        }

        [Test]
        public void CallMethodShouldBeThrowIvalidOperationExceptionWhereNotFoundName()
        {
            string name = "Pesho";
            string phoneNumber = "0888 111 888";

            phone.AddContact(name, phoneNumber);

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }
    }
}