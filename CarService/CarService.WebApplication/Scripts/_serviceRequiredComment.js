(function ($) {
    var checkBoxRequiredComment = $(".adminServiceCheckboxComment");
    $(".adminServiceCheckboxComment").click(function () {
        $(".adminServiceMessageComment").toggleClass('hidden');
    });
})(jQuery);