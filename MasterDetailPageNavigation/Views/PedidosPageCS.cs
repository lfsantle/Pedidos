using Xamarin.Forms;

namespace MasterDetailPageNavigation
{
	public class PedidosPageCS : ContentPage
	{
		public PedidosPageCS()
		{
			Title = "Pedidos";
			Content = new StackLayout
			{
				Children = {
					new Label {
						Text = "Pedidos",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}
