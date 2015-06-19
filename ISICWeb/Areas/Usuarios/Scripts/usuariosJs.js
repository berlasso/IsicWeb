﻿$(function () {
    $('#tablaUsuarios').dataTable({
        "dom": '<"row"<"col-md-12"ipTf>><"clear">rt<"bottom"><"clear">',
        "tableTools": {
            "aButtons": [],

        },
        //"columns": [
        //         { "data": "nombreusuario" },
        //         { "data": "apellido" },
        //         { "data": "nombre" },
        //         { "data": "dependencia" },
        //         { "data": "descripcion" },
        //         { "data": "activo" },
        //         { "data": null },
        //],
        "columnDefs": [
            {
                "targets": 0,
                "sortable": false
            }
        ],
        "language": {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        }
    });
    $('#tablaUsuarios tbody').on('click', '#btnBorrarUsuario', function () {
        var id = $(this).data("id");
        var table = $('#tablaUsuarios').DataTable();
        var row = table.row($(this).parents('tr'));

        alertify.confirm("Borrar Usuario", "Seguro que desea borrar?", function () {

            var url = urlBorrarUsuario + encodeURI(id);
            $.get(url, null, function (data) {
                if (data === "True") {
                    row.remove().draw();
                    alertify.success("Usuario borrado correctamente");


                } else {
                    alertify.error("Error al borrar");
                }
            });

        }, null)
            .set('labels', { cancel: 'Cancelar' })
            .set('defaultFocus', 'cancel');
    });



    $("div.dataTables_filter>label>input").addClass("form-control"); //estilo correcto a filtro
    $("div.dataTables_length>label>select").addClass("form-control"); //estilo correcto a cant de filas
    //$(".DTTT_container >a").each($).removeClass().addClass("btn btn-sm"); //agrego estilo correcto a botones de tabla
    //$("#table_filter").addClass("tile");

});

$(function () {


    $('#NombreUsuario').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnBuscarUsuarioMPBA").click();
        }
    });

    $("#btnBuscarUsuarioMPBA").click(function () {
        if ($("#NombreUsuario").valid() == true) {
            var nombreusuario = $("#NombreUsuario").val();
            var url = urlBuscarUsuario + nombreusuario + '&r=' + new Date().getTime();
            $("#divUsuarioMPBAEncontrado").empty();
            $("#divUsuarioMPBAEncontrado").hide();
            $.ajax({
                url: url,
                success: function (data) {
                    var json = data;
                    if (data.HuboError == true) {
                        alertify.alert("Error", data.ErrorMessage);
                    } else {
                        //if (data.DatosSimp.length == 0 || data.DatosSimp[0].Imputados.length == 0) {
                        //    alertify.alert("No hubo resultados");
                        //    return;
                        //}
                        var apellido = data.Apellido;
                        var nombre = data.Nombre;
                        $("#divUsuarioMPBAEncontrado").append("Usuario MPBA:");

                        $("#divUsuarioMPBAEncontrado").append('<ul><a id="usuarioMPBA" href="#" onclick="LlenarControlesSimp(usuarioMPBA)" data-apellido="' + data.Apellido + '" data-nombre="' + data.Nombre + '">' + data.Apellido + ', ' + data.Nombre + '</a></ul>').show();
                    }

                },
                beforeSend: function () {
                    //loader("Buscando datos de la IPP...");
                    $("#NombreUsuario").addClass("loadinggif");
                },
                complete: function () {
                    //$.unblockUI();    
                    $("#NombreUsuario").removeClass("loadinggif");
                },
                dataType: "json"
            });

        } else {
            $("#NombreUsuario").data("validator");
        }
    });
});
