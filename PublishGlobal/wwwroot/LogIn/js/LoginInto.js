//var urlHost = '/avs';
var urlHost = '';

$(document).ready(function () {



    function validateAccount(valor) {
        if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(valor)) {
            console.log("La dirección de email " + valor + " es correcta!.");
        } else {
            console.log("La dirección de email es incorrecta!.");
        }
    }

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


        if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(user)) {
            
        } else {
            $('#pMeesage').text('Incorrect account e-mail.');
            $("#dvcardMessage").show();
            return;
        }

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
                url: urlHost + '/Account/SaveCustomer',
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
                        window.location.href = urlHost + '/Account/Login';
                    }
                    else {
                        $('#pMeesage').text(result.messagePage);
                        $("#dvcardMessage").show();
                        $('#userReg').val('');
                        $('#passReg').val('');
                        $('#passConfirmReg').val('');
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
            url: urlHost+'/Account/Validate',
            data: {
                user: user,
                pass: pass
            },
            error: function (result) {
                alert("There is a Problem, Try Again!");
                console.log(urlHost + '/Account/SaveCustomer');
            },
            success: function (result) {
                console.log(result.rol);
                console.log(urlHost + '/Account/SaveCustomer');
                var linktoGo = '';

                if (result.rol == 'Admin') {

                }
                else if (result.rol == 'Auth') {
                    linktoGo = urlHost+'/Home/Index'

                }
                else if (result.rol == 'Cap') {

                }
                else {
                    //linktoGo = '/Formularies/Form' + result.countrylog;
                    linktoGo = urlHost +'/Formularies/Index';
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