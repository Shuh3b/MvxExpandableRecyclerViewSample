using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AppointmentPlanner.Core.ViewModels;
using AppointmentPlanner.Droid.Components;
using MvvmCross.ExpandableRecyclerView.DroidX;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Views;

namespace AppointmentPlanner.Droid.Views
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class AppointmentView : MvxActivity<AppointmentViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.AppointmentView);

            MvxExpandableRecyclerView expandableRecyclerView = _view.FindViewById<MvxExpandableRecyclerView>(Resource.Id.appointment_recyclerview);
            // Attach our custom adapter.
            expandableRecyclerView.Adapter = new AppointmentRecyclerAdapter((IMvxAndroidBindingContext)BindingContext);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}