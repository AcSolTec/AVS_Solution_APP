$(document).ready(function () {


    $("#btnPersonalDet").click(function () {

     //Pendiente *recuperar los values para el step personal info.

        $.ajax(
            {
                type: "POST",
                url: '/Account/SaveCustomer',
                data: {
                    RegisteredMail: user,
                    Pass: pass,
                    IdCountry: idCountry

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
                        $('#pMeesage').text(result.messagePage);
                        $("#dvcardMessage").show();
                        $('#userReg').val('');
                        $('#passReg').val('');
                        $('#ddCountry').val(0);
                        //alert(result.messagePage);
                    }
                }
            });

    });

});


function Validate() {

    var user = $('#user').val();
    var pass = $('#pass').val();

    if (user == '' && pass == '') {
        alert('Please capture user and password.');
        return;
    }

    if (user == '') {
        alert('Please capture user.');
        return;
    }


    if (pass == '') {
        alert('Please capture password.');
        return;
    }

    $.ajax(
        {
            type: "POST",
            url: '/Account/Validate',
            data: {
                user: user,
                pass: pass
            },
            error: function (result) {
                alert("There is a Problem, Try Again!");
            },
            success: function (result) {
                console.log(result);
                if (result.message == 'OK') {
                    window.location.href = '/Formularies/Form' + result.countrylog;
                }
                else {
                    alert(result.message);
                }
            }
        });
}

