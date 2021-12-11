$(document).ready(function () {

    $("#RegisterInto").hide();
    $("#dvcardMessage").hide()
    

    $("#btnDontAccount").click(function () {
        $('#RegisterInto').show();
        $('#LoginInto').hide();
    });

    $("#btnLoginPage").click(function () {
        $('#LoginInto').show();
        $('#RegisterInto').hide();
    });

    $("#btnRegister").click(function () {

        var user = $('#userReg').val();
        var pass = $('#passReg').val();
        var idCountry = $('#ddCountry').val();

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
            url: '/avs/Account/Validate',
            data: {
                user: user,
                pass: pass
            },
            error: function (result) {
                alert("There is a Problem, Try Again!");
            },
            success: function (result) {
                console.log(result.rol);

                var linktoGo = '';

                if (result.rol == 'Admin') {

                }
                else if (result.rol == 'Auth') {
                    linktoGo = '/avs/Home/Index'

                }
                else if (result.rol == 'Cap') {

                }
                else {
                    linktoGo = '/avs/Formularies/Form' + result.countrylog;
                }


                if (result.message == 'OK') {

                    window.location.href = linktoGo;
                }
                else {
                    alert(result.message);
                }
            }
        });
}

//function dontAccount() {
//    $("#LoginInto").hide();
//    $('#RegisterInto').show();
    
//}

//function LoginIntoData() {
//    $("#RegisterInto").fadeOut('slow');
//    $('#LoginInto').fadeIn('slow');
//}

//function Register() {

//}