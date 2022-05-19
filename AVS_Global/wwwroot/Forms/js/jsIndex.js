//var urlHost = '/avs';
var urlHost = '';

$(document).ready(function () {



    $("#btnAddCountry").click(function () {

        var idCountry = $('#ddCountry').val();

        var user = $('#lblUser').text();


        $.ajax(
            {
                type: "POST",
                url: urlHost + '/Formularies/AddNewCountryFormForCustomer',
                data: {
                    IdCountry: idCountry,
                    account: user

                },
                error: function (result) {
                    //alert("There is a Problem, Try Again!");
                    console.log(result.message);
                    $('#dvcardMessage').show();
                    $('#pMeesage').text(result.message);
                    
                },
                success: function (result) {


                    if (result.estatus == 'OK') {
                        console.log(result);
                        location.reload();
                        $('#dvCardSuccess').show();
                        $('#pMeesageSuc').text(result.message);

                    }
                    else {
                        $('#dvcardMessage').show();
                        $('#pMeesage').text(result.message);
                    }

                }
            });


    });

});