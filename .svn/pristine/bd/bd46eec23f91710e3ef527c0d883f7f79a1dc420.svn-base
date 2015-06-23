function CartelCarga(container) {
    container.append('<div id="divLoading" class="body-content-loading-overlay" style="display: block;"><div class="body-content-loading-spinner"></div></div>');


}

function LlenarControlesSimp(control) {
    $("#Apellido").val(control.dataset.apellido).css("color", "rgb(17, 17, 139)");
    $("#Nombres").val(control.dataset.nombre).css("color", "rgb(17, 17, 139)");
    //$("#DependenciaPolicial").val(control.dataset.comisaria).css("color", "rgb(17, 17, 139)");
    //$("#JuzgadoGarantias").val(control.dataset.juzgar).css("color", "rgb(17, 17, 139)");
    $("#FechaDelito").val(control.dataset.fechadelito).css("color", "rgb(17, 17, 139)");
    $("UFI").val(control.dataset.ufi).css("color", "rgb(17, 17, 139)");
    $("#Fiscal").val(control.dataset.titularufi).css("color", "rgb(17, 17, 139)");
    $("#Sexo").val(control.dataset.sexo).css("color", "rgb(17, 17, 139)");
    $("#Padre").val(control.dataset.padre).css("color", "rgb(17, 17, 139)");
    $("#Madre").val(control.dataset.madre).css("color", "rgb(17, 17, 139)");
    $("#Apodos").val(control.dataset.apodo).css("color", "rgb(17, 17, 139)");
    $("#FechaNacimiento").val(control.dataset.fechanacimiento).css("color", "rgb(17, 17, 139)");
    $("#Delito").val(control.dataset.delito).css("color", "rgb(17, 17, 139)");
    $("#EstadoCivil").val(control.dataset.estadocivil).css("color", "rgb(17, 17, 139)");

}




