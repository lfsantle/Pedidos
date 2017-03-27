using System;
using Xamarin.Forms;
using MasterDetailPageNavigation.Models;
using System.Collections.Generic;

namespace MasterDetailPageNavigation
{
	public partial class PedidosCadPage : ContentPage
	{

		public PedidosCadPage()
		{
			InitializeComponent();
			NovoPedido();
			AtualizarDados();
		}

		public void AtualizarDados()
		{
			CLINOM.Text = PedidosClass._Clientes.CLINOM;
			ListProdutos.ItemsSource = PedidosClass._PedidoItem;
			Qtde.Text = PedidosClass._PedidoItem.Count.ToString();
			double subtotal = 0;
			foreach (PedidoItem item in PedidosClass._PedidoItem)
			{
				double valor;
				try
				{
					if (!string.IsNullOrEmpty(item.UNIT))
					{
						valor = Convert.ToDouble(item.UNIT.Replace('.',','));
						int qtde = Convert.ToInt32(item.QUANT);
						subtotal += valor * qtde;
					}
				}
				catch (Exception ex)
				{
					Device.BeginInvokeOnMainThread(() =>
					{
						DisplayAlert("Falha", ex.Message.ToString(), "Ok");
					});
				}


			}
			SubTOT.Text = "R$ " + subtotal.ToString();
		}

		public PedidosCadPage(Clientes CLISelecionado)
		{
			InitializeComponent();
			PedidosClass._Clientes = CLISelecionado;
			AtualizarDados();
		}

		public PedidosCadPage(string texto)
		{
			InitializeComponent();
			AtualizarDados();
		}


		public PedidosCadPage(Produtos PRODSelecionado)
		{
			InitializeComponent();
			//CLINOM.Text = PedidosClass._Clientes.CLINOM;
			/* CAMPOS:
			 * SEQ 
			 * CUPOM
			 * CODPRO
			 * DESCRICAO
			 * UNIT 
			 * QUANT 
			 * TOTAL 
			 * DETALHE
			*/
			string detalhe = "R$ " + PRODSelecionado.PRECO1 + " * 1 = R$ " + PRODSelecionado.PRECO1 ;
			PedidosClass._PedidoItem.Add(new PedidoItem
			{
				SEQ = "",
				CUPOM = "",
				CODPROD = PRODSelecionado.CODIGO,
				DESCRICAO = PRODSelecionado.DESCPRO,
				UNIT = PRODSelecionado.PRECO1,
				QUANT = "1",
				TOTAL = PRODSelecionado.PRECO1,
				DETALHE = detalhe
			});

			//ListProdutos.ItemsSource = PedidosClass._PedidoItem;
			AtualizarDados();
		}

		protected void NovoPedido()
		{
			PedidosClass._PedidoCabecalho = new Pedidos();
			PedidosClass._PedidoItem = new List<PedidoItem>();
			PedidosClass._FormaPagto = new FormaPagto();
			PedidosClass._Clientes = new Clientes();

		}

		protected async void ClickPedidoCadDet(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new PedidosCadDetPage());
		}

		protected async void BTEscolherCliente(object sender, EventArgs args)
		{
			if ( PedidosClass._Clientes.CLINOM != null )
			{
				PedidosClass._Clientes = new Clientes();
				CLINOM.Text = null;
			}
			await Navigation.PushAsync(new ClientesPage("pedidos"));
		}

		protected async void BTAdicionarProduto(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new ProdutosPage("pedidos"));
		}

		protected async void ProdutoEditar(object sender, EventArgs args)
		{
			await DisplayAlert("Editar", "Não implementado", "OK");
		}

		protected async void ProdutoExcluir(object sender, EventArgs args)
		{
			await DisplayAlert("Excluir", "Não implementado", "OK");
		}

		protected async void GravarPedido(object sender, EventArgs args)
		{
			await DisplayAlert("Gravar", "Não implementado", "OK");

		}
	}
}
