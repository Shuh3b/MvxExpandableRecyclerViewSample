using AppointmentPlanner.Core.Entities;
using System.Collections.Generic;

namespace AppointmentPlanner.Core.Services.Interfaces
{
    public interface IPeopleService
    {
        IList<Person> GetPeople();

        Person AddPerson();
    }
}
