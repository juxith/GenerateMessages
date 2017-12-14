using GenerateMessages.BLL;
using GenerateMessages.Models;
using NUnit.Framework;
using System;

namespace GenerateMessages.Tests
{
    [TestFixture]
    public class MockData
    {
        Manager mgr = Factory.Create();

        [Test]
        public void CanGenerateMessage()
        {
            var guest = new Guest()
            {
                FirstName = "Judy",
                LastName = "Thao",
                Reservation = new Reservation()
                {
                    RoomNumber = 101,
                    StartTimestamp = 1513785600,
                    EndTimestamp = 1513854000,
                }
            };

            var company = new CompanyInfo()
            {
                Company = "Skyline Hotel",
                City = "New York City",
                Timezone = "US/Eastern"
            };

            var template = new Template()
            {
                Name = "Testing",
                Message = "Hello {FirstName}. Thank you for choosing {Company}. Your check-in time is for {Check-In} for room {RoomNumber}. Pleae let me know if there is anything I could assist you with"
            };

            var message = mgr.LoadMessage(guest, company, template);

            Assert.AreEqual("Hello Judy. Thank you for choosing Skyline Hotel. Your check-in time is for 12/20/2017 4:00:00 PM for room 101. Pleae let me know if there is anything I could assist you with", message);
        }

        [Test]
        public void CanGetAllGuests()
        {
            var guests = mgr.LoadAllGuests();

            Assert.AreEqual(3, guests.Count);
        }

        [Test]
        public void CanGetAllCompanies()
        {
            var companies = mgr.LoadAlCompanies();

            Assert.AreEqual(3, companies.Count);
        }

        [Test]
        public void CanAddNewTemplateAndGetAllTemplates()
        {
            var beforeAdd = mgr.LoadAllTemplates();

            Assert.AreEqual(3, beforeAdd.Count);

            var template = new Template()
            {
                Name = "Testing",
                Message = "Hello {FirstName}! We are testing the messaging system for {Company}."
            };

            mgr.CreateTemplate(template);

            var afterAdd = mgr.LoadAllTemplates();

            Assert.AreEqual(4, afterAdd.Count);
        }

        [Test]
        public void CanGetSingleGuest()
        {
            var guest = mgr.LoadGuest(1);

            Assert.AreEqual("Jane" , guest.FirstName);
            Assert.AreEqual("Doe", guest.LastName);
            Assert.AreEqual(101, guest.Reservation.RoomNumber);
            Assert.AreEqual(new DateTime(2017, 12, 20, 16, 0, 0), guest.Reservation.CheckIn);
            Assert.AreEqual(new DateTime(2017, 12, 21, 11, 0, 0), guest.Reservation.CheckOut);
        }

        [Test]
        public void CanGetSingleCompany()
        {
            var company = mgr.LoadCompany(2);

            Assert.AreEqual("Grand Central Hotel", company.Company);
            Assert.AreEqual("Minneapolis", company.City);
            Assert.AreEqual(TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"), company.TimeZoneInfo);
        }

        [Test]
        public void CanGetSingleTemplate()
        {
            var template = mgr.LoadTemplate(3);

            Assert.AreEqual("Follow-Up", template.Name);
            Assert.AreEqual("Thank you for staying with us at {Company}, We hope you enjoyed your stay and hope to see you again soon.", template.Message);
        }

        [Test]
        public void CanGetGreeting()
        {
            var greeting = MessageGreeting.GetGreeting(new DateTime(2017,12,12, 05,0,0));
            var greetingTwo = MessageGreeting.GetGreeting(new DateTime(2017, 12, 12, 12, 01, 0));
            var greetingThree = MessageGreeting.GetGreeting(new DateTime(2017, 12, 12, 17, 01, 0));

            Assert.AreEqual("Good morning ", greeting);
            Assert.AreEqual("Good afternoon ", greetingTwo);
            Assert.AreEqual("Good evening ", greetingThree);
        }
    }
}
