using System;
namespace MasterDetailPageNavigation.Models
{
	public class Produtos
	{
		public string CODIGO 	{ get; set; } //- código 
		public string CODBAR 	{ get; set; } //- código barra
		public string DESCPRO 	{ get; set; } //- descrição
		public string PRECO1 	{ get; set; } //- descrição

		public static explicit operator string(Produtos v)
		{
			throw new NotImplementedException();
		}
	}
}
