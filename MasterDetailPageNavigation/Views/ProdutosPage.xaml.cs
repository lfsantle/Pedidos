using MasterDetailPageNavigation.Services;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System;
using System.Linq;
using MasterDetailPageNavigation.Models;

namespace MasterDetailPageNavigation
{
	public partial class ProdutosPage : ContentPage
	{
		
		public List<Produtos> _listaProdutos;
		public string funcao;

		public ProdutosPage()
		{
			InitializeComponent();
			CarregarProdutos();
			this.Title = "Consulta Produtos";
		}

		public ProdutosPage(string retorno)
		{
			InitializeComponent();
			CarregarProdutos();
			funcao = retorno;
			this.Title = "Selecione um Produto";
		}

		private void CarregarProdutos()
		{
			ApiCall apiCall = new ApiCall();

			//Aqui buscamos os 10 com as maiores Notas e Iniciamos uma Thread
			apiCall.GetResponse<List<Produtos>>("Produtos.php").ContinueWith(t =>
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
						//ListProdutos.ItemsSource = t.Result;

						// joga os valores na  lista LOCAL
						_listaProdutos = new List<Produtos>();
						_listaProdutos = t.Result;

						// joga os valores na listview e chama a função pra ordenar e agroupar
						ListProdutos.ItemsSource = ListarProdutos();
						//ListProdutos.ItemsSource = t.Result;

					});

				}
			});

			ProdBusca.TextChanged += Busca_TextChanged;
		}

		private void Busca_TextChanged(object sender, TextChangedEventArgs e)
		{
			ListProdutos.ItemsSource = ListarProdutos(ProdBusca.Text);
		}

		public IEnumerable<Group<char, Produtos>> ListarProdutos(string filtro = "")
		{
			IEnumerable<Produtos> produtosFiltrados = _listaProdutos.Where(l => (l.DESCPRO.Trim().Length > 0));

			if (!string.IsNullOrEmpty(filtro))
			{
				produtosFiltrados = _listaProdutos.Where(l => (l.DESCPRO.ToLower().Contains(filtro.ToLower())));
			}

			return from ListProdutos in produtosFiltrados
				   orderby ListProdutos.DESCPRO
				   group ListProdutos by ListProdutos.DESCPRO[0] into grupos
				   select new Group<char, Produtos>(grupos.Key, grupos)
				;
		}

		private async void ProdutosClick(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
			//obtem o item selecionado
			var Produto = e.SelectedItem as Produtos;
			//deseleciona o item do listview
			ListProdutos.SelectedItem = null;

			if (string.IsNullOrEmpty(funcao))
			{

				//chama a pagina UsersDetailsPage
				//await Navigation.PushAsync(new ClientesDetalhesPage(Cliente));
				await DisplayAlert("Página Detalhe", "Aguardando implementação", "OK");
			}
			else
			{
				switch (funcao)
				{
					case "pedidos":
						await Navigation.PushAsync(new PedidoProdEditPage(Produto));
						break;
				}
			}
		}
	}
}