$(function () {


    $('.tabla').dataTable({
        //"dom": 'TRfrtsp<"row"<"col-md-12"l>>i',
        "dom": '<"row "<"col-md-5"TR><"col-md-1"r><"col-md-6"f>>ts<"row tile"<"col-md-4"l><"col-md-4"i><"col-md-4"p>>',
        serverSide: true,
        "processing": true,
        "ajax": window.urlTablaImputados,
        "order": [[2, "asc"]],//codbarras
        "columns": [
                    { "data": null },
                    { "data": "ThumbUrl" },
                    { "data": "CodigoDeBarras" },
                    { "data": "Apellido" },
                    { "data": "Nombre" },
                    { "data": "DocumentoNumero" },


                      {
                          "data": null,
                          "defaultContent": "<button class='btn-alt btn-xs' style='font-size: 20px!important' title='Borrar' id='btnborrarimputado' ><span  class='flaticon-waste2' ></span></button>"+
                           "<button class='btn-alt btn-xs ' style='font-size: 20px!important'  title='Enviar al SIC'   id='btnEnviarImputado'><span  class='flaticon-arrow430' ></span></button>"
                              
                        },
                    {
                        "data": "Id",
                        "visible": false
                    }
       

        ],
        "columnDefs": [
          {
              "render": function (data, type, row) {
                  return '<a href="' + urlEditar + '/' + row.Id + '" class="btn  btn-alt" title="Editar" onclick=" showPageLoadingSpinner()  ">Editar</a>';
              },
              "targets": 0, //boton editar

          },
        {
            "render": function (data, type, row) {
                if (data !== "" && data != null)

                    return '<img src=' + data + '?r=' + Math.random() + ' style="max-width: 100px"  class="thumb" />';
                else
                    return '';

            },
            "orderable": false,

            "targets": 1, //ThumbUrl

        },


       {
           "orderable": false,//columna Borrar/Enviar
           "targets": 6,

       },
       //{
       //    "orderable": false,//columna Enviar
       //    "targets": 7,
       //    "searchable": false
       //},
       {
           "targets": 7,//id
           "visible": false,
           "searchable": false
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
        },
        "tableTools": {
            "sSwfPath": "/Content/swf/copy_csv_xls_pdf.swf",
            "aButtons": [
                {
                    "sExtends": "copy",
                    "oSelectorOpts": { filter: 'applied', order: 'current' },
                    "mColumns": "visible",
                    "sButtonText": "Copiar"
                },
                {
                    "sExtends": "xls",
                    "oSelectorOpts": { filter: 'applied', order: 'current' },
                    "mColumns": "visible",

                },
                {
                    "sExtends": "pdf",
                    "oSelectorOpts": { filter: 'applied', order: 'current' },
                    "mColumns": "visible",
                    "sPdfOrientation": "landscape"
                },
                {
                    "sExtends": "print",
                    "sButtonText": "Imprimir",
                    "sInfo": "<h2 style='color: white;'>Vista de Impresión</h2><p>Utilice la funcion de impresion del navegador para imprimir la tabla. Presione ESCAPE cuando haya terminado</p>"
                }
            ]
        }

    });

    //$('.tabla').on('processing.dt', function (e, settings, processing) {
    //    if (processing) {

    //        showPageLoadingSpinner();
    //    } else {
    //        hidePageLoadingSpinner(1);
    //    }
    //}).dataTable();
    $('.tabla tbody').on('click', '#btnborrarimputado', function (e) {
        e.preventDefault();
        //var row = $(this).parents('tr');
        //var data = $('.tabla').DataTable().row(row).data();



        //var id = $(this).data("id");
        var table = $('.tabla').DataTable();
        var row = table.row($(this).parents('tr'));
        var id = row.data().Id
        alertify.confirm("Borrar Imputado", "Seguro que desea borrar?", function () {

            var url = urlBorrarImputado + encodeURI(id);
            $.get(url, null, function (data) {
                if (data === "True") {

                    //row.remove();
                    row.remove().draw();
                    alertify.success("Imputado borrado correctamente");


                } else {
                    alertify.error("Error al borrar");
                }
            });

        }, null)
     .set('labels', { cancel: 'Cancelar' })
     .set('defaultFocus', 'cancel');
    });
    $('.tabla tbody').on('click', '#btnEnviarImputado', function () {
        var row = $(this).parents('tr');
        var data = $('.tabla').DataTable().row(row).data();
        var url = urlEnviarImputado + encodeURI(data.Id);
        if ($('#chkEnviar').is(':checked')) {
            $.get(url, null, function (data) {
                if (data === "True") {

                    row.remove();
                    alertify.success("Delito Enviado");


                } else {
                    alertify.error("Error al enviar");
                }
            });
        } else {
            alertify.warning("Debe tildar ENVIAR");
        }
    });
});

$(function () {
    $('[data-toggle="popover"]').popover();
});



$(document).ready(function () {

    $('#btnGenerarCodBarras').click(function () {
        $.ajax({
            type: 'GET',
            url: urlBuscarCodBarrasAutogenerado,
            //dataType: 'JSON',
            async: true,
            beforeSend: function () {
                $("#CodBarras").addClass("loadinggif");
            },
            success: function (data) {
                if (data.length == 13) {
                    letra = LetraCodBarra(data);
                    $("#CodBarras").val(data.substring(0, 12) + letra);
                }
            },
            complete: function () {
                $("#CodBarras").removeClass("loadinggif");
            }
        });
    });

    //ControlarComisaria();
    $('#FechaDelito').bind('keyup keypress blur change cut copy paste ', function () {
        var validator = $("#frmDetalleOtip").validate();
        validator.element(this);
        validator.element($("#FechaNacimiento"));

    });

});




$(document).ready(function () {
    $('#FechaNacimiento').bind('keyup keypress blur change cut copy paste ', function () {
        var validator = $("#frmDetalleOtip").validate();
        validator.element(this);
        validator.element($("#FechaDelito"));

    });
});


var LetraCorrecta = "";
(function ($) {
    if ($.validator && $.validator.unobtrusive) {


        $.validator.unobtrusive.adapters.addBool("letracodbarras", "letracodbarras");
        $.validator.addMethod("letracodbarras", function (value, element, params) {
            if (value && value.length == 13) {
                letra = LetraCodBarra(value);
                if (letra != "" && letra.toUpperCase() != value.substr(12, 1).toUpperCase()) {
                    LetraCorrecta = letra;
                    return false;
                }
            }
            return true;
        }, function (params, element) { return "Código incorrecto. La letra debería ser " + LetraCorrecta });

        $.validator.unobtrusive.adapters.addBool("codexistente", "codexistente");
        var resultado = false;
        $.validator.addMethod("codexistente", function (value, element, params) {
            if (!element.readOnly && value && value.length == 13) {
                var cb = $('#CodBarras').val();
                var result = $.ajax({
                    dataType: 'text',
                    url: urlBuscarCodBarras + cb,
                    async: false,
                    beforeSend: function () {
                        $("#CodBarras").addClass("loadinggif");
                    },
                    complete: function () {
                        $("#CodBarras").removeClass("loadinggif");
                    }
                });
            }

            if (result != null && result.responseText == "True") return false; else return true;

        }, "");


    }
})(jQuery);


function LetraCodBarra(cb) {
    var Codigo = "";
    var i, j;
    var letra = "";
    var expo = [0, 1, 2, 4, 8];
    if (cb.length != 13)
        return "";
    else
        Codigo = cb.substring(0, 12);

    if (isNaN(Codigo))
        return "";
    var Suma = 0;
    for (i = 1; i <= 3; i++) {
        for (j = 1; j <= 4; j++) {
            Suma += (parseInt((Codigo.substr((i - 1) * 4 + j - 1, 1))) + 48) * expo[j];
        }
    }
    letra = "ABCDEFGHIJKMNPRSTUVWXYZ".substr(((Suma % 23)), 1);
    letra = letra.toUpperCase();
    return letra;
}


function BuscarCodigoBarras(cb) {


    $.ajax({
        type: 'GET',
        url: urlBuscarCodBarras + cb,
        //dataType: 'JSON',
        async: true,
        beforeSend: function () {
            $("#CodBarras").addClass("loadinggif");
        },
        success: function (data) {
            if (data == "True") {
                //alertify.alert("Existente");
                var error = "Código de Barras existente";
                $("#CodBarras").addClass("input-validation-error");
                $("#codBarrasExistenteError").empty().html(error).show();
            }

        },
        complete: function () {
            $("#CodBarras").removeClass("loadinggif");
        }
    });

}

function GenerarReporte(id, sinHuellas) {

    $.ajax({
        type: 'GET',
        url: urlGenerarReporte + id + '&SinHuellas=' + sinHuellas,
        beforeSend: function () {
            showPageLoadingSpinner();
        },
        success: function (result) {
            $('#ajaxLoaderDiv').hide();
            //$('#btnVolverDetalle').attr("onclick", "window.history.go(-2);return false;");
            window.location = urlBajarReporte + result;

        }
    });
};




function BuscarIdImputado(cb) {
    var id = 0;
    $.ajax({
        type: 'GET',
        url: urlBuscarIdImputado + cb,
        //dataType: 'JSON',
        async: false,

        success: function (data) {
            if (data != null) {
                //alertify.alert("Existente");

                id = data;

            }

        }

    });
    return id;
}

function ControlarComisaria() {
    var select = $("#DependenciaPolicial").selectize();
    if (typeof (select[0]) == "undefined") return;
    var selectize = select[0].selectize;
    var dep = $('#elegidoLocalidadPolicial').data('localidad');
    var dp = "";
    if (dep == null || dep === "undefined" || dep === "Indeterminada") {
        selectize.clear();
        selectize.clearOptions();
        selectize.disable();
    } else {
        dp = "(" + dep + ")";
        selectize.enable();
        // selectize.clear();
        // selectize.clearOptions();

        selectize.load(function (callback) {
            $.ajax({
                type: 'GET',
                url: urlAutocompleteDependenciaPolicial + "&loc=" + $('#hidIdLocalidadPolicial').val(),
                success: function (results) {
                    if (results.dpEncontrados.length > 0) {
                        selectize.enable();
                        callback(results.dpEncontrados);
                    }
                    else
                        selectize.disable();
                },
                error: function () {
                    callback();
                }
            });
        });

    }
    $("#lblDependenciaPolicial").html("Dependencia Policial" + dp);
}


$(document).ready(function () {

    $("#IPP").mask("99-99-999999-99");
    var subcb = '9999';
    if (!$('#CodBarras').attr('readonly'))
        subcb = $('#hidSubCodBarra').val();
    $('#CodBarras').mask("01" + subcb + "999999a");
    $('#txtBuscarCodBarras').mask("999999999999a");


    $('#txtBuscarCodBarras').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnBuscarCodBarrasMenu").click();
        }
    });


    $('#IPP').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $("#btnBuscarIpp").click();
        }
    });

});

