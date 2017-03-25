using System;
namespace MasterDetailPageNavigation.Models
{
	public class Pedidos
	{
		public string SEQ		{ get; set; } //- sequencial
		public string DATA   	{ get; set; } //- data
		public string CODCLI 	{ get; set; } //– código cliente
		public string LIQUIDO 	{ get; set; } //– valor liquido
		public string CODVEN  	{ get; set; } //- código vendedor
		public string COMPRADO	{ get; set; } //- comprador
		public string CODFORM  	{ get; set; } //- código forma pgto

		public string PEDIDO 	{ get; set; } //- sequencial (select php)
		public string CLINOM 	{ get; set; } //- nome cliente (select php)
	}
}