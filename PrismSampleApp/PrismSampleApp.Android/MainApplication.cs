using System;
using Android.App;
using Android.OS;
using Xamarin.Essentials;
using Android.Runtime;

namespace PrismSampleApp.Droid
{ 
    public class MainApplication : Application
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Platform.Init(this);

        }
    }
}
