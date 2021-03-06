﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MasterDetailPageNavigation.Models;

namespace MasterDetailPageNavigation
{
	public partial class PedidoProdEditPage : ContentPage
	{
		public string PRECO1;
		public int qtde = 0;
		double subtotal = 0;
		double valor = 0;

		public PedidoProdEditPage(Produtos PRODSelecionado)
		{
			InitializeComponent();
			this.Title = "Adicionar Produto";

			valor = Convert.ToDouble(PRODSelecionado.PRECO1);
			Lbl_PRODDESC.Text = PRODSelecionado.DESCPRO;
			Lbl_UNIT.Text = "R$ " + PRODSelecionado.PRECO1.Replace('.', ',');
			PRECO1 = PRODSelecionado.PRECO1;
			Lbl_CodBarra.Text = PRODSelecionado.CODBAR;
			Lbl_CODPROD.Text = PRODSelecionado.CODIGO;
			//Qtde.Text = "1";
			Calcular();
			Qtde.TextChanged += Qtde_TextChanged;
		}


		private void Calcular()
		{

			if (!string.IsNullOrEmpty(Qtde.Text))
			{
				try
				{
					qtde = Convert.ToInt32(Qtde.Text);
				}
				catch (Exception ex)
				{
					DisplayAlert("Erro ao Calcular Qtde", ex.Message, "OK");
				}

				subtotal = valor * qtde;
				Subtotal.Text = "R$ " + subtotal.ToString();
				Qtde.Text = qtde.ToString();
			}
			else
			{
				subtotal = 0;
				Subtotal.Text = "";
			}
		}

		private void Qtde_TextChanged(object sender, TextChangedEventArgs e)
		{
			Calcular();
		}

		private async void GravarProduto(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty( Qtde.Text )) 
			{
				await DisplayAlert("Atenção", "Insira a quantidade desejada!", "OK");
			}
			else
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
					await Navigation.PushAsync(new PedidosCadPage("adicionado"));
				}
			}

		}
	}
}
