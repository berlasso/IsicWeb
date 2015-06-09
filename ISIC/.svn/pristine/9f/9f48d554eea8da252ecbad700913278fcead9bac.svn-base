

jQuery.support.cors = true;
(function ($) {
    
    if ($.validator && $.validator.unobtrusive) {
        $.validator.unobtrusive.adapters.add(
           'isdateafter', ['propertytested', 'allowequaldates','allowoneempty'], function (options) {
               options.rules['isdateafter'] = options.params;
               options.messages['isdateafter'] = options.message;
           });
        $.validator.addMethod("isdateafter", function (value, element, params) {

            var parts = element.name.split(".");
            var prefix = "";
            if (parts.length > 1)
                prefix = parts[0] + ".";
            var startdatevalue = $('input[name="' + prefix + params.propertytested + '"]').val();

            if (params.allowoneempty === "False" && (value=="" ^ startdatevalue==""))
                return false;
            if (!value || !startdatevalue)
                return true;
            var dateparts = value.split("/");
            var d1 = new Date(Number(dateparts[2]), Number(dateparts[1]) - 1, Number(dateparts[0]));
            dateparts = startdatevalue.split("/");
            var d2 = new Date(Number(dateparts[2]), Number(dateparts[1]) - 1, Number(dateparts[0]));
            return (params.allowequaldates) ? Date.parse(d2) <= Date.parse(d1) :
                Date.parse(d2) < Date.parse(d1);
        });
    }
})(jQuery);
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
})


$(function() {
    if ($.validator && $.validator.unobtrusive) {
        $.validator.unobtrusive.adapters.add(
           'isdatebefore', ['propertytested', 'allowequaldates'], function (options) {
               options.rules['isdatebefore'] = options.params;
               options.messages['isdatebefore'] = options.message;
           });
        $.validator.addMethod("isdatebefore", function (value, element, params) {

            var parts = element.name.split(".");
            var prefix = "";
            if (parts.length > 1)
                prefix = parts[0] + ".";
            var startdatevalue = $('input[name="' + prefix + params.propertytested + '"]').val();


            if (!value || !startdatevalue)
                return true;
            var dateparts = value.split("/");
            var d2 = new Date(Number(dateparts[2]), Number(dateparts[1]) - 1, Number(dateparts[0]));
            dateparts = startdatevalue.split("/");
            var d1 = new Date(Number(dateparts[2]), Number(dateparts[1]) - 1, Number(dateparts[0]));
            return (params.allowequaldates) ? Date.parse(d2) <= Date.parse(d1) :
                Date.parse(d2) < Date.parse(d1);
        });
    }
});



$(function () {

    //$(function () {
    //    $('.datepicker').datetimepicker({
    //        locale: 'es',
    //        format: 'DD/MM/YYYY',
    //        minDate: '01/01/1900',
    //        maxDate: new Date()
    //    });
    //});
    $(".datepicker").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),
        dateFormat: "dd/mm/yy",
        yearRange: "-100:+0"
    });
});


jQuery(function($) {
    'use strict',

        //#main-slider
        $(function() {
            $('#main-slider.carousel').carousel({
                interval: 8000
            });
        });


    // accordian
    $('.accordion-toggle').on('click', function() {
        $(this).closest('.panel-group').children().each(function() {
            $(this).find('>.panel-heading').removeClass('active');
        });

        $(this).closest('.panel-heading').toggleClass('active');
    });

    //Initiat WOW JS
    new WOW().init();
});

function loader(mensaje) {
    $("#cartelLoader span").html(mensaje);
    $.blockUI({
        baseZ: "9999",

        message: $("#cartelLoader"),
        fadeIn: 700,
        fadeOut: 700,
        showOverlay: true,
        css: {
            top: ($(window).height() - 300) / 2 + "px",
            left: ($(window).width() - 300) / 2 + 100 + "px",
            width: 300,
            right: "10px",
            border: "none",
            padding: "5px",
            backgroundColor: "#000",
            '-webkit-border-radius': "10px",
            '-moz-border-radius': "10px",
            opacity: .6,
            color: "#fff"

        }
    });
}
//$(window).load(function () {
//    'use strict';
//    var $portfolio_selectors = $('.portfolio-filter >li>a');
//    var $portfolio = $('.portfolio-items');
//    $portfolio.isotope({
//        itemSelector: '.portfolio-item',
//        layoutMode: 'fitRows'
//    });

//    $portfolio_selectors.on('click', function () {
//        $portfolio_selectors.removeClass('active');
//        $(this).addClass('active');
//        var selector = $(this).attr('data-filter');
//        $portfolio.isotope({ filter: selector });
//        return false;
//    });
//});

// portfolio filter
$(window).load(function () {
    'use strict';
    var $portfolio_selectors = $('.portfolio-filter >li>a');
    var $portfolio = $('.portfolio-items');
    $portfolio.isotope({
        itemSelector: '.portfolio-item',
        layoutMode: 'fitRows'
    });

    $portfolio_selectors.on('click', function () {
        $portfolio_selectors.removeClass('active');
        $(this).addClass('active');
        var selector = $(this).attr('data-filter');
        $portfolio.isotope({ filter: selector });
        return false;
    });



    
});


//$(function () {
//    $('.volver').click(function (e) {
//        e.preventDefault();
//        //showPageLoadingSpinner();
//        history.go(-1);
//    });
//});



$(document).ready(function () {
    //Initialize PrettyPhoto here
    $("a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', overlay_gallery: false, slideshow: 3000, autoplay_slideshow: false, social_tools: false, deeplinking: false });
    // items filter


});

//$(function () {
//    $('#fotos_filter a').click(function() {
//        var selector = $(this).attr('data-filter');
//        $('div#fotos').isotope({
//            filter: selector,
//            itemSelector: 'img.foto',
//            layoutMode: 'fitRows'
//        });

//        $('#fotos_filter').find('a.active').removeClass('active');
//        $(this).addClass('active');

//        return false;
//    });
//});
