using System;
using ClienteAPI.Models;
using ClienteAPI.Models.Validations;
using Xunit;
using FluentValidation.TestHelper;

namespace ClienteAPI.Tests
{
    public class UnitTest1
    {
        private User _userValido, _userInvalido; 
        private UserModelValidator _validator;

        public UnitTest1()
        {
            _userValido = new User()
            {
                Username = "gcfilho",
                FirstName = "Gerson",
                LastName = "Cardoso",
                Password = "teste",
                Email = "gersoncfilho@mac.com",
                Phone = "99545-4608",
                BirthDate = new DateTime(1970,07,31,02,00,00)
            };
            _validator = new UserModelValidator();
        }

        [Fact]
        public void ShouldPassIfUserIsValid()
        {
            var result = _validator.Validate(_userValido);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            Assert.True(result.IsValid);
        }

        [Fact]
        public void ShouldPassIfUsernameIsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(c=>c.Username, "abcdefghyt");
        }

        [Fact]
        public void ShouldPassIfUsernameIsNullOrEmpty()
        {
            _validator.ShouldHaveValidationErrorFor(c => c.Username, "");
            _validator.ShouldHaveValidationErrorFor(c => c.Username, null as string);
        }

        [Fact]
        public void ShoulPassIfUsernameIs1Character()
        {
            _validator.ShouldHaveValidationErrorFor(c => c.Username, "a");
        }

        [Fact]
        public void ShoulPassIfUsernameIsMoreThan2Chars()
        {
            _validator.ShouldNotHaveValidationErrorFor(c => c.Username, "ab");
        }

        [Fact]
        public void ShoulPassIfUsernameIsMoreThan10Chars()
        {
            _validator.ShouldHaveValidationErrorFor(c => c.Username, "a54as5s4as5as5as45b");
        }

        [Fact]
        public void ShouldPassIfDateIsValid()
        {
            _validator.ShouldNotHaveValidationErrorFor(c=>c.BirthDate, new DateTime(2018,04,23,09,28,00));
            _validator.ShouldNotHaveValidationErrorFor(c => c.BirthDate, DateTime.Today);
        }

    }
}
