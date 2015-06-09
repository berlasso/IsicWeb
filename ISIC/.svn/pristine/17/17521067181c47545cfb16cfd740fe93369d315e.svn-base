function onGuardarBegin() {
    loader("Guardando, espere un momento...");
}

function onGuardarComplete() {
    $.unblockUI();
}

function onGuardarSuccess() {
    $('.validation-summary-errors li').remove();
    alertify.success("Carga Exitosa");
    
}

function onGuardarFailure() {
    $("#frmDetalleOtip").data("validator").settings.focusInvalid = false;
    alertify.error("Error en la carga");
}

    $('.selectize-localidad').selectize({
        valueField: 'value',
        labelField: 'name',
        searchField: 'search',
        delimiter: ',',
        maxItems: 1,
        closeAfterSelect: true,
        create: false,
        persist: false,
        loadingClass: 'loading',
        hideSelected: true,
        onChange: function (value) {
            var id = this.$input[0].id;
            var hiddenControl = '#hidId' + id;
            var valor = $("#elegido" + id).data("autocomplete");
            var valorIdProvincia = $("#elegido" + id).data("idprovincia");
            var valorIdPartido = $("#elegido" + id).data("idpartido");
            var valorPartido = $("#elegido" + id).data("partido");
            if (valor == null) {
                valor = "0";
            } 
            $(hiddenControl).val(valor);
            id = id.replace('Localidad', '');
            if (!isNaN(parseFloat(valorIdProvincia)))
                $('#Provincia' + id).val(valorIdProvincia);
            if (!isNaN(parseFloat(valorIdPartido))) {
                $('#Partido' + id).attr("data-autocomplete", valorIdPartido);
                $('#elegidoPartido' + id).html(valorPartido);
                $('#hidIdPartido'+id).val(valorIdPartido);
            }
        },
        render: {
            item: function (data) {
                var nombre = this.$input[0].id;
                var id = $('#hidId' + nombre).val();
                var datavalue = "";
                if (!isNaN(parseFloat(data.value)))
                    datavalue = data.value;
                else
                    datavalue = id;
                return '<div id="elegido' + nombre + '" data-autocomplete="' + datavalue + '" data-idprovincia="'+data.idProvincia+'" data-idpartido="'+data.idPartido+'" data-partido="'+data.partido+'">' + data.name + '</div>';
            }
        },
        load: function (query, callback) {
            if (!query.length) return callback();
            $.ajax({
                url: urlAutocompleteLocalidad + encodeURIComponent(query),
                type: 'GET',
                error: function () {
                    callback();
                },
                success: function (res) {
                    callback(res.localidadesEncontradas);
                }
            });
        }
    });

    $('#ModusOperandi').selectize({
        valueField: 'value',
        labelField: 'name',
        searchField: 'search',
        delimiter: ',',
        maxItems: 1,
        closeAfterSelect: true,
        create: false,
        persist: false,
        hideSelected: true,
        loadingClass: 'loading',
        onChange: function (value) {
            var id = this.$input[0].id;
            var hiddenControl = '#hidId' + id;
            var valor = $("#elegido" + id).data("autocomplete");
            if (valor == null) { valor = "0" };
            $(hiddenControl).val(valor);
        },
        render: {
            item: function (data) {
                var nombre = this.$input[0].id;
                var id = $('#hidId' + nombre).val();
                var datavalue = "";
                if (!isNaN(parseFloat(data.value)))
                    datavalue = data.value;
                else
                    datavalue = id;
                return '<div id="elegido' + nombre + '" data-autocomplete="' + datavalue + '">' + data.name + '</div>';
            }
        },

        load: function (query, callback) {
            if (!query.length) return callback();

            $.ajax({
                url: urlAutocompleteModusOperandi + encodeURIComponent(query),
                type: 'GET',
                error: function () {
                    callback();
                },
                success: function (res) {
                    callback(res.moEncontrados);
                }
            });
        }
    });

    $('.selectize-partido').selectize({
        valueField: 'value',
        labelField: 'name',
        searchField: 'search',
        delimiter: ',',
        maxItems: 1,
        closeAfterSelect: true,
        create: false,
        persist: false,
        hideSelected: true,
        loadingClass: 'loading',
        onChange: function (value) {
            var id = this.$input[0].id;
            var hiddenControl = '#hidId' + id;
            var valor = $("#elegido" + id).data("autocomplete");
            if (valor == null) { valor = "0" };
            $(hiddenControl).val(valor);
        },
        render: {
            item: function (data) {
                var nombre = this.$input[0].id;
                var id = $('#hidId' + nombre).val();
                var datavalue = "";
                if (!isNaN(parseFloat(data.value)))
                    datavalue = data.value;
                else
                    datavalue = id;
                return '<div id="elegido' + nombre + '" data-autocomplete="' + datavalue + '">' + data.name + '</div>';
            }
        },
        load: function (query, callback) {
            if (!query.length) return callback();
            var autocompletePartidoUrl = $("#autocompletePartidoUrl").val();
            $.ajax({
                url: urlAutocompletePartido + encodeURIComponent(query),
                type: 'GET',
                error: function () {
                    callback();
                },
                success: function (res) {
                    callback(res.partidosEncontrados);
                }
            });
        }
    });

    $(".datepicker").datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: "dd/mm/yy"
    });