$("#btnBuscarCodBarrasMenu").bind("click", function () {
    var cb = $("#txtBuscarCodBarras").val();
    if (cb === "") return;
    showPageLoadingSpinner();
    var id = BuscarIdImputado(cb);

    if (id <= 0) {
        hidePageLoadingSpinner(0);
        alertify.alert("Error", "Código de Barras inexistente");
        return;
    }
    var url = urlAltaModificacion + id;
    window.open(url, '_self', false);

});

$(function () {


    $("#btnBuscarIpp").click(function () {
        if ($("#IPP").valid() == true) {
            var ipp = $("#IPP").val();
            var url = urlBuscarIppSimp + ipp + '&r=' + new Date().getTime();
            $("#divIppEncontrado").empty();
            $("#divIppEncontrado").hide();
            $.ajax({
                url: url,
                success: function (data) {
                    var json = data;
                    if (data.HuboError == true) {
                        alertify.alert("Error", data.errorMessage);
                    } else {
                        if (data.DatosSimp.length == 0 || data.DatosSimp[0].Imputados.length == 0) {
                            alertify.alert("No hubo resultados");
                            return;
                        }
                        var delito = data.DatosSimp[0].Delitos[0];
                        for (var i = 0; i < data.DatosSimp[0].Imputados.length; i++) {
                            var imputado = data.DatosSimp[0].Imputados[i];
                            if (imputado.ClaseVinculoPersona !== "Imputado")
                                continue;
                            var sexo = 0;
                            if (imputado.Sexo == "M")
                                sexo = 1;
                            else if (imputado.Sexo == "F")
                                sexo = 2;
                            var estcivil = 0;
                            if (imputado.EstadoCivil != null)
                                estcivil = imputado.EstadoCivil;
                            if (imputado.Madre === null)
                                imputado.Madre = "";
                            if (imputado.Padre === null)
                                imputado.Padre = "";
                            if ((imputado.FechaNacimiento instanceof Date && !isNaN(imputado.FechaNacimiento.valueOf())) === false)
                                imputado.FechaNacimiento = "";
                            if (i == 0) {
                                $("#divIppEncontrado").append("Imputados en el SIMP para la IPP " + ipp + ":");
                            }
                            $("#divIppEncontrado").append('<ul><a id="imputadoSimp' + i + '" href="#" onclick="LlenarControlesSimp(imputadoSimp' + i + ')"' +
                                //'data-comisaria="' + imputado.depPol + '" ' +
                                'data-fechanacimiento="' + imputado.FechaNacimiento + '" ' +
                                'data-delito="' + delito.ClaseDelito + '" ' +
                                'data-estadocivil="' + estcivil + '" ' +
                                'data-madre="' + imputado.Madre + '" ' +
                                'data-padre="' + imputado.Padre + '" ' +
                                'data-apodo="' + imputado.Apodo + '" ' +
                                //'data-juzgar="' + imputado.juzGar + '" ' +
                                'data-fechadelito="' + imputado.fechaDelito + '" ' +
                                'data-ufi="' + imputado.ufi + '" ' +
                                'data-titularufi="' + imputado.titularUfi + '" ' +
                                'data-nombre="' + imputado.Nombre + '" ' +
                                'data-sexo="' + sexo + '" ' +
                                'data-lugarnacimiento="' + imputado.LugarNacimiento + '" ' +
                                'data-apellido="' + imputado.Apellido + '">' + imputado.Apellido + ', ' + imputado.Nombre + '</a></ul>').show();
                            //alert('data.errorMessage');
                        }
                    }
                },
                beforeSend: function () {
                    //loader("Buscando datos de la IPP...");
                    $("#IPP").addClass("loadinggif");
                },
                complete: function () {
                    //$.unblockUI();    
                    $("#IPP").removeClass("loadinggif");
                },
                dataType: "json"
            });

        } else {
            $("#IPP").data("validator");
        }
    });
});


