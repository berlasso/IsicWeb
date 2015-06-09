$(document).ready(function () {
    //Initialize PrettyPhoto here
    $("a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', overlay_gallery: false, slideshow: 3000, autoplay_slideshow: false, social_tools: false 	});
    // items filter
    $('#fotos_filter a').click(function () {
        var selector = $(this).attr('data-filter');
        $('div#fotos').isotope({
            filter: selector,
            itemSelector: 'img.foto',
            layoutMode: 'fitRows'
        });

        $('#fotos_filter').find('li.active').removeClass('active');
        $(this).parent('li').addClass('active');

        return false;
    });

	
});