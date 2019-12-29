(function ($) {
    var dateInput = $("#dateOfService");
    $(".radioButtonAsSoon").click(function () {
        dateInput.addClass("hidden");
    });
    $(".radioButtonSelectDate").click(function () {
        dateInput.removeClass("hidden");
    });
})(jQuery);