$(document).ready(function () {
    $('#LocalidadPolicial').bind('keyup keypress blur change cut copy paste ', function () {
        ControlarComisaria();
    });
});





$("#btnGuardar").on('click', function () {
    if ($("#frmDetalleOtip").valid() == false) {
        //$("#frmDetalleOtip").data("validator").settings.focusInvalid = false;
        $("#frmDetalleOtip").data("validator");
        alertify.error("Error en la carga");
    }
});





function BorrarImputado(id) {

    var url = urlBorrarImputado + encodeURI(id);
    $.get(url, null, function (data) {
        if (data === "True") {

            $("#tr" + id).remove();
            alertify.success("Imputado borrado correctamente");


        } else {
            alertify.error("Error al borrar");
        }
    });


}







//GUARDAR IMPUTADO DE OTIP
function onGuardarBegin() {
    loader("Guardando, espere un momento...");
}
function onGuardarComplete() {
    $.unblockUI();
}


function onGuardarSuccess(data) {
    if (data == "") {
        $('.validation-summary-errors li').remove();
        $("#btnImagenes").attr("disabled", false);
        if (!$('#CodBarras').is('[readonly]')) {
            $("#CodBarras").attr("readonly", true);
            var cb = $("#CodBarras").val();
            var id = BuscarIdImputado(cb);
            $("#Id").val(id);
            var href = $("#btnImagenes").attr("href").replace("idImputado=0", "idImputado=" + id) + "&cb=" + cb;
            $("#btnImagenes").attr("href", href);

        }

        alertify.success("Carga Exitosa");

    } else {
        $("#frmDetalleOtip").data("validator").settings.focusInvalid = false;
        alertify.error("Error en la carga");
    }
}
function onGuardarFailure(datos) {
    $("#frmDetalleOtip").data("validator").settings.focusInvalid = false;
    alertify.error("Error en la carga:<br/>" + data);
}
///////////////////////////
//PARA GENERAR REPORTE DEL IMPUTADO
//function onGenerarReporteBegin() {
//    loader("Generando el reporte, espere un momento...");
//}
//function onGenerarReporteComplete() {
//    $.unblockUI();
//}
//function onGenerarReporteSuccess(data) {

