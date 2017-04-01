using System;
using System.Collections.Generic;
using MasterDetailPageNavigation.Services;
using MasterDetailPageNavigation.Models;
using System.Net.Http;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace MasterDetailPageNavigation
{
	public partial class Login : ContentPage
	{

		protected CRUD_Service service = new CRUD_Service();
		public User usuario = new User();

		public Login()
		{
			InitializeComponent();


			if (UsuarioClass._UserLogado)
			{
				CarregarMasterPage();
			}

		}

		public async void CarregarMasterPage()
		{
			var MasterPage = new MainPage();
			await Navigation.PushModalAsync(MasterPage);
		}

		protected async void ExecLogin(object sender, EventArgs args)
		{
			BTAcesso.IsEnabled = false;
			BTAcesso.Text = "AGUARDE...";
			usuario.NOME = "";
			usuario.SENHA = "";

			// email e senha
			if (string.IsNullOrEmpty(EntryEmail.Text) && string.IsNullOrEmpty(EntryPass.Text))
			{
				await DisplayAlert("Atenção", "E-mail e senha são obrigatórios.", "OK");
			}
			// só email
			if (string.IsNullOrEmpty(EntryEmail.Text) && !string.IsNullOrEmpty(EntryPass.Text))
			{
				await DisplayAlert("Atenção", "E-mail é obrigatório.", "OK");
			}
			// só senha
			if (!string.IsNullOrEmpty(EntryEmail.Text) && string.IsNullOrEmpty(EntryPass.Text))
			{
				await DisplayAlert("Atenção", "Senha é obrigatória.", "OK");
			}
			// ambos ok
			if (!string.IsNullOrEmpty(EntryEmail.Text) && !string.IsNullOrEmpty(EntryPass.Text))
			{
				// salvar valores
				usuario.NOME = EntryEmail.Text;
				usuario.SENHA = EntryPass.Text;

				try
				{
					HttpResponseMessage resposta = await service.Login(usuario);

					if (resposta.IsSuccessStatusCode)
					{
						string json = resposta.Content.ReadAsStringAsync().Result.Trim();
						json = json.Replace("[", "").Replace("]", "");

						JsonRetorno retorno = JsonConvert.DeserializeObject<JsonRetorno>(json);
						string cod = retorno.codigo;
						string msg = retorno.msg;
						string nome = retorno.nome;

						if (!string.IsNullOrEmpty(msg) && msg == "OK") {
							UsuarioClass._UserLogado = true;
							UsuarioClass._VendedorLogado.COD = cod;
							UsuarioClass._VendedorLogado.NOME = nome;

							UsuarioClass._UserDataHora = (DateTime)System.DateTime.Now;
							CarregarMasterPage();
						} 
						else 
						{
							await DisplayAlert("Atenção", "Nome ou Senha inválido(s)!", "OK");
						}

					}
					else
					{
						await DisplayAlert("Erro no Login", "Erro no processamento.", "OK");
					}
					//await DisplayAlert("Retorno", , "OK");
					//await Navigation.PopAsync();
				}
				catch (Exception ex)
				{
					await DisplayAlert("Erro", ex.Message, "SAIR");

				}

			}
			BTAcesso.IsEnabled = true;
			BTAcesso.Text = "ACESSO";

			
			//var MasterPage = new MainPage();
			//await Navigation.PushModalAsync(MasterPage);


			//MasterPage = new NavigationPage(new MainPage());
			//await Navigation.PushAsync(new MainPage());
			//MainPage = new MasterDetailPageNavigation.MainPage();
			//NavigationPage nav = new NavigationPage(new MainPage());
		}

	}
}
