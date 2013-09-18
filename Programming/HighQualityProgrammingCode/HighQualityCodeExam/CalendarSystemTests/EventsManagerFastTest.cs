using CalendarSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CalendarSystemTests
{
    [TestClass]
    public class EventsManagerFastTest
    {
        [TestMethod]
        public void AddEventTest()
        {
            EventsManagerFast target = new EventsManagerFast(); // TODO: Initialize to an appropriate value
            Event ev = null; // TODO: Initialize to an appropriate value
            target.AddEvent(ev);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod]
        public void EventsManagerFastConstructorTest()
        {
            EventsManagerFast target = new EventsManagerFast();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        [TestMethod]
        public void DeleteEventsByTitleTest()
        {
            EventsManagerFast target = new EventsManagerFast(); // TODO: Initialize to an appropriate value
            string title = string.Empty; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.DeleteEventsByTitle(title);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod]
        public void ListEventsTest()
        {
            EventsManagerFast target = new EventsManagerFast(); // TODO: Initialize to an appropriate value
            DateTime date = new DateTime(); // TODO: Initialize to an appropriate value
            int count = 0; // TODO: Initialize to an appropriate value
            IEnumerable<Event> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Event> actual;
            actual = target.ListEvents(date, count);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
