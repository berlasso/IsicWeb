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