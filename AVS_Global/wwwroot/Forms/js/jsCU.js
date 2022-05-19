$(document).ready(function () {


  

    $("#btnPassAdult").click(function () {

        $('#btnMessagePage').click();


    });

    $("#btnPassChild").click(function () {

        $('#btnPopChil').click();


    });




    $("#btnUploadPassAd").click(function () {

        var passportAdult;

        var formData = new FormData();
        formData.append('files', $('#fuPassAdult')[0].files[0]);
        formData.append('files', $('#fuPassAdult1')[0].files[0]);
        formData.append('files', $('#fuPassAdult2')[0].files[0]);
        formData.append('files', $('#fuPassAdult3')[0].files[0]);
        formData.append('files', $('#fuPassAdult4')[0].files[0]);
        formData.append('files', $('#fuPassAdult5')[0].files[0]);

        var idForm = $('#lblidForm').text();

        $.ajax(
            {
                type: "POST",
                url: '/Formularies/ReqPassportsAdults?idForm=' + idForm,
                data: formData,
                processData: false,
                contentType: false,
                error: function (result) {
                    //alert("There is a Problem, Try Again!");
                },
                success: function (result) {
                    console.log('resultado ' + result);
                  
                }
            });


    });


    $("#btnUploadPassCh").click(function () {

        var passportAdult;

        var formDataCH = new FormData();
        formDataCH.append('files', $('#fuPassChild')[0].files[0]);
        formDataCH.append('files', $('#fuPassChild1')[0].files[0]);
        formDataCH.append('files', $('#fuPassChild2')[0].files[0]);
        formDataCH.append('files', $('#fuPassChild3')[0].files[0]);
        formDataCH.append('files', $('#fuPassChild4')[0].files[0]);

        var idForm = $('#lblidForm').text();

        $.ajax(
            {
                type: "POST",
                url: '/Formularies/ReqPassportsAChildrens?idForm=' + idForm,
                data: formDataCH,
                processData: false,
                contentType: false,
                error: function (result) {
                    //alert("There is a Problem, Try Again!");
                },
                success: function (result) {
                    console.log('resultado ' + result);
                    
                }
            });


    });

  

});