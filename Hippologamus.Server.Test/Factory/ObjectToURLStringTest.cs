using Hippologamus.Server.Factorys;
using System;
using Xunit;

namespace Hippologamus.Server.Test.Factory
{
    public class ObjectToURLStringTest
    {
        [Theory]
        [InlineData("John", "Lennon", "FirstName=John&LastName=Lennon")]
        [InlineData("Paul", "McCartney", "FirstName=Paul&LastName=McCartney")]
        [InlineData("George", "Harrison", "FirstName=George&LastName=Harrison")]
        [InlineData("Ringo", "Starr", "FirstName=Ringo&LastName=Starr")]
        [InlineData("FirstName", "", "FirstName=FirstName&LastName=")]
        [InlineData("", "LastName", "FirstName=&LastName=LastName")]
        [InlineData("First Name", "Last Name", "FirstName=First+Name&LastName=Last+Name")]
        public void TestPerson_Create(string firstname, string lastName, string expected)
        {
            //arrange
            var person = new TestPerson()
            {
                FirstName = firstname,
                LastName = lastName
            };
            //act
            var value = ObjectToURLString.Create(person);
            //assert
            Assert.Equal(expected, value);
        }

        [Fact]
        public void TestCar_ReliantRobin()
        {
            //arrange
            var car = new TestCar()
            {
                Make = "Reliant",
                NumberOfWheels = 3,
                DateOfManufacture = new DateTime(1973, 12, 24),
                RightHandedDrive = true
            };
            //act
            var value = ObjectToURLString.Create(car);
            //assert
            Assert.Equal("Make=Reliant&NumberOfWheels=3&DateOfManufacture=1973-12-24T00%3a00%3a00&RightHandedDrive=true", value);
        }

        [Fact]
        public void TestCar_Blank()
        {
            //arrange
            var car = new TestCar()
            {
            };
            //act
            var value = ObjectToURLString.Create(car);
            //assert
            Assert.Equal("Make=&NumberOfWheels=0&DateOfManufacture=0001-01-01T00%3a00%3a00&RightHandedDrive=false", value);
        }

        private class TestPerson
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        private class TestCar
        {
            public string Make { get; set; }
            public int NumberOfWheels { get; set; }
            public DateTime DateOfManufacture { get; set; }
            public bool RightHandedDrive { get; set; }
        }
    }
}