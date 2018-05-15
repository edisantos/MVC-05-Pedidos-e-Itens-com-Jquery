using PedidosItens.Contexto;
using PedidosItens.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PedidosItens.Controllers
{
    public class ItensController : Controller
    {
        private DbContexto db = new DbContexto();
        public ActionResult ListarItens(int id)
        {
            var lista = db.Itens.Where(m => m.Pedido.Id == id);
            ViewBag.Pedido = id;
            return PartialView(lista);
        }
        public ActionResult SalvarItens(int quantidade
             , string produto
             , int valorunitario
             , int idPedido)
        {
            var iten = new Itens()
            {
                Quantidade = quantidade
                ,
                Produto = produto
                ,
                ValorUnitario = valorunitario
                ,
                Pedido = db.Pedidos.Find(idPedido),

            };

            db.Itens.Add(iten);
            db.SaveChanges();



            return Json(new { Resultado = iten.Id }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ExcluirItens(int id)
        {
            var result = false;
            var item = db.Itens.Find(id);
            if (item != null)
            {
                db.Itens.Remove(item);
                db.SaveChanges();
                result = true;
            }

            return Json(new { Resultado = result}, JsonRequestBehavior.AllowGet);
        }
    }
}