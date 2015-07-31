function ContinuarInfiniteScroll() {
    $('.wrap').infinitescroll('resume');
}


function AsignarPrettyPhoto(caller) {
    var href = $(caller).attr('href');
    $('.wrap').infinitescroll('pause');
    $.prettyPhoto.open(href);
    $('.wrap').infinitescroll('resume');
    //event.preventDefault();

}

$(document).ready(function () {

    //Initialize PrettyPhoto here
    $("a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', overlay_gallery: false, slideshow: 3000, autoplay_slideshow: false, social_tools: false, deeplinking: false });
   
   
    
});


/////////////////
//form busqueda//
/////////////////
$(document).ready(function () {
    //$("section#DatosSomaticos>div.panel>div.panel-heading").hide();
    $("section#DatosSomaticos").css("padding-top", "0");
    //$('#CodBarras').mask("999999999999a");
    var busqAv = $("#BusquedaAvanzada").val();
    if (busqAv === "1") {
        if ($("#pnlBusquedaAvanzada").hasClass("hidden"))
            $("#pnlBusquedaAvanzada").toggleClass("hidden");
        if ($("#pnlDatosSomaticos").hasClass("hidden"))
            $("#pnlDatosSomaticos").toggleClass("hidden");
        $("#lblBusquedaAvanzada").addClass("active");
    }  else if (busqAv==="0") {
        $("#lblBusquedaAvanzada").removeClass("active");
    }


});


$(function() {
    $("#btnBusquedaAvanzada").change(function () {
      
        $("#pnlBusquedaAvanzada").toggleClass("hidden");
        $("#pnlDatosSomaticos").toggleClass("hidden");
        var busquedaAvanzada = 0;
        if ($("#pnlDatosSomaticos").hasClass("hidden") === false) {
            busquedaAvanzada = 1;
            $('html, body').animate({
                scrollTop: $("#pnlBusquedaAvanzada").offset().top
            }, 2000);
        }

        $("#BusquedaAvanzada").val(busquedaAvanzada);
    });
});



$(function() {
    $('#EdadDesde').bind('keyup keypress blur change cut copy paste ', function() {
        var validator = $("#frmBusquedaSic").validate();
        validator.element(this);
        validator.element($("#EdadHasta"));
    });
    $('#EdadHasta').bind('keyup keypress blur change cut copy paste ', function() {
        var validator = $("#frmBusquedaSic").validate();
        validator.element(this);

        validator.element($("#EdadDesde"));
    });
});


$(function() {
    $('#tablaPortal').dataTable({
        "dom": '<"row"<"col-md-12"ip>><"clear">rt<"bottom"><"clear"><"row"<"col-md-12"p>>',
        "initComplete": function(settings, json) {
            $.unblockUI();
        },
        serverSide: true,
        "processing": false,
        "stateSave": true,
        "ajax": window.urlTablaImputados,

        "order": [[2, "asc"]], //codbarras
        "columns": [
            { "data": null },
            { "data": "ThumbUrl" },
            { "data": "CodigoDeBarras" },
            { "data": "Apellido" },
            { "data": "Nombre" },
            { "data": "DocumentoNumero" },
            { "data": "Id" }
        ],
        "columnDefs": [
            {
                "orderable": false,
                "searchable": false,
                "data": null,
                //"defaultContent": "Editar",
                "targets": 0 //Ver
            },
            {
                "render": function(data, type, row) {
                    if (data !== "" && data != null)

                        return '<p class="thumb"><img src=' + data + '?r=' + Math.random() + ' style="max-width: 100px"  /><br/></p>';
                    else
                        return '';

                },
                "orderable": false,
                "searchable": false,
                "targets": 1 //ThumbUrl
            },
            {
                "render": function(data, type, row) {
                    var url = window.location.href;
                    return '<a href="' + urlVerImputado + '?id=' + row.Id + '&returnUrl=' + url + '" title="Ver Imputado" onclick=" showPageLoadingSpinner() " class="btn btn-alt">Ver</a>';
                },
                "targets": 0, //ver
            },
            {
                "targets": 6, //id
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
    }).on('processing.dt', function(e, settings, processing) {
        if (processing) {
            loader("Buscando datos...");
        } else {
            $.unblockUI();
        }
    }).dataTable();

    $('#tablaPortal').on('page.dt', function () {
       
        
    });
});


$(document).ready(function () {
    //ControlarComisaria();
    $('#FechaDelitoDesde').bind('keyup keypress blur change cut copy paste ', function () {
        var validator = $("#frmBusquedaSic").validate();
        validator.element(this);
        validator.element($("#FechaDelitoHasta"));

    });
    
});



$(document).ready(function () {
    //ControlarComisaria();
    $('#FechaDelitoHasta').bind('keyup keypress blur change cut copy paste ', function () {
        var validator = $("#frmBusquedaSic").validate();
        validator.element(this);
        validator.element($("#FechaDelitoDesde"));

    });

});

////////////////////////////
function ElegirFoto(control) {
    var cant = $("#CantFotosAgregadas").val();
    if (cant == null) cant = 0;
    var fotosAgregadas = $("#FotosAgregadas").val();
    var urlFoto = $(control).parent().parent().parent().children().attr("href");
    if ($(control).prop('checked') === true) {
        //$(control).parent().parent().parent().css("border-color", "rgba(255, 192, 203, 0.70)");
        $(control).parents(".item").children("img").css("background", "red");
        //$(control).parent().parent().parent().addClass("tile-light");
        cant++;

        fotosAgregadas = fotosAgregadas + "," + urlFoto;
    } else {
        //$(control).parent().parent().parent().css("background-color", "transparent");
        $(control).parents(".item").children("img").css("background", "rgba(0, 0, 0, 0.24)");
        cant--;
        fotosAgregadas = fotosAgregadas.replace("," + urlFoto, "");

    }
    var msg = "";
    if (cant === 1)
        msg = "1 FOTO AGREGADA";
    else if (cant > 1)
        msg = cant + " FOTOS AGREGADAS";
    $("#CantFotosAgregadas").val(cant);
    $("#CartelFotosAgregadas").html( msg );
    if (msg === "")
        $("#CartelFotosAgregadas").html('');
    else {
        $("#CartelFotosAgregadas").append("<a style='margin-left:10px;' href='#' class='btn  btn-alt' onclick='MostrarFotosElegidas()'>Mostrar</a>");
    }
    $("#FotosAgregadas").val(fotosAgregadas);
}

function MostrarFotosElegidas() {
    var fotosElegidas = $("#FotosAgregadas").val();
    fotosElegidas = fotosElegidas.indexOf(',') == 0 ? fotosElegidas.substring(1) : fotosElegidas;
    if (fotosElegidas != null && fotosElegidas != "") {

        window.open(urlFotosElegidas + fotosElegidas);
    }
}




jQuery.validator.addMethod('numericlessthan', function (value, element, params) {
    var otherValue = $(params.element).val();
    if ((value === '' && otherValue === '')) { return true}
    return isNaN(value) && isNaN(otherValue) || (params.allowequality === 'True' ? parseFloat(value) <= parseFloat(otherValue) : parseFloat(value) < parseFloat(otherValue));
}, '');

jQuery.validator.unobtrusive.adapters.add('numericlessthan', ['other', 'allowequality'], function (options) {
    var prefix = options.element.name.substr(0, options.element.name.lastIndexOf('.') + 1),
    other = options.params.other,
    fullOtherName = appendModelPrefix(other, prefix),
    element = $(options.form).find(':input[name=' + fullOtherName + ']')[0];

    options.rules['numericlessthan'] = { allowequality: options.params.allowequality, element: element };
    if (options.message) {
        options.messages['numericlessthan'] = options.message;
    }
});


jQuery.validator.addMethod('numericgreaterthan', function (value, element, params) {
    var otherValue = $(params.element).val();
    if ((value === '' && otherValue === '')) { return true }
    return isNaN(value) && isNaN(otherValue) || (params.allowequality === 'True' ? parseFloat(value) >= parseFloat(otherValue) : parseFloat(value) > parseFloat(otherValue));
}, '');

jQuery.validator.unobtrusive.adapters.add('numericgreaterthan', ['other', 'allowequality'], function (options) {
    var prefix = options.element.name.substr(0, options.element.name.lastIndexOf('.') + 1),
    other = options.params.other,
    fullOtherName = appendModelPrefix(other, prefix),
    element = $(options.form).find(':input[name=' + fullOtherName + ']')[0];

    options.rules['numericgreaterthan'] = { allowequality: options.params.allowequality, element: element };
    if (options.message) {
        options.messages['numericgreaterthan'] = options.message;
    }
});

function appendModelPrefix(value, prefix) {
    if (value.indexOf('*.') === 0) {
        value = value.replace('*.', prefix);
    }
    return value;
}

$(window).load(function () {

    $(function() {
        $("#btnImprimirFotos").on("click", function() {
            $("#printForm").printThis({

            });
        });
    });
  



    $(function () {
        var $container = $('.wrap');
            $container.isotope({
            itemSelector: '.item',
            layoutMode: 'fitRows'
        });
     


        $container.infinitescroll({
            navSelector: '.navselector', // selector for the paged navigation
            nextSelector: '.navselector a', // selector for the NEXT link (to page 2)
            itemSelector: '.item', // selector for all items you'll retrieve
            animate: 'true',
            extraScrollPx: 200,
            bufferPx: 100,
            prefill: 'true',
            finishedMsg: '<div><h5>No hay más fotos que mostrar.</h5></div>',
            loading: {
                //finishedMsg: 'No hay mas fotos para mostrar.',
                //finished: undefined,
                finishedMsg: '<div><h5>No hay más fotos que mostrar.</h5></div>',
                speed: "Slow",
                img: null,
                msgText: '<div><img alt="Cargando..." src="../../Areas/PortalSIC/Content/Images/loader.gif"><br/><em>Cargando más fotos...</em></div>'

            }
        },
            function (newElements) {

                var $newElems = $(newElements);
                $newElems.imagesLoaded(function () {
                    $container.isotope('appended', $newElems);
                });


                ////Initialize PrettyPhoto here
                $("a[rel^='prettyPhoto']").prettyPhoto({
                    animation_speed: 'normal',
                    overlay_gallery: true,
                    deeplinking:false,
                    slideshow: 3000,
                    autoplay_slideshow: false,
                    social_tools: false,
                    allow_expand: false,
                    callback: function () {
                        (ContinuarInfiniteScroll || Function)();

                    }
                });
            });

    });



    $('#NumeroDocumento').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroNroDoc").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroNroDoc"><label>Nro.Doc.: ' + valor + '</label><a  onclick=$("#filtroNroDoc").remove();$("#NumeroDocumento").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#CodBarras').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroCodBarras").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroCodBarras"><label>Cod.Barras: ' + valor + '</label><a  onclick=$("#filtroCodBarras").remove();$("#CodBarras").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Delito').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroDelito").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroDelito"><label>Delito: ' + valor + '</label><a  onclick=$("#filtroDelito").remove();$("#Delito").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Apellido').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroApellido").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroApellido"><label>Apellido: ' + valor + '</label><a  onclick=$("#filtroApellido").remove();$("#Apellido").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Nombres').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroNombre").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroNombre"><label>Nombre: ' + valor + '</label><a  onclick=$("#filtroNombre").remove();$("#Nombres").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FiscaliaGeneral').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroFisGral").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroFisGral"><label>Fisc.: ' + $("#FiscaliaGeneral option:selected").text() + '</label><a  onclick=$("#filtroFisGral").remove();$("#FiscaliaGeneral").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#IPP').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroIPP").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroIPP"><label>IPP: ' + valor + '</label><a  onclick=$("#filtroIPP").remove();$("#IPP").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Apodos').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroApodos").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroApodos"><label>Apodos: ' + valor + '</label><a  onclick=$("#filtroApodos").remove();$("#Apodos").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#EdadDesde').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroEdadDesde").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroEdadDesde"><label>Edad Desde: ' + valor + '</label><a  onclick=$("#filtroEdadDesde").remove();$("#EdadDesde").val("").valid();$("#EdadHasta").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#EdadHasta').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroEdadHasta").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroEdadHasta"><label>Edad Hasta: ' + valor + '</label><a  onclick=$("#filtroEdadHasta").remove();$("#EdadHasta").val("").valid();$("#EdadDesde").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Madre').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroMadre").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroMadre"><label>Madre: ' + valor + '</label><a  onclick=$("#filtroMadre").remove();$("#Madre").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Padre').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroPadre").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroPadre"><label>Padre: ' + valor + '</label><a  onclick=$("#filtroPadre").remove();$("#Padre").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FechaDelitoDesde').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroFechaDelitoDesde").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroFechaDelitoDesde"><label>Fecha Del. De: ' + valor + '</label><a  onclick=$("#filtroFechaDelitoDesde").remove();$("#FechaDelitoDesde").val("").valid();$("#FechaDelitoHasta").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FechaDelitoHasta').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroFechaDelitoHasta").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroFechaDelitoHasta"><label>Fecha Del. Hasta: ' + valor + '</label><a  onclick=$("#filtroFechaDelitoHasta").remove();$("#FechaDelitoHasta").val("").valid();$("#FechaDelitoDesde").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#OtrosNombres').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroOtrosNombres").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroOtrosNombres"><label>Otros Nombres: ' + valor + '</label><a  onclick=$("#filtroOtrosNombres").remove();$("#OtrosNombres").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Profesion').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroProfesion").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroProfesion"><label>Profesión: ' + valor + '</label><a  onclick=$("#filtroProfesion").remove();$("#Profesion").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#LocalidadNacimiento').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroLocalidadNacimiento").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroLocalidadNacimiento"><label>Lugar Nac.: ' + valor + '</label><a  onclick=$("#filtroLocalidadNacimiento").remove();$("#LocalidadNacimiento").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Calle').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroCalle").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroCalle"><label>Calle Imp.: ' + valor + '</label><a  onclick=$("#filtroCalle").remove();$("#Calle").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#NroH').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroNroH").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroNroH"><label>Nro. Casa: ' + valor + '</label><a  onclick=$("#filtroNroH").remove();$("#NroH").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Localidad').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroLocalidad").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroLocalidad"><label>Loc. Imp.: ' + valor + '</label><a  onclick=$("#filtroLocalidad").remove();$("#Localidad").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Partido').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroPartido").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroPartido"><label>Part. Imp.: ' + valor + '</label><a  onclick=$("#filtroPartido").remove();$("#Partido").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Sexo').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroSexo").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroSexo"><label>Sexo: ' + $("#Sexo option:selected").text() + '</label><a  onclick=$("#filtroSexo").remove();$("#Sexo").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#ProvinciaNacimiento').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroProvinciaNacimiento").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroProvinciaNacimiento"><label>Prov. Nac.: ' + $("#ProvinciaNacimiento option:selected").text() + '</label><a  onclick=$("#filtroProvinciaNacimiento").remove();$("#ProvinciaNacimiento").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#PaisNacimiento').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroPaisNacimiento").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroPaisNacimiento"><label>País Nac.: ' + $("#PaisNacimiento option:selected").text() + '</label><a  onclick=$("#filtroPaisNacimiento").remove();$("#PaisNacimiento").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Provincia').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroProvincia").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroProvincia"><label>Prov. Imputado: ' + $("#Provincia option:selected").text() + '</label><a  onclick=$("#filtroProvincia").remove();$("#Provincia").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Robustez').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroRobustez").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroRobustez"><label>Robustez: ' + $("#Robustez option:selected").text() + '</label><a  onclick=$("#filtroRobustez").remove();$("#FiscaliaGeneral").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#ColorPiel').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroColorPiel").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroColorPiel"><label>Color Piel: ' + $("#ColorPiel option:selected").text() + '</label><a  onclick=$("#filtroColorPiel").remove();$("#ColorPiel").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#ColorOjos').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroColorOjos").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroColorOjos"><label>Color Ojos: ' + $("#ColorOjos option:selected").text() + '</label><a  onclick=$("#filtroColorOjos").remove();$("#ColorOjos").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#ColorCabellos').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroColorCabello").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroColorCabello"><label>Color Pelo: ' + $("#ColorCabellos option:selected").text() + '</label><a  onclick=$("#filtroColorCabello").remove();$("#ColorCabellos").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#TipoCabello').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroTipoCabello").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroTipoCabello"><label>Tipo Pelo: ' + $("#TipoCabello option:selected").text() + '</label><a  onclick=$("#filtroTipoCabello").remove();$("#TipoCabello").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#TipoCalvicie').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroCalvicie").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroCalvicie"><label>Calvicie: ' + $("#TipoCalvicie option:selected").text() + '</label><a  onclick=$("#filtroCalvicie").remove();$("#TipoCalvicie").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FormaCara').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroFormaCara").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroFormaCara"><label>Forma Cara: ' + $("#FormaCara option:selected").text() + '</label><a  onclick=$("#filtroFormaCara").remove();$("#FormaCara").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#DimensionCeja').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroDimensionCeja").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroDimensionCeja"><label>Dim. Cejas: ' + $("#DimensionCeja option:selected").text() + '</label><a  onclick=$("#filtroDimensionCeja").remove();$("#DimensionCeja").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#TipoCeja').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroTipoCeja").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroTipoCeja"><label>Tipo Cejas: ' + $("#TipoCeja option:selected").text() + '</label><a  onclick=$("#filtroTipoCeja").remove();$("#TipoCeja").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FormaMenton').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroFormaMenton").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroFormaMenton"><label>Forma Mentón: ' + $("#FormaMenton option:selected").text() + '</label><a  onclick=$("#filtroFormaMenton").remove();$("#FormaMenton").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FormaOreja').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroFormaOreja").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroFormaOreja"><label>Forma Orejas: ' + $("#FormaOreja option:selected").text() + '</label><a  onclick=$("#filtroFormaOreja").remove();$("#FormaOreja").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FormaNariz').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroFormaNariz").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroFormaNariz"><label>Forma Nariz: ' + $("#FormaNariz option:selected").text() + '</label><a  onclick=$("#filtroFormaNariz").remove();$("#FormaNariz").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FormaBoca').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroFormaBoca").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroFormaBoca"><label>Forma Boca: ' + $("#FormaBoca option:selected").text() + '</label><a  onclick=$("#filtroFormaBoca").remove();$("#FormaBoca").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FormaLabioInferior').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroFormaLabioInferior").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroFormaLabioInferior"><label>Labio Inf.: ' + $("#FormaLabioInferior option:selected").text() + '</label><a  onclick=$("#filtroFormaLabioInferior").remove();$("#FormaLabioInferior").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#FormaLabioSuperior').bind('change  ', function () {
        var valor = $(this).val();
        $("#filtroFormaLabioSuperior").remove();
        if (valor != '0') {
            $("#filtrosAplicados").append('<div id="filtroFormaLabioSuperior"><label>Labio Sup.: ' + $("#FormaLabioSuperior option:selected").text() + '</label><a  onclick=$("#filtroFormaLabioSuperior").remove();$("#FormaLabioSuperior").val("0").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
    $('#Estatura').bind('keyup keypress blur change cut copy paste input', function () {
        var valor = $(this).val();
        $("#filtroEstatura").remove();
        if (valor != '') {
            $("#filtrosAplicados").append('<div id="filtroEstatura"><label>Estatura: ' + valor + '</label><a  onclick=$("#filtroEstatura").remove();$("#Estatura").val("").valid(); href="#filtrosAplicados"><i style="color:red;margin-left:5px;" class="fa fa-times"></i></a></div>');
        }
    });
});

function LlenarPanelFiltros() {
    $('input').blur();
    $.each($("select"), function() {
        if ($(this).val() !== '0' && $(this).val() !=='') {
            $(this).change();
        }
    });
};

