$('#myForm').submit(function (e) {
    e.preventDefault();
}).validate({
    rules: {
        inputEmail: {
            required: true,
            email: true
        },
        password: "required"
    },
    messages: {
        inputEmail: {
            required: "Email is required",
            email: "Enter valid email address"
        },
        password: "Password is required"
    },
    submitHandler: function (form) {
        $('#loginSpinner').show();
        $('#btnLogin').prop('disabled', true);
        var form = new FormData();
        form.append("Email", $('#inputEmail').val());
        form.append("Password", $('#password').val());

        var settings = {
            "url": "/api/Login",
            "method": "POST",
            "timeout": 0,
            "processData": false,
            "mimeType": "multipart/form-data",
            "contentType": false,
            "data": form,
            statusCode: {
                404: function (response) {
                    $("#alert1Top").show();
                    window.setTimeout(function () {
                        $("#alert1Top").hide();
                    }, 2000);
                    $('#loginSpinner').hide();
                    $('#btnLogin').prop('disabled', false);
                },
                403: function (response) {
                    $("#alert1Top").show();
                    window.setTimeout(function () {
                        $("#alert1Top").hide();
                    }, 2000);
                    $('#loginSpinner').hide();
                    $('#btnLogin').prop('disabled', false);
                }
            }
        };

        $.ajax(settings).done(function (data, statusText, xhr) {

            if (xhr.status === 200) {
                var res = JSON.parse(data);
                localStorage.setItem("token", res.token);
                var role = parseJwt(res.token)["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                if (role == "Admin")
                    window.location.replace('/Admin/Dashboard/Dashboard');
                else
                    window.location.replace('/User/Home/Index');
                // console.log(role);
            } else {
                $("#alert1Top").show();
                window.setTimeout(function () {
                    $("#alert1Top").hide();
                }, 2000);
                $('#loginSpinner').hide();
                $('#btnLogin').prop('disabled', false);
            }
        });

    }
});

function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
};