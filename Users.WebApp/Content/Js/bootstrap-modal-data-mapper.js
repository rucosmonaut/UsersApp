$(".modal").on('shown.bs.modal', function (e) {
    var dataAttributes = $(e.relatedTarget).data();

    (function () {
        var valueElements = $(e.currentTarget).find("[modal-data-value]");

        for (var i = 0; i < valueElements.length; i++) {
            var elem = $(valueElements[i]);
            $(elem).val(
                dataAttributes[elem.attr("modal-data-value")]);
        }
    }());

    (function () {
        var textNodeElements = $(e.currentTarget).find("[modal-data-inner-text]");
        for (var i = 0; i < textNodeElements.length; i++) {
            var elem = $(textNodeElements[i]);
            $(elem).html(
                dataAttributes[elem.attr("modal-data-inner-text")]);
        }
    }());
});