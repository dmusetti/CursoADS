function Alerta() {
   alert("Teste");
}


function carregaModelos() {
   var Tipo = $("#Tipo").val();
   if (Tipo != "") {
      $.ajax({
         dataType: "json",
         data: "{Tipo: '" + Tipo + "'}",
         type: "POST",
         contentType: "application/json; charset=utf-8",
         url: "/Buscas/GetModelos",
         success: function (dados) {
            $("#Modelos").empty();
            $(dados).each(function (i, o) {
               $("#Modelos").append("<option value=" + o.Descricao + ">" + o.Descricao + "</option>");
            });
         }
      });
   };
};



function SalvarPedido() {
   var idCliente = $("#idCliente").val();
   var nomeCliente = $("#nomeCliente").val();
   $.ajax({
      dataType: "json",
      data: "{Id: '" + idCliente + "', NomeCliente: '" + nomeCliente + "'}",
      type: "POST",
      contentType: "application/json; charset=utf-8",
      url: "/Pedido/SalvarPedido",
      success: function (dados) {
         $("#NPedido").empty();
         $(dados).each(function (i, o) {
            $("#ItensPedido").remove();
            $("#NPedido").val(o);
            str = "<div class='row'>";
            str += "<div class='col-5 fontGrid border'>Item 1</div>";
            str += "<div class='col-4 fontGrid border'>10.0</div>";
            str += "<div class='col-4 fontGrid border'>100.0</div>";
            str += "<div class='col-4 fontGrid border'>1000.0</div>";
             str += "</div>";
            $('#ItensPedido').append(str);



         });
      }
   });
};




function BuscarProduto() {
    var idProduto = $("#txtCodigoProduto").val();

    $.ajax({
        dataType: "json",
        data: "{Id: '" + idProduto + "'}",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/Buscas/BuscarProduto",
        success: function (dados) {
            $(dados).each(function (i, o) {
                if (dados != null) {
                    $("#txtDescricao").empty();
                    $("#txtVrUnitario").empty();
                    $("#txtVrTotal").empty();

                    $("#txtDescricao").val(o.Descricao);
                    $("#txtVrUnitario").val(o.VrUnitario);

                    var Qtde = $("#txtQtde").val();

                    var vrTotal = o.VrUnitario * Qtde;

                    $("#txtVrTotal").val(vrTotal);
                } else {
                    alert("Código inválido ou inexistente.");
                }
            });
        }
    });
};
