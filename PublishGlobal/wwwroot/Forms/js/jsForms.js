$(document).ready(function () {

    var urlHost = '/avs';

    //PAKISTAN FORM
    $("#btnPersonalDet").click(function () {


        //Validation data 

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
                url: urlHost+'/Formularies/SavePersonalDetPakistan',
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

    $("#btnAppDetails").click(function () {



        //Validation data 





        var idForm = $('#lblidForm').text();

        var name = $('#txtNamePassport').val();
        var middName = $('#txtMiddleName').val();
        var lastName = $('#txtLastName').val();
        var dateBirth = $('#dtp_birht').val();
        var cityBirth = $('#txtCityBirth').val();
        var ddlCountry = $('#ddCountryDetails').val();

        var sex;

        if ($('#chekSexMen').is(":checked")) {
            sex = true;
        }

        if ($('#chekSexWom').is(":checked")) {
            sex = false;
        }

        var maritalStatus;

        if ($('#chekMaritalSingle').is(":checked")) {
            maritalStatus = false;
        }

        if ($('#chekMaritalMarried').is(":checked")) {
            maritalStatus = true;
        }

        var bloodGroup = $('#txtBlood').val();
        var idMark = $('#txtIdMark').val();
        var natLan = $('#txtNatLan').val();
        var religion = $('#txtReligion').val();
        var natPresent = $('#txtPresentNat').val();
        var natPrev = $('#txtPreviousNat').val();
        var natDual = $('#txtDualNat').val();


        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SaveApplicantsDetPakistan',
                data: {
                    idForm: idForm,
                    name: name,
                    middleName: middName,
                    lastName: lastName,
                    dateBirth: dateBirth,
                    cityBirth: cityBirth,
                    idCountry: ddlCountry,
                    bitSex: sex,
                    bitMarital: maritalStatus,
                    bloodGroup: bloodGroup,
                    idMark: idMark,
                    natLanguage: natLan,
                    religion: religion,
                    natPresent: natPresent,
                    natPrevious: natPrev,
                    natDual: natDual

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

    $("#btnPassportDet").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();
        var ddTypePass = $('#ddTypePass').val();
        var travelDocs;

        if ($('#chekUNTravel').is(":checked")) {
            travelDocs = true;
        }

        var passportNum = $('#passNum').val();
        var placeIssue = $('#txtIssue').val();
        var dateIssue = $('#dtp_issue').val();
        var dateExpiry = $('#dtp_Expiry').val();
        var issueAuht = $('#txtIsAuth').val();


        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SavePassportPakistan',
                data: {
                    idForm: idForm,
                    idTypePass: ddTypePass,
                    bitTravelDocs: travelDocs,
                    passportNum: passportNum,
                    placeIssue: placeIssue,
                    dateIssue: dateIssue,
                    dateExpiry: dateExpiry,
                    issueAuht: issueAuht


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

    $("#btnAddDetails").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();
        var ddCountryAdress = $('#ddCountryAdress').val();
        var phoneHome = $('#txtPhoneHome').val();
        var phoneWork = $('#txtPhoneWork').val();
        var phoneCell = $('#txtPhoneCell').val();
        var inPakist = $('#txtInPakistan').val();
        var phoneHomeb = $('#txtPhoneHomeb').val();
        var phoneWokrb = $('#txtPhoneWorkb').val();
        var phoneCellb = $('#txtPhoneCellb').val();
        var email = $('#txtEmail').val();



        var visitSponsored = false;

        if ($('#chekSponsored').is(":checked")) {
            visitSponsored = true;
        }


        var OtherSponsored = false;

        if ($('#chekSponOther').is(":checked")) {
            OtherSponsored = true;
        }


        var nameSpon = $('#txtNameSponsorA').val();
        var addSpon = $('#txtAddressA').val();
        var citySpon = $('#txtCityA').val();
        var zipCoSpon = $('#txtPCA').val();
        var telPhoneSpon = $('#txtPHomeSponsorA').val();
        var telWorkSpon = $('#txtPWorkSponsorA').val();
        var telCellSpon = $('#txtPCellSponsorA').val();


        var nameSponB = $('#txtNameSponsorB').val();
        var addSponB = $('#txtAddressB').val();
        var citySponB = $('#txtCityB').val();
        var zipCoSponB = $('#txtPCB').val();
        var telPhoneSponB = $('#txtPHomeSponsorB').val();
        var telWorkSponB = $('#txtPWorkSponsorB').val();
        var telCellSponB = $('#txtPCellSponsorB').val();


        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SaveConctactDetails',
                data: {
                    idForm: idForm,
                    idContry: ddCountryAdress,
                    telHome: phoneHome,
                    telWork: phoneWork,
                    telCell: phoneCell,
                    inPakistan: inPakist,

                    telHomeb: phoneHomeb,
                    telWorkb: phoneWokrb,
                    telCellb: phoneCellb,
                    email: email,
                    bitSponsor: visitSponsored,

                    nameSponA: nameSpon,
                    addSponA: addSpon,
                    telHomeSponA: telPhoneSpon,
                    telWorkSponA: telWorkSpon,
                    telCellSponA: telCellSpon,
                    citySponA: citySpon,
                    zipCodSponA: zipCoSpon,

                    bitSponsorB: OtherSponsored,
                    nameSponB: nameSponB,
                    addSponB: addSponB,
                    telHomeSponB: telPhoneSponB,
                    telWorkSponB: telWorkSponB,
                    telCellSponB: telCellSponB,
                    citySponB: citySponB,
                    zipCodSponB: zipCoSponB

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

    $("#btnAddPastJobs").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();

        var designation = $('#txtDesignation').val();
        var depto = $('#txtDepartament').val();
        var dateStart = $('#dtp_durFrom').val();
        var dateFinish = $('#dtp_durTo').val();
        var duties = $('#txtDuties').val();
        var nameHead = $('#txtNameHead').val();
        var address = $('#txtAdressJobs').val();
        var phoneHead = $('#txtPhoneHead').val();
        var descrip = $('#txtProvideRes').val();

        var applyVisa = false;

        if ($('#chekApp3Country').is(":checked")) {
            applyVisa = true;
        }


        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SavePastJobs',
                data: {
                    idForm: idForm,
                    designation: designation,
                    depto: depto,
                    dateStart: dateStart,
                    dateFinish: dateFinish,
                    duties: duties,
                    address: address,
                    phone: phoneHead,
                    descp: descrip,
                    bitApply: applyVisa,
                    name: nameHead

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

    $("#btnAddFamilySec1").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();

        var nMother = $('#txtNameMother').val();
        var nFather = $('#txtNameFatherr').val();
        var IdNatMother = $('#ddlNatMother').val();
        var IdNatFather = $('#ddlNatFather').val();
        var SpouseName = $('#txtNameSpouse').val();
        var IdNatSpouse = $('#ddlNatSpouse').val();
        var dateBirth = $('#dtp_BirthSpo').val();
        var placeBirth = $('#txtPlaceBirth').val();
        var profesion = $('#txtProfesion').val();
        var nameEmpSpouse = $('#txtNameEmployer').val();
        var addresEmpSpuse = $('#txtAddEmp').val();
        var telEmpSpouse = $('#txtPhoneEmp').val();

        var bitChildrens = false;

        if ($('#checkChildren').is(":checked")) {
            bitChildrens = true;
        }

        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SaveFamilyData',
                data: {
                    idForm: idForm,
                    nMother: nMother,
                    nFather: nFather,
                    idNatMother: IdNatMother,
                    idNatFather: IdNatFather,
                    spouseName: SpouseName,
                    idNatSpouse: IdNatSpouse,
                    dateBirth: dateBirth,
                    placeBirth: placeBirth,
                    profesion: profesion,
                    bitChildrens: bitChildrens,
                    nameEmpSpouse: nameEmpSpouse,
                    addresEmpSpuse: addresEmpSpuse,
                    telEmpSpouse: telEmpSpouse

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

        if (bitChildrens == true) {
            var model = [];
            var dataToSend;
            //Loop through the Table rows and build a JSON array.
            $("#tblChildrens TBODY TR").each(function () {
                var row = $(this);
                dataToSend = {
                    idForm: $('#lblidForm').text(), nameChild: row.find("TD").eq(0).html(), dateOfBirth: row.find("TD").eq(1).html()
                };

                model.push(dataToSend);
            });
            //Send the JSON array to Controller using AJAX.
            console.log(dataToSend);
            console.log(JSON.stringify(model));
            $.ajax({
                type: "POST",
                url: urlHost +"/Formularies/SaveChildrens",
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    //alert(r + " record(s) inserted.");
                }
            });
        }

    });

    $("#btnAddFamilySec2").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();
        var _nameBank = $('#txtBankName').val();
        var _branch = $('#txtBranch').val();
        var _acNumber = $('#txtAcNumber').val();
        var _address = $('#txtAddressBank').val();
        var _verifier = $('#txtVerifier').val();

        //var nMother = $('#txtNameMother').val();
        //var nFather = $('#txtNameFatherr').val();
        //var IdNatMother = $('#ddlNatMother').val();

        var checkAccomp = false;
        var checkBank = false;

        if ($('#checkAccomp').is(":checked")) {
            checkAccomp = true;
        }

        if ($('#checkBank').is(":checked")) {
            checkBank = true;
        }

        if (checkAccomp == true) {
            var model = [];
            var dataToSend;
            //Loop through the Table rows and build a JSON array.
            $("#tblAccompany TBODY TR").each(function () {
                var row = $(this);
                dataToSend = {
                    idForm: $('#lblidForm').text(), accompName: row.find("TD").eq(0).html(), dateOfBirth: row.find("TD").eq(1).html(), passportNumber: row.find("TD").eq(2).html(), address: row.find("TD").eq(3).html()
                };

                model.push(dataToSend);
            });
            //Send the JSON array to Controller using AJAX.
            //console.log(dataToSend);
            //console.log(JSON.stringify(model));
            $.ajax({
                type: "POST",
                url: urlHost +"/Formularies/SaveAccompanying",
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    //alert(r + " record(s) inserted.");
                },
                error: function (result) {
                    alert("There is a Problem, Try Again!");
                }
            });
        }

        if (checkBank == true) {


            $.ajax(
                {
                    type: "POST",
                    url: urlHost +'/Formularies/SaveBankData',
                    data: {
                        idForm: idForm,
                        nameBank: _nameBank,
                        branch: _branch,
                        acNumber: _acNumber,
                        address: _address,
                        veriefer: _verifier

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

        }


    });

    $("#btnsaveForm").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();


        var bRefused = false;
        if ($('#checkRefused').is(":checked")) {
            bRefused = true;
        }

        var bRefusedEntry = false;
        if ($('#checkRefusedEntry').is(":checked")) {
            bRefusedEntry = true;
        }

        var detRefusal = $('#txtDetailsRefusal').val();

        var bDeported = false;

        if ($('#checkDeported').is(":checked")) {
            bDeported = true;
        }


        var datDeport = $('#dtp_Deported').val();
        var ddCountryDeport = $('#ddCountryDeport').val();
        var reasonDep = $('#txtReasonDepo').val();
        var refenceNumber = $('#txtrefNumberDepo').val();

        if (bDeported == true) {

            //call deported data 
            $.ajax(
                {
                    type: "POST",
                    url: urlHost +'/Formularies/SaveTravelDeported',
                    data: {
                        idForm: idForm,
                        dateDeport: datDeport,
                        idCountry: ddCountryDeport,
                        reason: reasonDep,
                        referenceNum: refenceNumber
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
        }

        var bCriminal = false;
        if ($('#checkCriminal').is(":checked")) {
            bCriminal = true;
        }

        var datConviction = $('#dtp_Criminal').val();
        var ddCountryConvic = $('#ddCountryConviction').val();
        var offen = $('#txtOffenceCriminal').val();
        var sentence = $('#txtSentence').val();

        if (bCriminal == true) {

            //call conviction data 
            $.ajax(
                {
                    type: "POST",
                    url: urlHost +'/Formularies/SaveTravelConviction',
                    data: {
                        idForm: idForm,
                        dateConviction: datConviction,
                        idCountry: ddCountryConvic,
                        offence: offen,
                        sentence: sentence

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
        }


        //call travel data 
        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SaveBitsTravles',
                data: {
                    idForm: idForm,
                    bitRefused: bRefused,
                    bitRefusedPakistan: bRefusedEntry,
                    bitRemoveCountry: bDeported,
                    bitConviction: bCriminal,
                    detailRefusal: detRefusal

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


        var visited5years = false;

        if ($('#checkLast5Years').is(":checked")) {
            visited5years = true;
        }


        if (visited5years == true) {
            var model = [];
            var dataToSend;
            //Loop through the Table rows and build a JSON array.
            $("#tblVisitedLast5 TBODY TR").each(function () {
                var row = $(this);
                dataToSend = {
                    idForm: $('#lblidForm').text(), dateTravel: row.find("TD").eq(0).html(), address: row.find("TD").eq(1).html(), purpose: row.find("TD").eq(2).html(), duration: row.find("TD").eq(3).html()
                };

                model.push(dataToSend);
            });
            //Send the JSON array to Controller using AJAX.
            //console.log(dataToSend);
            //console.log(JSON.stringify(model));
            $.ajax({
                type: "POST",
                url: urlHost +"/Formularies/SaveTravelLast5",
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    //alert(r + " record(s) inserted.");
                },
                error: function (result) {
                    alert("There is a Problem, Try Again!");
                }
            });
        }


        var model = [];
        var dataToSend;
        //Loop through the Table rows and build a JSON array.
        $("#tblVisitedLast2 TBODY TR").each(function () {
            var row = $(this);
            dataToSend = {
                idForm: $('#lblidForm').text(), dateTravel: row.find("TD").eq(0).html(), address: row.find("TD").eq(1).html(), purpose: row.find("TD").eq(2).html(), duration: row.find("TD").eq(3).html()
            };

            model.push(dataToSend);
        });
        //Send the JSON array to Controller using AJAX.
        //console.log(dataToSend);
        //console.log(JSON.stringify(model));
        $.ajax({
            type: "POST",
            url: urlHost +"/Formularies/SaveTravelLast2",
            data: JSON.stringify(model),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
                //alert(r + " record(s) inserted.");
            },
            error: function (result) {
                alert("There is a Problem, Try Again!");
            }
        });

        //location.reload();

    });


    $("body").on("click", "#btnAdd", function () {
        //Reference the Name and Country TextBoxes.
        var txtName = $("#txtNameChild");
        var txtCountry = $("#txtBirthChild");

        //Get the reference of the Table's TBODY element.
        var tBody = $("#tblChildrens > TBODY")[0];

        //Add Row.
        var row = tBody.insertRow(-1);

        //Add Name cell.
        var cell = $(row.insertCell(-1));
        cell.html(txtName.val());

        //Add Country cell.
        cell = $(row.insertCell(-1));
        cell.html(txtCountry.val());

        //Add Button cell.
        cell = $(row.insertCell(-1));
        var btnRemove = $("<input />");
        btnRemove.attr("type", "button");
        btnRemove.attr("onclick", "Remove(this);");
        btnRemove.attr("class", "btn btn-danger")
        btnRemove.val("Remove");
        cell.append(btnRemove);

        //Clear the TextBoxes.
        txtName.val("");
        txtCountry.val("");
    });

    //Accompanying's
    $("body").on("click", "#btnAddAccomp", function () {
        //Reference the Name and Country TextBoxes.
        var txtName = $("#txtNameAccom");
        var txtBirhtA = $("#txtBirthAccom");
        var txtPassNum = $("#txtPassportNumAccom");
        var txtAddressAccomp = $("#txtAddressAccom");
        //Get the reference of the Table's TBODY element.
        var tBody = $("#tblAccompany > TBODY")[0];

        //Add Row.
        var row = tBody.insertRow(-1);

        //Add Name cell.
        var cell = $(row.insertCell(-1));
        cell.html(txtName.val());

        //Add Country cell.
        cell = $(row.insertCell(-1));
        cell.html(txtBirhtA.val());

        cell = $(row.insertCell(-1));
        cell.html(txtPassNum.val());

        cell = $(row.insertCell(-1));
        cell.html(txtAddressAccomp.val());

        //Add Button cell.
        cell = $(row.insertCell(-1));
        var btnRemove = $("<input />");
        btnRemove.attr("type", "button");
        btnRemove.attr("onclick", "RemoveAccom(this);");
        btnRemove.attr("class", "btn btn-danger")
        btnRemove.val("Remove");
        cell.append(btnRemove);

        //Clear the TextBoxes.
        txtName.val("");
        txtBirhtA.val("");
        txtPassNum.val("");
        txtAddressAccomp.val("");
    });

    //Visited pakistan last 5 years
    $("body").on("click", "#btnAddVisitedL5", function () {
        //Reference the Name and Country TextBoxes.
        var txtdateLast5 = $("#txtDateLast5");
        var txtdestinLast5 = $("#txtDestinLast5");
        var txtpurposeLast5 = $("#txtPurposeLast5");
        var txtdurationLast5 = $("#txtDurationLast5");
        //Get the reference of the Table's TBODY element.
        var tBody = $("#tblVisitedLast5 > TBODY")[0];

        //Add Row.
        var row = tBody.insertRow(-1);

        //Add Name cell.
        var cell = $(row.insertCell(-1));
        cell.html(txtdateLast5.val());

        //Add Country cell.
        cell = $(row.insertCell(-1));
        cell.html(txtdestinLast5.val());

        cell = $(row.insertCell(-1));
        cell.html(txtpurposeLast5.val());

        cell = $(row.insertCell(-1));
        cell.html(txtdurationLast5.val());

        //Add Button cell.
        cell = $(row.insertCell(-1));
        var btnRemove = $("<input />");
        btnRemove.attr("type", "button");
        btnRemove.attr("onclick", "RemoveLast5(this);");
        btnRemove.attr("class", "btn btn-danger")
        btnRemove.val("Remove");
        cell.append(btnRemove);

        //Clear the TextBoxes.
        txtdateLast5.val("");
        txtdestinLast5.val("");
        txtpurposeLast5.val("");
        txtdurationLast5.val("");
    });

    //Visited pakistan last 2 years
    $("body").on("click", "#btnAddVisitedL2", function () {
        //Reference the Name and Country TextBoxes.
        var txtdateLast2 = $("#txtDateLast2");
        var txtdestinLast2 = $("#txtDestinLast2");
        var txtpurposeLast2 = $("#txtPurposeLast2");
        var txtdurationLast2 = $("#txtDurationLast2");
        //Get the reference of the Table's TBODY element.
        var tBody = $("#tblVisitedLast2 > TBODY")[0];

        //Add Row.
        var row = tBody.insertRow(-1);

        //Add Name cell.
        var cell = $(row.insertCell(-1));
        cell.html(txtdateLast2.val());

        //Add Country cell.
        cell = $(row.insertCell(-1));
        cell.html(txtdestinLast2.val());

        cell = $(row.insertCell(-1));
        cell.html(txtpurposeLast2.val());

        cell = $(row.insertCell(-1));
        cell.html(txtdurationLast2.val());

        //Add Button cell.
        cell = $(row.insertCell(-1));
        var btnRemove = $("<input />");
        btnRemove.attr("type", "button");
        btnRemove.attr("onclick", "RemoveLast2(this);");
        btnRemove.attr("class", "btn btn-danger")
        btnRemove.val("Remove");
        cell.append(btnRemove);

        //Clear the TextBoxes.
        txtdateLast2.val("");
        txtdestinLast2.val("");
        txtpurposeLast2.val("");
        txtdurationLast2.val("");
    });


    //CUBA FORM
    $("#btnAddCuContact").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();

        var firstNameCu = $('#txtNameCu').val();
        var surNameCu = $('#txtSurname').val();
        var addressCu = $('#txtAddressCu').val();
        var zipeCode = $('#txtZipeCode').val();
        var townCu = $('#txtTownCu').val();
        var mailCu = $('#txtMailCu').val();
        var numeroTelCu = $('#txtNumeroTel').val();


        if (firstNameCu == '' || surNameCu == '' || addressCu == '' || zipeCode == ''
            || townCu == '' || mailCu == '' || numeroTelCu == '') {
            alert('Please capture the required fields');
            return;
        }


        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SaveConctactDetCuba',
                data: {
                    idForm: idForm,
                    firstName: firstNameCu,
                    surName: surNameCu,
                    address: addressCu,
                    zipCode: zipeCode,
                    town: townCu,
                    emailAddress: mailCu,
                    telNum: numeroTelCu

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

    $('#dvformDifAddress').hide();

    $('#chekShipYes').change(function () {
        if (this.checked)
            $('#dvformDifAddress').fadeIn('slow');

    });

    $('#checkShipNo').change(function () {
        if (this.checked)
            $('#dvformDifAddress').fadeOut('slow');

    });

    $("#btnAddTripShip").click(function () {

        //Validation data 

        var idForm = $('#lblidForm').text();

        var dateEntryCuba = $('#dtp_EntryCuba').val();
        var dateDeparture = $('#dtp_DepartureCuba').val();
        var ddlNumAdults = $('#ddAdults').val();
        var ddlChildren = $('#ddChildren').val();
        var bShipDiff = false;

        var surNameShip = '';
        var firstNameShip = '';
        var addressShipDif = '';
        var zipCodeShip = '';
        var townShip = '';

        if ($('#chekShipYes').is(":checked")) {
            bShipDiff = true;
            
        }
        if ($('#checkShipNo').is(":checked")) {
            bShipDiff = false;
            
        }

        if (bShipDiff == true) {
            surNameShip = $('#txtSurNameDifAdd').val();
            firstNameShip = $('#txtNameDifAd').val();
            addressShipDif = $('#txtAddressDifAd').val();
            zipCodeShip = $('#txtZPDifAd').val();
            townShip = $('#txtTownShipDif').val();
        }
       

        var bppchf5 = false;
        var brschf750 = false;
        var beschf22 = false;
        var bNatInt = false;

        if ($('#chekch5').is(":checked")) {
            bppchf5 = true;
        }

        if ($('#chekch7').is(":checked")) {
            brschf750 = true;
        }

        if ($('#chek22').is(":checked")) {
            beschf22 = true;
        }

        if ($('#chekNatInt').is(":checked")) {
            bNatInt = true;
        }



        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SaveTripShippCuba',
                data: {
                    idForm: idForm,
                    dateEntry: dateEntryCuba,
                    dateDeparture: dateDeparture,
                    numAdults: ddlNumAdults,
                    numChildrens: ddlChildren,
                    passportAdult: passportAdult,
                    passportChil: passportChild,
                    bitShippDifferent: bShipDiff,
                    bitPPchf5: bppchf5,
                    bitRSchf750: brschf750,
                    bitESchf22: beschf22,
                    bitCourrierNatInt: bNatInt,
                    surNameShip: surNameShip,
                    firstNameShip: firstNameShip,
                    addressShip: addressShipDif,
                    zipCodeShip: zipCodeShip,
                    townShip: townShip

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




        var passportAdult;
        var passportChild;

        var formData = new FormData();
        formData.append('files', $('#fuPassAdult')[0].files[0]);
        formData.append('files', $('#fuPassChild')[0].files[0]);
        formData.append('idForm', idForm);

       $.ajax(
            {
                type: "POST",
                url: 'http://localhost/avs_api/api/cuba/recieveImagesCuba',
                data: formData,
                processData: false,
                contentType: false,
                error: function (result) {
                    //alert("There is a Problem, Try Again!");
                },
                success: function (result) {
                    console.log('resultado ' + result);
                    if (result.message == 'OK') {
                        //window.location.href = '/Formularies/Login';
                    }
                    else {
                        alert(result.messagePage);
                    }
                }
            });


       
    });

    $("#btnAddSummary").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();

        var comments = $('#txtComments').val();

        var bitRead = false;

        if ($('#checkRead').is(":checked")) {
            bitRead = true;
        }

        var bitGTC = false;

        if ($('#checkGTC').is(":checked")) {
            bitGTC = true;
        }



        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SaveSummary',
                data: {
                    idForm: idForm,
                    comments: comments,
                    bitReadSuccess: bitRead,
                    bitReadGTC: bitGTC

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


    //FORM SOUTH KOREA
    $("#btnAddSKPI").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();
        var idCountrySK = $('#ddCountrySK').val();
        var firstNamesk = $('#txtSurnameSK').val();
        var surNamesk = $('#txtGiveName').val();
        var bitSex = false;
        if ($('#checkMale').is(":checked")) {
            bitSex = true;
        }

        var bitSurUk = false;
        if ($('#checkSurUk').is(":checked")) {
            bitSurUk = true;
        }

        var bitNameUk = false;
        if ($('#checkNameUk').is(":checked")) {
            bitNameUk = true;
        }

        var passNumSK = $('#txtPassportNumber').val();
        var dateBirthSK = $('#dtp_dtSK').val();
        var dateExpiredSK = $('#dtp_dtEXPSK').val();



        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SavePersonalInfo',
                data: {
                    idForm: idForm,
                    idCountry: idCountrySK,
                    name: firstNamesk,
                    surName: surNamesk,
                    bitSex: bitSex,
                    BitNameUk: bitNameUk,
                    bitSurNamUk: bitSurUk,
                    passNum: passNumSK,
                    dateBirth: dateBirthSK,
                    dateExpired: dateExpiredSK

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

    $("#btnAddSKIR").click(function () {


        //Validation data 

        var idForm = $('#lblidForm').text();

        var bitOther = false;
        if ($('#checkYesAn').is(":checked")) {
            bitOther = true;
        }

        var ddlCountryOther = $('#ddCountryOtherSK').val();

        var mobNumber = $('#txtMobNum').val();

        var bitVisitedKo = false;
        if ($('#checkVisitedUkYes').is(":checked")) {
            bitVisitedKo = true;
        }

        var ddlPurposeSK = $('#ddPurposeSK').val();

        var sponsorName = $('#txtSponsorSK').val();
        var AddNumSpon = $('#txtAddNumberSK').val();
        var zipCodeSK = $('#txtZipCodeSK').val();
        var citySK = $('#txtCitySK').val();
        var numberKorea = $('#txtNumberKorea').val();
        var ddlJobSK = $('#ddlCurrentJob').val();

        var bitInfected = false;
        if ($('#checkYesInfected').is(":checked")) {
            bitInfected = true;
        }

        var bitArrested = false;
        if ($('#checkArresYes').is(":checked")) {
            bitArrested = true;
        }

        



        $.ajax(
            {
                type: "POST",
                url: urlHost +'/Formularies/SaveInformationReq',
                data: {
                    idForm: idForm,
                    bitOtherNat: bitOther,
                    mobileNumber: mobileNumber,
                    bitVisitedKorea: bitVisitedKo,
                    idCountry: ddlCountryOther,
                    postalCode: '',
                    addressPostal: '',
                    numberContactKorea: numberKorea,
                    IdJob: ddlJobSK,
                    BitInfectiuos15: bitInfected,
                    BitArrested: bitArrested,
                    sponsorName: sponsorName,
                    addressNumber: AddNumSpon,
                    zipCode: zipCodeSK,
                    city: citySK,
                    IdPurposeSK: ddlPurposeSK

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


function Remove(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete: " + name)) {
        //Get the reference of the Table.
        var table = $("#tblChildrens")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};

function RemoveAccom(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete: " + name)) {
        //Get the reference of the Table.
        var table = $("#tblAccompany")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};

function RemoveLast5(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete: " + name)) {
        //Get the reference of the Table.
        var table = $("#tblVisitedLast5")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};

function RemoveLast2(button) {
    //Determine the reference of the Row using the Button.
    var row = $(button).closest("TR");
    var name = $("TD", row).eq(0).html();
    if (confirm("Do you want to delete: " + name)) {
        //Get the reference of the Table.
        var table = $("#tblVisitedLast2")[0];

        //Delete the Table row using it's Index.
        table.deleteRow(row[0].rowIndex);
    }
};

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
            url: urlHost +'/Account/Validate',
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

