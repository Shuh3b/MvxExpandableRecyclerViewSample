using AppointmentPlanner.Core.Services;
using AppointmentPlanner.Core.Services.Interfaces;
using AppointmentPlanner.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace AppointmentPlanner.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IPeopleService, PeopleService>();

            RegisterAppStart<AppointmentViewModel>();
        }
    }
}
