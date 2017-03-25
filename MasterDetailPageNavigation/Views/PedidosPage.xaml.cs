using MasterDetailPageNavigation.Services;
using MasterDetailPageNavigation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System.Linq;

namespace MasterDetailPageNavigation
{
	public partial class PedidosPage : ContentPage
	{
		public List<Pedidos> _listaPedidos;

		public PedidosPage()
		{
			InitializeComponent();

			ApiCall apiCall = new ApiCall();

			//Aqui buscamos os 10 com as maiores Notas e Iniciamos uma Thread
			apiCall.GetResponse<List<Pedidos>>("Pedidos.php").ContinueWith(t =>
			{
				//O ContinueWith é responsavel por fazer algo após o request finalizar

				//Aqui verificamos se houve problema ne requisição
				if (t.IsFaulted)
				{
					Debug.WriteLine(t.Exception.Message);
					Device.BeginInvokeOnMainThread(() =>
					{
						DisplayAlert("Falha", "Ocorreu um erro na Requisição", "Ok");
					});
				}
				//Aqui verificamos se a requisição foi cancelada por algum Motivo
				else if (t.IsCanceled)
				{
					Debug.WriteLine("Requisição cancelada");
					Device.BeginInvokeOnMainThread(() =>
					{
						DisplayAlert("Cancela", "Requisição Cancelada", "Ok");
					});
				}
				//Caso a requisição ocorra sem problemas, cairemos aqui
				else
				{
					//Se Chegarmos aqui, está tudo ok, agora itemos tratar nossa Lista
					//Aqui Usaremos a Thread Principal, ou seja, a que possui as references da UI
					Device.BeginInvokeOnMainThread(() =>
					{
						// jogava valores online
						//ListPedidos.ItemsSource = t.Result;

						// joga os valores na  lista LOCAL
						_listaPedidos = new List<Pedidos>();
						_listaPedidos = t.Result;
						// joga os valores na listview e chama a função pra ordenar e agroupar
						ListPedidos.ItemsSource = ListarPedidos();
					});



				}
			});
			BuscarPedido.TextChanged += Busca_TextChanged;
		}

		private void Busca_TextChanged(object sender, TextChangedEventArgs e)
		{
			ListPedidos.ItemsSource = ListarPedidos(BuscarPedido.Text);
		}

		public IEnumerable<Group<char, Pedidos>> ListarPedidos(string filtro = "")
		{
			IEnumerable<Pedidos> pedidosFiltrados = _listaPedidos;

			if (!string.IsNullOrEmpty(filtro))
			{
				pedidosFiltrados = _listaPedidos.Where(l => (l.CLINOM.ToLower().Contains(filtro.ToLower()) || l.PEDIDO.ToLower().Contains(filtro.ToLower())));
			}

			return from ListPedidos in pedidosFiltrados
				   orderby ListPedidos.CLINOM
				   group ListPedidos by ListPedidos.CLINOM[0] into grupos
				   select new Group<char, Pedidos>(grupos.Key, grupos);
		}

		protected async void AddPedido(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new PedidosCadPage());
		}

		protected async void PedidosClick(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{

				return;
			}
			//obtem o item selecionado
			var Pedido = e.SelectedItem as Pedidos;
			//deseleciona o item do listview
			ListPedidos.SelectedItem = null;
			//chama a pagina UsersDetailsPage
			await Navigation.PushAsync(new PedidosDetalhesPage(Pedido));
		}

	}
}