//  alertify.success("Carga Exitosa");
//  }
//function onGenerarReporteFailure(datos) {
//    alertify.error("Error","No se pudo generar el reporte.");
//}
///////////////////////////////

/////////////////////////
///IMAGEMAPPSTER
/////////////////////////

$(function () {


    $(function () {
        $("#body").mapster({
            singleSelect: true,
            //render_highlight: { altImage: '../Areas/Otip/Content/Images/body3.png' },
            render_highlight: { altImage: urlMapperBody3 },
            mapKey: 'parte',
            scaleMap: true,
            fill: true,
            stroke: true,
            strokeOpacity: 0.85,
            //altImage: '../Areas/Otip/Content/Images/body2.png',
            altImage: urlMapperBody2,
            fillOpacity: 0.7,
            onStateChange: function (object) {

                if (object.state === "select") {
                    var rnd = $('#hidRnd').val();
                    if (object.selected === true) {
                        var area = $("#bodymap>area[parte=" + object.key + "]");
                        $("#lblUbicacionSena" + rnd).html(area.data("original-title"));
                        $("#hidIdUbicacionSena" + rnd).val(area.attr("value"));
                        //$("#lblParteSeleccionada").html(area.data("original-title"));
                    } else if (object.key !== "cuerpoE") {
                        $("#lblUbicacionSena" + rnd).html('');
                        $("#hidIdUbicacionSena" + rnd).val("1");
                    }
                }
            }
        });
        $('#body').mapster('resize', 250, 0, 1000);
        $('#btnCuerpoEntero').on("click", function () {
            //$("#lblUbicacionSena").html('Cuerpo Entero');
            $("#hidIdUbicacionSena").val('50');
            $("area.cuerpoE").mapster('set');
            var seleccionado = $("#body").mapster('get', 'cuerpoE');
            if (!seleccionado) {
                $("#lblUbicacionSena").html('');
                $("#hidIdUbicacionSena").val("1");
            }

        });

        $('#btnCuerpoEntero').on("mouseenter", function () {
            var seleccionado = $("#body").mapster('get', 'cuerpoE');
            if (!seleccionado)
                $("area.cuerpoE").mapster('highlight', true);
        });
        $('#btnCuerpoEntero').on("mouseleave", function () {
            var seleccionado = $("#body").mapster('get', 'cuerpoE');
            if (!seleccionado)
                $("area.cuerpoE").mapster('set', false);
        });

        $(document).on('click', '#btnOtraParte', function () {

            var rnd = $("#hidRnd").val();
            $("#body").mapster('set', false, $("#body").mapster('get'));
            $("#lblUbicacionSena" + rnd).html('Otro');
            $("#hidIdUbicacionSena").val('43');

            //$("#lblParteSeleccionada").html('Otro');
        });
        $(document).on('click', '#btnLimpiarPartes', function () {
            $("#lblUbicacionSena").html('');
            $("#hidIdUbicacionSena").val('1');
            //$("#lblParteSeleccionada").html('');
            $("#body").mapster('set', false, $("#body").mapster('get'));
        });

    });



});
/////////////////////////////


