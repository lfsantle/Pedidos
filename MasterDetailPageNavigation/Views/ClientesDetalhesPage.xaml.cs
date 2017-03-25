using MasterDetailPageNavigation.Services;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using System;

namespace MasterDetailPageNavigation
{
	public partial class ClientesDetalhesPage : ContentPage
	{

		public ClientesDetalhesPage(Clientes cliente)
		{
			InitializeComponent();

			Lbl_CLINOM.Text = cliente.CLINOM;

			Lbl_PESSOA.Text = cliente.PESSOA;
			Lbl_CLICGC.Text = cliente.CLICGC;
			Lbl_CLIINS.Text = cliente.CLIINS;
			Lbl_CLICON.Text = cliente.CLICON;
			Lbl_CLICPF.Text = cliente.CLICPF;
			Lbl_CLIRG.Text = cliente.CLIRG;

			Lbl_CLIEND.Text = cliente.CLIEND;
			Lbl_CLIBAI.Text = cliente.CLIBAI;
			Lbl_CLICID.Text = cliente.CLICID;
			Lbl_CLIEST.Text = cliente.CLIEST;
			Lbl_CLICEP.Text = cliente.CLICEP;

			Lbl_CLITEL.Text = cliente.CLITEL;
			Lbl_CLIFAX.Text = cliente.CLIFAX;

			/*
			ApiCall apiCall = new ApiCall();

			//Aqui buscamos os 10 com as maiores Notas e Iniciamos uma Thread
			apiCall.GetResponse<List<Clientes>>("Clientes.php?c="+cliente.CLICOD).ContinueWith(t =>
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
						BindingContext = t.Result;
					});
				}
			});
			*/
		}

	}
}