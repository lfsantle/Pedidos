using System;
using Android.App;
using Android.Support.V7.App;

namespace MasterDetailPageNavigation.Droid
{

	[Activity(Label = "PedidosTOL", Icon = "@drawable/icon", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]

	public class SplashActivity : AppCompatActivity
	{
		protected override void OnResume()
		{
			base.OnResume();
			StartActivity(typeof(MainActivity));
		}

	}
}
