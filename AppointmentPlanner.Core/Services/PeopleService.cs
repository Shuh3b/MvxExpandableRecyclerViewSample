using AppointmentPlanner.Core.Entities;
using AppointmentPlanner.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace AppointmentPlanner.Core.Services
{
    public class PeopleService : IPeopleService
    {
        /// <summary>
        /// Change to increase/decrease the number of people.
        /// </summary>
        private readonly int peopleCount = 200;

        /// <summary>
        /// Change the number passed to randomNumber.Next(x, potentialHeadersCount) to increase/decrease the number of potential headers.
        /// </summary>
        private readonly int potentialHeadersCount = 20;

        private readonly IList<string> firstNames = new List<string>
        {
            "Barbara", "Mary", "Deborah", "Jonathan", "Mitchell", "Patricia", "Billy", "Brenda", "Clinton", "Joseph", "Kathryn", "Wanda", "Jimmy", "Marie", "Tony", "Paula", "Nicole", "Lori", "Ryan", "Jeffrey",
            "Donna", "Jennifer", "Wesley", "Brian", "Jillian", "David", "Jason", "Stacey", "Jeffrey", "Emily", "Diana", "Shane", "Anthony", "Bethany", "Michael", "Shawn", "Scott", "Doris", "Robert", "Brianna",
            "Eric", "Katie", "Jocelyn", "Justin", "Juan", "Heather", "Joseph", "Robert", "Kristina", "Erin", "Andrew", "Cristian", "Stephanie", "Alexandria", "Mary", "John", "Paula", "Amy", "Melissa", "Anna",
            "Patricia", "Joseph", "Adam", "Brian", "Ernest", "Laura", "Samantha", "Christian", "Miranda", "Amanda", "Darren", "Sally", "Frederick", "Jacob", "Joel", "Bethany", "Mary", "Joshua", "Kevin", "Cynthia",
            "Adam", "Sharon", "Troy", "Jesse", "Brenda", "Olivia", "Nicholas", "Lisa", "Brian", "Robert", "Kimberly", "Sarah", "Randall", "Amy", "Michele", "Eric", "Stephanie", "Anna", "Richard", "Ashley",
        };

        private readonly IList<string> lastNames = new List<string>
        {
            "Barrett", "Huang", "Garcia", "Rivera", "Novak", "Roberts", "Odom", "House", "Barron", "Maldonado", "Ortega", "Anderson", "Parker", "Kelly", "Hicks", "Davis", "Johnson", "Ramirez", "Lee", "Olson",
            "Roman", "Moore", "Thomas", "Porter", "Benson", "Coleman", "Butler", "Norman", "Casey", "Cuevas", "Reeves", "Blackwell", "Costa", "Potter", "Hanson", "Ross", "Steele", "Bennett", "Evans", "Coleman",
            "Ortega", "Bailey", "Hogan", "Johnson", "Turner", "Hamilton", "Henson", "Sanchez", "Weaver", "Odom", "Diaz", "Chavez", "Boyd", "Jones", "Evans", "Best", "Petty", "Miller", "Love", "Mitchell",
            "Bartlett", "Hall", "Jones", "Flowers", "Nguyen", "Humphrey", "Brown", "Jones", "Hanson", "King", "Carter", "Jones", "Elliott", "Watson", "Johnson", "Waters", "Sullivan", "Bush", "Scott", "Phillips",
            "Sims", "Norman", "Delgado", "Huff", "Wade", "Gonzales", "Williams", "Serrano", "Taylor", "Berry", "Hayes", "Green", "Kelly", "Smith", "Rich", "Lopez", "Gibson", "Daugherty", "Walker", "Nelson",
        };

        public IList<Person> GetPeople()
        {
            var people = new List<Person>();

            for (int i = 0; i <= peopleCount; i++)
            {
                people.Add(GenerateRandomPerson());
            }

            return people;
        }

        public Person AddPerson()
        {
            return GenerateRandomPerson();
        }

        private Person GenerateRandomPerson()
        {
            var randomNumber = new Random();
            var firstName = firstNames[randomNumber.Next(firstNames.Count)];
            var lastName = lastNames[randomNumber.Next(lastNames.Count)];
            var appointment = DateTime.Today.AddDays(randomNumber.Next(potentialHeadersCount));

            return new Person(firstName, lastName, appointment);
        }
    }
}
