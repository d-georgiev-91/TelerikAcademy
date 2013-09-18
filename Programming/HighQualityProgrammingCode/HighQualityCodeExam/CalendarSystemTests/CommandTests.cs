using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;

namespace CalendarSystemTests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void CommandParseAddEventNameTest()
        {
            string command = "AddEvent 2012-01-21T20:00:00 | party Viki | home";
            string expected = "AddEvent";
            string actual = Command.Parse(command).Name;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CommandParseDeleteEventsNameTest()
        {
            string command = "DeleteEvents c# exam";
            string expected = "DeleteEvents";
            string actual = Command.Parse(command).Name;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CommandParseListEventsNameTest()
        {
            string command = "ListEvents 2013-11-27T08:30:25 | 25";
            string expected = "ListEvents";
            string actual = Command.Parse(command).Name;
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CommandParseAddEventThreeParametersTest()
        {
            string command = "AddEvent 2012-01-21T20:00:00 | party Viki | home";
            string[] expected = 
            {
                 "2012-01-21T20:00:00",
                 "party Viki",
                 "home"
            };
            string[] actual = Command.Parse(command).Parameters;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CommandParseAddEventTwoParametersTest()
        {
            string command = "AddEvent 2012-01-21T20:00:00 | party Viki";
            string[] expected = 
            {
                 "2012-01-21T20:00:00",
                 "party Viki",
            };
            string[] actual = Command.Parse(command).Parameters;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CommandParseAddEventOneParameterTest()
        {
            string command = "AddEvent 2012-01-21T20:00:00";
            string[] expected = 
            {
                 "2012-01-21T20:00:00",
            };
            string[] actual = Command.Parse(command).Parameters;
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommandParseAddEventNoParametersTest()
        {
            string command = "AddEvent";
            Command parsedCommand = Command.Parse(command);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CommandParseAddEventMoreThanThreeParametersTest()
        {
            string command = "AddEvent 2012-01-21T20:00:00 | party Viki | home | Pesho";
            Command parsedCommand = Command.Parse(command);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CommandParseAddEventWithParameterWhiteSpaceTest()
        {
            string command = "AddEvent 2012-01-21T20:00:00 |  | home";
            Command parsedCommand = Command.Parse(command);
        }
    }
}
