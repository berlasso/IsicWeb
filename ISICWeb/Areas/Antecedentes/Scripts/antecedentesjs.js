function onBuscarBegin() {
    loader('Buscando...');
}

function onBuscarComplete() {
    $.unblockUI();
}

$(function() {
    $("#CodBarras").mask("999999999999a");
    //$("#causaspendientes").mask("9", { placeholder: "" });
    $("#Clase").mask("9999", { placeholder: "" });
});

