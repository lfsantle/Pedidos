using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MasterDetailPageNavigation.Models;

namespace MasterDetailPageNavigation
{
	public partial class PedidoProdEditPage : ContentPage
	{
		public string PRECO1;

		public PedidoProdEditPage(Produtos PRODSelecionado)
		{
			InitializeComponent();
			this.Title = "Add Produto";

			Lbl_PRODDESC.Text = PRODSelecionado.DESCPRO;
			Lbl_UNIT.Text = "R$ " + PRODSelecionado.PRECO1.Replace('.', ',');
			PRECO1 = PRODSelecionado.PRECO1;
			Lbl_CodBarra.Text = PRODSelecionado.CODBAR;
			Lbl_CODPROD.Text = PRODSelecionado.CODIGO;
			Qtde.Text = "1";

			Qtde.TextChanged += Qtde_TextChanged;
		}

		private void Calcular()
		{
			double subtotal;
			try
			{
				double valor = Convert.ToDouble(Lbl_UNIT.Text.Replace('.', ','));
				int qtde = Convert.ToInt32(Qtde.Text);
				subtotal = valor * qtde;
				Subtotal.Text = "R$ " + subtotal.ToString();
			}
		}

		private void Qtde_TextChanged(object sender, TextChangedEventArgs e)
		{
			Calcular();
		}

		private async void GravarProduto(object sender, EventArgs e)
		{

			var answer = await DisplayAlert("Confirmação", "Deseja adicionar o produto?", "Sim", "Não");
			if (answer)
			{
				string detalhe = "R$ " + PRECO1 + " * " + Qtde.Text + " = " + Subtotal.Text;
				PedidosClass._PedidoItem.Add(new PedidoItem
				{
					SEQ = "",
					CUPOM = "",
					CODPROD = Lbl_CODPROD.Text,
					DESCRICAO = Lbl_PRODDESC.Text,
					UNIT = PRECO1,
					QUANT = Qtde.Text,
					TOTAL = Subtotal.Text.Replace("R$ ", "").Replace(',', '.'),
					DETALHE = detalhe
				});
				await Navigation.PushAsync(new PedidosCadPage());
			}

		}
	}
}