function getUrlParameter(name, url) {
    if (!url) url = location.href
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(url);
    return results == null ? null : results[1];
}

//FileUploader///////////////////////

function TipoArchivoChange(rnd, control) {
    var tipoArchivo = control[control.selectedIndex].text;

    if (tipoArchivo.toLowerCase().indexOf("tatuaje") > -1) {
        $("#lblTipoSena" + rnd).hide();
        $("#lblTipoTatuaje" + rnd).show();
        $("#TipoSena" + rnd).hide();
        $("#DescripcionArchivo" + rnd).hide();
        $("#lblDescripcion" + rnd).hide();
        $("#DescripcionTatuaje" + rnd).show();
    }
    else {
        $("#lblTipoTatuaje" + rnd).hide();
        $("#DescripcionArchivo" + rnd).show();
        $("#DescripcionTatuaje" + rnd).hide();
        $("#lblDescripcion" + rnd).show();
    }

    if (tipoArchivo.toLowerCase().indexOf("seña") > -1) {

        $("#lblTipoSena" + rnd).show();
        $("#lblTipoTatuaje" + rnd).hide();
        $("#TipoSena" + rnd).show();
        $("#DescripcionTatuaje" + rnd).hide();


    }
    else {
        $("#lblTipoSena" + rnd).hide();

        $("#TipoSena" + rnd).hide();

    }


    if (tipoArchivo.toLowerCase().indexOf("seña") > -1 || tipoArchivo.toLowerCase().indexOf("tatuaje") > -1) {
        $("#btnIndicarUbicacion" + rnd).show();
        $("#lblUbicacionS" + rnd).show();
        $("#lblUbicacionSena" + rnd).show();

    }
    else {
        $("#btnIndicarUbicacion" + rnd).hide();
        $("#lblUbicacionS" + rnd).hide();
        $("#lblUbicacionSena" + rnd).hide();

    }

}


function LimpiarDatosCaptura() {
    $('#hidImagenCapturada').val("");
    $('#imageCapturaWebcam').attr("src", "");
    $("#TipoArchivoWebcam").val(1);
    $("#lblUbicacionSenaWebcam").html("");
    $("#hidIdUbicacionSenaWebcam").val("1");
    $("#TipoSenaWebcam").val(0);
    $("#DescripcionArchivoWebcam").val("");
    //  $("object[type^=application]").attr("width", "0").attr("height", "0");
}


function PrepararSubida(rnd, esCaptura) {
    $("#hidDescripcionArchivo").val($("#DescripcionArchivo" + rnd).val());
    $("#hidTipoArchivo").val($("#TipoArchivo" + rnd).val());
    $("#hidDescripcionTatuaje").val($("#DescripcionTatuaje" + rnd).val());
    $("#hidTipoSena").val($("#TipoSena" + rnd).val());
    $("#hidIdUbicacion").val($("#hidIdUbicacionSena" + rnd).val());
    $("#esCaptura").val(esCaptura);


    $('html, body').animate({
        scrollTop: $("#tableUpload").offset().top
    }, 2000);

};
///////////////////////////////////