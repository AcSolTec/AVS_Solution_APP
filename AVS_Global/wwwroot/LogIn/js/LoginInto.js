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
                    window.location.href = '/Home/Index';
                }
                else {
                    alert(result.message);
                }
            }
        });
}