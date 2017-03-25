using System;
using Xamarin.Forms;

namespace MasterDetailPageNavigation
{
	public partial class PedidosCadPage : ContentPage
	{
		public PedidosCadPage()
		{
			InitializeComponent();
		}

		protected async void ClickPedidoCadDet(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new PedidosCadDetPage());
		}
	}
}
