
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;

namespace MasterDetailPageNavigation
{
	public class CRUD_Service
	{

		private HttpClient _client;
		private string url_REST = "http://www.lfsant.com.br/PedidosTOL/Clientes.php";

		public CRUD_Service()
		{
			_client = new HttpClient();
		}

		public async Task<HttpResponseMessage> AdicionarCliente(Clientes cliente)
		{
			var json = JsonConvert.SerializeObject(cliente);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			/*
			var buffer = System.Text.Encoding.UTF8.GetBytes(conteudo);
			var byteConteudo = new ByteArrayContent(buffer);

			byteConteudo.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			Task<HttpResponseMessage> retorno = _client.PostAsync(url_REST, byteConteudo);

			return retorno.Result;
			*/

			var responseMessage = await _client.PostAsync(url_REST, content);
			return responseMessage;
		}


	}
}
