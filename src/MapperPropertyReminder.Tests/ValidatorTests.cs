namespace MapperPropertyReminder.Tests
{
    using System;
    using Helper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MapperPropertyReminderTests
    {
        [TestMethod]
        public void MapperPropertyReminderTests_AllPropertiesSet_AllSet_ShouldReturnTrue()
        {
            // Arange
            var complexItem = new ComplexItem
            {
                MyDateTime = DateTime.Now,
                MyDouble = 1d,
                MyInnerComplex = new InnerComplexItem
                {
                    MyInnerDateTime = DateTime.Now,
                    MyInnerDouble = 1d,
                    MyInnerInt = 1,
                    MyInnerString = "a value"
                },
                MyInt = 1,
                MyObject = String.Empty,
                MyString = "a value"
            };

            // Act

            // Assert

            Assert.IsTrue(MapperReminder.AllPropertiesSet(complexItem));
        }

        [TestMethod]
        public void MapperPropertyReminderTests_AllPropertiesSet_AllDefault_ShouldReturnFalse()
        {
            // Arange
            var complexItem = new ComplexItem();

            // Act

            // Assert
            Assert.IsFalse(MapperReminder.AllPropertiesSet(complexItem));
        }

        [TestMethod]
        public void MapperPropertyReminderTests_AllPropertiesSet_DefaultStringProperty_ShouldReturnFalse()
        {
            // Arange
            var complexItem = new ComplexItem
            {
                MyDateTime = DateTime.Now,
                MyDouble = 1d,
                MyInnerComplex = new InnerComplexItem(),
                MyInt = 1,
                MyObject = String.Empty,
            };

            // Act

            // Assert
            Assert.IsFalse(MapperReminder.AllPropertiesSet(complexItem));
        }

        [TestMethod]
        public void MapperPropertyReminderTests_AllPropertiesSet_DefaultComplex_ShouldReturnFalse()
        {
            // Arange
            var complexItem = new ComplexItem
            {
                MyDateTime = DateTime.Now,
                MyDouble = 1d,
                ////MyInnerComplex = new InnerComplexItem(),
                MyInt = 1,
                MyObject = String.Empty,
                MyString = "a value"
            };

            // Act

            // Assert
            Assert.IsFalse(MapperReminder.AllPropertiesSet(complexItem));
        }

        [TestMethod]
        public void MapperPropertyReminderTests_AllPropertiesSet_DefaultInt_ShouldReturnFalse()
        {
            // Arange
            var complexItem = new ComplexItem
            {
                MyDateTime = DateTime.Now,
                MyDouble = 1d,
                MyInnerComplex = new InnerComplexItem(),
                ////MyInt = 1,
                MyObject = String.Empty,
                MyString = "a value"
            };

            // Act

            // Assert
            Assert.IsFalse(MapperReminder.AllPropertiesSet(complexItem));
        }

        [TestMethod]
        public void MapperPropertyReminderTests_AllPropertiesSet_DefaultDouble_ShouldReturnFalse()
        {
            // Arange
            var complexItem = new ComplexItem
            {
                MyDateTime = DateTime.Now,
                ////MyDouble = 1d,
                MyInnerComplex = new InnerComplexItem(),
                MyInt = 1,
                MyObject = String.Empty,
                MyString = "a value"
            };

            // Act

            // Assert
            Assert.IsFalse(MapperReminder.AllPropertiesSet(complexItem));
        }
    }
}