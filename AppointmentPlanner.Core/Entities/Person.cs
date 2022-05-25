using System;

namespace AppointmentPlanner.Core.Entities
{
    public class Person
    {
        public Person(string firstName, string lastName, DateTime? appointment)
        {
            FirstName = firstName;
            LastName = lastName;
            Appointment = appointment;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Appointment { get; set; }
    }
}
