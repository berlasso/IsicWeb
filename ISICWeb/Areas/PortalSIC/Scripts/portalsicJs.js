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



$(function () {
    $('#tablaPortal').dataTable({
        //"dom": 'TRfrtsp<"row"<"col-md-12"l>>i',
        //"dom": '<"row"<"col-md-5"TR><"col-md-1"><"col-md-6"p>>ts<"row"<"col-md-6"l><"col-md-6"p>>i',
        "dom": '<"row"<"col-md-12"ip>><"clear">rt<"bottom"><"clear">',
        serverSide: true,
        "processing": true,
        "ajax": window.urlTablaImputados,
        "order": [[2, "asc"]], //codbarras
        "columns": [
                    { "data": null },
                    {"data": "ThumbUrl"},
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
            "render": function (data, type, row) {
                if (data !== "")
                    
                return '<img src=' + data + ' style="max-width: 100px" />';
                else
                    return '';
            },
            "orderable": false,
            "searchable": false,
            "targets": 1 //ThumbUrl
        },
        {
            "render": function (data, type, row) {
                return '<a href="' + urlVerImputado+  '/' + row.Id + '" title="Ver Imputado" onclick=" showPageLoadingSpinner() " class="btn btn-alt">Ver</a>';
            },
            "targets": 0, //ver
        },

     
       {
           "targets": 6,//id
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
        //"tableTools": {
        //    "sSwfPath": "/Content/swf/copy_csv_xls_pdf.swf",
        //    "aButtons": [
        //        {
        //            "sExtends": "copy",
        //            "oSelectorOpts": { filter: 'applied', order: 'current' },
        //            "mColumns": "visible",
        //            "sButtonText": "Copiar"
        //        },
        //        {
        //            "sExtends": "xls",
        //            "oSelectorOpts": { filter: 'applied', order: 'current' },
        //            "mColumns": "visible",

        //        },
        //        {
        //            "sExtends": "pdf",
        //            "oSelectorOpts": { filter: 'applied', order: 'current' },
        //            "mColumns": "visible",
        //            "sPdfOrientation": "landscape"
        //        },
        //        {
        //            "sExtends": "print",
        //            "sButtonText": "Imprimir",
        //            "sInfo": "<h2 style='color: white;'>Vista de Impresión</h2><p>Utilice la funcion de impresion del navegador para imprimir la tabla. Presione ESCAPE cuando haya terminado</p>"
        //        }
        //    ]
        //}
    });
   

    $('tablaPortal').on('processing.dt', function (e, settings, processing) {
        if (processing) {

                        showPageLoadingSpinner();
                    } else {
                        hidePageLoadingSpinner(1);
                    }
    }).dataTable();

  

   
});




$(function() {
    $("#btnBusquedaAvanzada").change(function() {
        $("#pnlBusquedaAvanzada").toggleClass("hidden");
        $("#pnlDatosSomaticos").toggleClass("hidden");
  
    });
});

$(function () {
    $("#btnBuscar").on('click', function () {
        if ($("#frmBusquedaSic").valid() == false) {
            //$("#frmDetalleOtip").data("validator").settings.focusInvalid = false;
            $("#frmBusquedaSic").data("validator");
            alertify.error("Error en los datos ingresados");
        } else {
            var busquedaAvanzada = 0;
            if ($("#pnlDatosSomaticos").hasClass("hidden") === false)
                busquedaAvanzada = 1;
            $("#BusquedaAvanzada").val(busquedaAvanzada);
            showPageLoadingSpinner();
        }
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
    $("#CartelFotosAgregadas").html("<b>" + msg + "<i class='flaticon-zoom22'></i></b> ");
    if (msg === "")
        $("#CartelFotosAgregadas").html('');
    $("#FotosAgregadas").val(fotosAgregadas);
}

function MostrarFotosElegidas() {
    var fotosElegidas = $("#FotosAgregadas").val();
    fotosElegidas = fotosElegidas.indexOf(',') == 0 ? fotosElegidas.substring(1) : fotosElegidas;
    if (fotosElegidas != null && fotosElegidas != "") {

        window.open(urlFotosElegidas + fotosElegidas);
    }
}

$(function() {
    $("#CartelFotosAgregadas").on("click", function() {
        MostrarFotosElegidas();
    });
});



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

    $(function () {
        $("#btnImprimir").on("click", function () {
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
});
