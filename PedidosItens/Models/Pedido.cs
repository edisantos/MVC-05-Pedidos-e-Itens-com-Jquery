using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PedidosItens.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }
        public Decimal Valor { get; set; }
    }
}