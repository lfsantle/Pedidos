using System;
namespace MasterDetailPageNavigation.Models
{
	public class PedidoItem
	{
		public string SEQ 		{ get; set; } //- sequencial 
		public string CUPOM 	{ get; set; } //- Tslor01.seq
		public string CODPROD 	{ get; set; } //- código produto
		public string DESCRICAO { get; set; } //- descrição produto
		public string UNIT 		{ get; set; } //- valor unitario
		public string QUANT 	{ get; set; } //- quantidade
		public string TOTAL 	{ get; set; } //- total
		public string DETALHE 	{ get; set; } //- descricao UNI, QTDE e Total pro binding
		public string DETALHE2	{ get; set; } //- descricao UNI, QTDE e Total pro binding

	}
}
