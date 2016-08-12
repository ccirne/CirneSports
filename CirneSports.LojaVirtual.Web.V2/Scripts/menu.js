var app = {};

$(function () {
    app.inicializar();
});

app.inicializar = function () {
    $('#main-menu').smartmenus();
    app.obteresportes();
}

app.obteresportes = function () {
    $.getJSON('/menu/obteresportes', function (data) {
        $(data).each(function () {
            $("#esportes").append("<li><a href='#'>" + this.CategoriaDescricao + "</a></li>");
        });
    });
};