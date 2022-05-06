
    //var urlHost = '/avs';
    var urlHost = '';

    $("#btnLogOut").click(function () {
        $.ajax(
            {
                type: "POST",
                url: urlHost + '/Account/logOutSesession',
                data: {
                },
                error: function (result) {
                    alert("There is a Problem, Try Again!");
                },
                success: function (result) {
                    console.log(result);
                    if (result.message == 'OK') {
                        window.location.href = '/Account/Login';
                    }
                    else {
                        alert(result.message);
                    }
                }
            });
        });
