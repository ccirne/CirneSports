var app = {};

$(function () {
    app.inicializar();
});

app.inicializar = function () {
    $('#main-menu').smartmenus();
    app.obteresportes();
    app.obtermarcas();
}

app.obteresportes = function () {
    $.getJSON('/menu/obteresportes', function (data) {
        $(data).each(function () {
            $("#esportes").append("<li><a href='#'>" + this.CategoriaDescricao + "</a></li>");
        });
    });
};

app.obtermarcas = function () {
    $.getJSON('/menu/obtermarcas', function (data) {
        $(data).each(function () {
            $(".marcas").append("<li><a href='#'>" + this.MarcaDescricao + "</a></li>");
        });
    });
};