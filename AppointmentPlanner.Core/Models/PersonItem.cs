using AppointmentPlanner.Core.Entities;
using MvvmCross.ExpandableRecyclerView.Core;
using System;

namespace AppointmentPlanner.Core.Models
{
    public class PersonItem : TaskItem<Person, DateTime?>
    {
        public PersonItem(Person model) 
            : base(model)
        { }

        public override DateTime? Header { get => Model.Appointment; set => Model.Appointment = value; }
    }
}
