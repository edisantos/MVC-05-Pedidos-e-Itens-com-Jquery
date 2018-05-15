$(document).ready(function () {
    debugger;
    var url = window.location.pathname;
    if (url.indexOf("Edit") > 0) {
        var id = $("#Id").val();
        ListarItens(id);
    }
});

function SalvarPedido() {
    //debugger;
    //Data
    var data = $("#Data").val();

    //Cliente

    var cliente = $("#Cliente").val();

    //Valor

    var valor = $("#Valor").val();

    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedidos/Create"] input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = tokenadr;

    //Gravar

    var url = "/Pedidos/Create";

    $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        headers: headersadr,
        data: { id: 0, Data: data, Cliente: cliente, Valor: valor, __RequestVerificationToken: token },
        success: function (data) {
            if(data.Resultado > 0)
            {
                //debugger;
               ListarItens(data.Resultado);
            }
        }


    });

}

//Função listar itens

function ListarItens(idPedido) {
    var url = "/Itens/ListarItens";
    $.ajax({
        url: url,
        type: "GET",
        data: { id: idPedido },
        datatype: "html",
        success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
        
    });
}

//Salvar Itens

function SalvarItens() {
    //debugger;
    var quantidade = $("#Quantidade").val();
    var produto = $("#Produto").val();
    var valorunitario = $("#ValorUnitario").val();
    var idPedido = $("#idPedido").val();

    var url = "/Itens/SalvarItens";
    $.ajax({
        url: url,
        data: { Quantidade: quantidade, Produto: produto, ValorUnitario: valorunitario, idPedido: idPedido },
        type: "GET",
        datatype: "json",
        success: function (data) {
            if (data.Resultado > 0) {
               //debugger;
                ListarItens(idPedido);
            }
        }

    });
}

function ExcluirItens(id) {
    var url = "/Itens/ExcluirItens";
    $.ajax({
        url: url
        , data: { id: id }
        , datatype: "json"
        , type: "POST"
        , success : function(data)
        {
            if (data.Resultado) {
                var linha = "#tr" + id;
                $(linha).fadeOut(500);
            }
        }


    });
}

function EditarItem(id)
{

}