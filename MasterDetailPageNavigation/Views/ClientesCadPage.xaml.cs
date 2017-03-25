using System;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MasterDetailPageNavigation
{
	public partial class ClientesCadPage : ContentPage
	{
		public ClientesCadPage()
		{
			InitializeComponent();
		}

		private async void GravarCliente(object sender, EventArgs e)
		{
			var Estado 	= CLIEST.SelectedIndex;
			string StrEstado;

			if (Estado < 0) {
				StrEstado = "SP"; 
			} else {
				StrEstado = CLIEST.Items[CLIEST.SelectedIndex].ToString();
			}

			var Tipo 	= PESSOA.SelectedIndex;
			string StrTipo;

			if (Tipo < 0) {
				StrTipo = "FISICA";
			} else { 
				StrTipo = PESSOA.Items[PESSOA.SelectedIndex].ToString();
			}

			CRUD_Service service = new CRUD_Service();
			Clientes novoCliente = new Clientes()
			{

				CLINOM = CLINOM.Text,
				CLIEND = CLIEND.Text,
				CLIBAI = CLIBAI.Text,
				CLICID = CLICID.Text,
				CLIEST = StrEstado,
				CLICEP = CLICEP.Text,
				PESSOA = StrTipo,
				CLICGC = CLICGC.Text,
				CLIINS = CLIINS.Text,
				CLICPF = CLICPF.Text,
				CLIRG = CLIRG.Text,
				CLITEL = CLITEL.Text,
				CLIFAX = CLIFAX.Text,
				CLICON = CLICON.Text

			};

			try
			{
				HttpResponseMessage resposta = await service.AdicionarCliente(novoCliente);
				if (resposta.IsSuccessStatusCode)
				{
					// var retorno = JsonConvert.DeserializeObject(resposta.Content.ReadAsStringAsync().Result);
					await DisplayAlert("Confirmação:", "Cliente cadastrado com sucesso!", "OK");
					var detailPage = new MainPage();
					await Navigation.PushModalAsync(detailPage);
				}
				else
				{
					await DisplayAlert("Erro no Cadastro", "Cadastro não efetuado!", "OK");
				}
				//await DisplayAlert("Retorno", , "OK");
				//await Navigation.PopAsync();
			}
			catch (Exception ex)
			{
				await DisplayAlert("Erro", ex.Message, "SAIR");

			}
		}
	}
}
