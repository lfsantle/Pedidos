
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;

using MasterDetailPageNavigation.Models;

namespace MasterDetailPageNavigation
{
	public class CRUD_Service
	{

		private HttpClient _httpClient;


		public CRUD_Service()
		{
			_httpClient = new HttpClient();
		}

		public async Task<HttpResponseMessage> AdicionarCliente(Clientes cliente)
		{
			string url_REST = "http://www.lfsant.com.br/PedidosTOL/Clientes.php";
			var json = JsonConvert.SerializeObject(cliente);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			/*
			var buffer = System.Text.Encoding.UTF8.GetBytes(conteudo);
			var byteConteudo = new ByteArrayContent(buffer);

			byteConteudo.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			Task<HttpResponseMessage> retorno = _client.PostAsync(url_REST, byteConteudo);

			return retorno.Result;
			*/

			var responseMessage = await _httpClient	.PostAsync(url_REST, content);
			return responseMessage;
		}

		public async Task<HttpResponseMessage> Login(User logarusuario)
		{
			string url_REST = "http://www.lfsant.com.br/PedidosTOL/Acesso.php";
			var json = JsonConvert.SerializeObject(logarusuario);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			/*
			var buffer = System.Text.Encoding.UTF8.GetBytes(conteudo);
			var byteConteudo = new ByteArrayContent(buffer);

			byteConteudo.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			Task<HttpResponseMessage> retorno = _client.PostAsync(url_REST, byteConteudo);

			return retorno.Result;
			*/

			var responseMessage = await _httpClient.PostAsync(url_REST, content);
			return responseMessage;
		}
	}
}
