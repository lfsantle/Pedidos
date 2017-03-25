using MasterDetailPageNavigation.Services;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System;
using System.Linq;

namespace MasterDetailPageNavigation
{
	public partial class ClientesPage : ContentPage
	{
		public List<Clientes> _listaClientes;
		public ClientesPage()
		{
			InitializeComponent();


			ApiCall apiCall = new ApiCall();

			//Aqui buscamos os 10 com as maiores Notas e Iniciamos uma Thread
			apiCall.GetResponse<List<Clientes>>("Clientes.php").ContinueWith(t =>
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
						// joga os valores direto na Lista
						//ListClientes.ItemsSource = t.Result;

						// joga os valores na  lista LOCAL
						_listaClientes = new List<Clientes>();
						_listaClientes = t.Result;
						// joga os valores na listview e chama a função pra ordenar e agroupar
						ListClientes.ItemsSource = ListarClientes();
					});

				}
			});

			CliBusca.TextChanged += Busca_TextChanged;
		}

		private void Busca_TextChanged(object sender, TextChangedEventArgs e)
		{
			ListClientes.ItemsSource = ListarClientes(CliBusca.Text);
		}

		public IEnumerable<Group<char, Clientes>> ListarClientes(string filtro = "")
		{
			IEnumerable<Clientes> clientesFiltrados = _listaClientes;

			if (!string.IsNullOrEmpty(filtro))
			{
				clientesFiltrados = _listaClientes.Where(l => (l.CLINOM.ToLower().Contains(filtro.ToLower())));
			}

			return from ListClientes in clientesFiltrados
				   orderby ListClientes.CLINOM
				   group ListClientes by ListClientes.CLINOM[0] into grupos
				   select new Group<char, Clientes>(grupos.Key, grupos);
		}

		protected async void AddCliente(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new ClientesCadPage());
		}

		/*
		protected async void ClientesClick(object sender, EventArgs args)
		{

			await Navigation.PushAsync(new ClientesDetalhesPage());
		}
		*/

		private async void ClientesClick(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				
				return;
			}
			//obtem o item selecionado
			var Cliente = e.SelectedItem as Clientes;
			//deseleciona o item do listview
			ListClientes.SelectedItem = null;
			//chama a pagina UsersDetailsPage
			await Navigation.PushAsync(new ClientesDetalhesPage(Cliente));
		}


	}
}