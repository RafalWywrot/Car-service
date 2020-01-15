(function ($) {
    $(".changeToVerify").click(function () {
        var url = $(this).attr('data-url');
        var id = $(this).attr('data-id');
        $.ajax({
            url: url,
            type: 'POST',
            data: {
                'bookingServiceId': id
            },
            success: function (result) {
                if (result.Success) {
                    alert('ok');
                    setTimeout(function () {
                        location.reload();  //Refresh page
                    }, 100);
                }
                else {
                    alert(result.Message);
                }
            },
            error: function (xhr) {
                alert('Error');
            }
        });
    });

    $(".changeToAccept").click(function () {
        var url = $(this).attr('data-url');
        var id = $(this).attr('data-id');
        $.ajax({
            url: url,
            type: 'POST',
            data: {
                'bookingServiceId': id
            },
            success: function (result) {
                if (result.Success) {
                    alert('ok');
                    setTimeout(function () {
                        location.reload();  //Refresh page
                    }, 100);
                }
                else {
                    alert(result.Message);
                }
            },
            error: function (xhr) {
                alert('Error');
            }
        });
    });

    $(".changeToDecline").click(function () {
        var url = $(this).attr('data-url');
        var id = $(this).attr('data-id');
        $.ajax({
            url: url,
            type: 'POST',
            data: {
                'bookingServiceId': id
            },
            success: function (result) {
                if (result.Success) {
                    alert('ok');
                    setTimeout(function () {
                        location.reload();  //Refresh page
                    }, 100);
                }
                else {
                    alert(result.Message);
                }
            },
            error: function (xhr) {
                alert('Error');
            }
        });
    });

    $(".changeToInProgress").click(function () {
        var url = $(this).attr('data-url');
        var id = $(this).attr('data-id');
        $.ajax({
            url: url,
            type: 'POST',
            data: {
                'bookingServiceId': id
            },
            success: function (result) {
                if (result.Success) {
                    alert('ok');
                    setTimeout(function () {
                        location.reload();  //Refresh page
                    }, 100);
                }
                else {
                    alert(result.Message);
                }
            },
            error: function (xhr) {
                alert('Error');
            }
        });
    });


    $(".changeToFinished").click(function () {
        var url = $(this).attr('data-url');
        var id = $(this).attr('data-id');
        $.ajax({
            url: url,
            type: 'POST',
            data: {
                'bookingServiceId': id
            },
            success: function (result) {
                if (result.Success) {
                    alert('ok');
                    setTimeout(function () {
                        location.reload();  //Refresh page
                    }, 100);
                }
                else {
                    alert(result.Message);
                }
            },
            error: function (xhr) {
                alert('Error');
            }
        });
    });
})(jQuery);