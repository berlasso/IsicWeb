

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
