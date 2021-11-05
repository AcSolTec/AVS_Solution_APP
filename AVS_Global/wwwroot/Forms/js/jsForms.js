$(document).ready(function () {


    $("#btnPersonalDet").click(function () {


        var idForm = $('#lblidForm').text();

        var ddlVisaAp = $('#ddVisaApp').val();
        var ddlPurpose = $('#ddPurpose').val();
        var durationStay = $('#txtDurationStay').val();
        var ddVisasTime = $('#ddVisasTime').val();
        var ddTypeVisa = $('#ddTypeVisa').val();
        var ddPortIn = $('#ddPortIn').val();
        var ddPortOut = $('#ddPortOut').val();
        var PlacesVisited = $('#txtPlacesVisited').val();
        var DetProfesion = $('#txtDetailsProfesion').val();




        $.ajax(
            {
                type: "POST",
                url: '/Formularies/SavePersonalDetPakistan',
                data: {
                    idForm: idForm,
                    idVisaAp: ddlVisaAp,
                    idPurpose: ddlPurpose,
                    durationStay: durationStay,
                    idVisasTime: ddVisasTime,
                    idTypeVisa: ddTypeVisa,
                    idPortsIn: ddPortIn,
                    idPortsOut: ddPortOut,
                    pvPakistan: PlacesVisited,
                    dOfProfesion: DetProfesion

                },
                error: function (result) {
                    alert("There is a Problem, Try Again!");
                },
                success: function (result) {
                    console.log(result);
                    if (result.message == 'OK') {
                        //window.location.href = '/Formularies/Login';
                    }
                    else {

                        alert(result.messagePage);
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

