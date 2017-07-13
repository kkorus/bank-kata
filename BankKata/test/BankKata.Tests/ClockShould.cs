using System;
using BankKata.App;
using NUnit.Framework;

namespace BankKata.Tests
{
    [TestFixture]
    public class ClockShould
    {
        [Test]
        public void Return_Todays_Date_In_dd_MM_yyyy_Format()
        {
            // Arrange
            var clock = new TestableClock();

            // Act
            var date = clock.GetCurrentDateAsString();

            // Assert
            Assert.That(date, Is.EqualTo("24/04/2015"));
        }

        private class TestableClock : Clock
        {
            protected override DateTime GetToday()
            {
                return new DateTime(2015, 4, 24);
            }
        }
    }
}
