//var urlHost = '/avs';
var urlHost = '';

$(document).ready(function () {

    if ($('#rdOnline').click(function () {

        //replace names of customer
        var enReqPayment = {

        };


        $.ajax(
            {
                type: "POST",
                url: urlHost + '/Formularies/SubmitRequest',
                data: enReqPayment,
                dataType: 'json',
                error: function (result) {
                    alert('Online payment not available.');
                    console.log(result);
                },
                success: function (result) {

                    var d = JSON.parse(result);
                    $("#frmOnlineBuy").attr('src', d.RedirectUrl);
                }
            });


    }));



    $(window).bind('message', function (e) {
        switch (e.originalEvent.data.message) {
            case 'css':
                $('#iframe').css('height', e.originalEvent.data.height + "px");
                break;
        }
    });


});


