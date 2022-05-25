using AppointmentPlanner.Core.Models;
using AppointmentPlanner.Core.Services.Interfaces;
using MvvmCross.Commands;
using MvvmCross.ExpandableRecyclerView.Core;
using MvvmCross.ExpandableRecyclerView.Core.Helpers;
using MvvmCross.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentPlanner.Core.ViewModels
{
    public class AppointmentViewModel : MvxViewModel
    {
        private readonly IPeopleService peopleService;

        public AppointmentViewModel(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            if (People == null)
                People = new MvxObservableCollection<ITaskItem>();

            var people = peopleService.GetPeople();
            var peopleItems = people.Select(person => new PersonItem(person));
            People.ReplaceWith(peopleItems);
        }

        public MvxObservableCollection<ITaskItem> People { get; private set; }

        public IMvxCommand AddPersonCommand => new MvxCommand(AddPerson);

        public IMvxCommand<ITaskItem> RemovePersonCommand => new MvxCommand<ITaskItem>(RemovePerson);

        public IMvxCommand<ITaskItem> UnplanPersonCommand => new MvxCommand<ITaskItem>(UnplanPerson);

        private void AddPerson()
        {
            var person = peopleService.AddPerson();
            var personItem = new PersonItem(person);
            People.Add(personItem);
        }

        private void RemovePerson(ITaskItem person)
        {
            People.Remove(person);
        }

        private void UnplanPerson(ITaskItem person)
        {
            People.Update(person, DateTime.MinValue);
        }
    }
}
