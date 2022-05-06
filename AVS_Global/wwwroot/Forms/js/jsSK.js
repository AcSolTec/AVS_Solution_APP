
$(document).ready(function () {
 
    $('#culture option:contains("Spanish (Mexico)")').attr("style", "display:none");
    $('#culture option:contains("French (France)")').attr("style", "display:none");
    $('#culture option:contains("German (Germany)")').attr("style", "display:none");
});

$('#dtBirthSK').datetimepicker({
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 2,
    minView: 2,
    forceParse: 0
});

$('#dtExpiredSK').datetimepicker({
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 2,
    minView: 2,
    forceParse: 0
});


function onlyOneArres(checkbox) {
    var checkboxes = document.getElementsByName('checkArres');
    checkboxes.forEach((item) => {
        if (item !== checkbox) item.checked = false
    });
}

function onlyOneCUSU(checkbox) {
    var checkboxes = document.getElementsByName('checkcusu');
    checkboxes.forEach((item) => {
        if (item !== checkbox) item.checked = false
    });
}

function onlyOneYesNop(checkbox) {
    var checkboxes = document.getElementsByName('checkhVisi');
    checkboxes.forEach((item) => {
        if (item !== checkbox) item.checked = false
    });
}

function onlyOneSex(checkbox) {
    var checkboxes = document.getElementsByName('checkMF');
    checkboxes.forEach((item) => {
        if (item !== checkbox) item.checked = false
    });
}

function onlyOneOtCo(checkbox) {
    var checkboxes = document.getElementsByName('checkAC');
    checkboxes.forEach((item) => {
        if (item !== checkbox) item.checked = false
    });
}