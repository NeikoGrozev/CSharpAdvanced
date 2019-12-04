namespace Tests
{
    using NUnit.Framework;
    using Database;
    using System;

    public class DatabaseTests
    {
        [Test]
        public void ConstructorShouldBeInitializeWith16Elements()
        {
            int[] array = new int[16];
            Database database = new Database(array);

            Assert.That(16, Is.EqualTo(database.Count));
        }

        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionIsNot16Elements()
        {
            int[] array = new int[17];

            Assert.That(() => new Database(array), Throws.InvalidOperationException);
        }

        [Test]
        public void AddNewElement()
        {
            int[] array = new int[4];
            Database database = new Database(array);

            Assert.That(4, Is.EqualTo(database.Count));

            int element = 1;
            database.Add(element);

            Assert.That(5, Is.EqualTo(database.Count));
        }

        [Test]
        public void AddMoreLessElementOver16()
        {
            int[] array = new int[16];
            Database database = new Database(array);
            int anotherElement = 0;

            Assert.Throws<InvalidOperationException>(() => database.Add(anotherElement));
        }

        [Test]
        public void RemoveOneElement()
        {
            int[] array = new int[4];
            Database database = new Database(array);

            Assert.That(4, Is.EqualTo(database.Count));
            database.Remove();

            Assert.That(3, Is.EqualTo(database.Count));
        }

        [Test]
        public void RemoveShouldBeThrowInvalidOperationExeption()
        {
            int[] array = new int[0];
            Database database = new Database(array);

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMetodShouldBeNewCopyArray()
        {
            int[] array = new int[5];
            Database database = new Database(array);
            int[] anotherArray = database.Fetch();

            Assert.AreEqual(anotherArray.Length, database.Count);
        }
    }
}