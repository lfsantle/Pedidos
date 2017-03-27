using System.Collections.Generic;
using Xamarin.Forms;

namespace MasterDetailPageNavigation
{
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public MasterPage()
		{
			InitializeComponent();

			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Pedidos",
				IconSource = "pedidos.png",
				TargetType = typeof(PedidosPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Clientes",
				IconSource = "clientes.png",
				TargetType = typeof(ClientesPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Produtos",
				IconSource = "pedidos.png",
				TargetType = typeof(ProdutosPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Sobre nós",
				IconSource = "sobre.png",
				TargetType = typeof(SobreNosPage)
			});


			listView.ItemsSource = masterPageItems;
		}
	}
}
