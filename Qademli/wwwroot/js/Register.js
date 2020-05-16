$('#myForm').submit(function (e) {
    e.preventDefault();
}).validate({
    rules: {
        firstName: "required",
        inputEmail: {
            required: true,
            email: true
        },
        password: "required",
        confirmPassword: { equalTo: "#password" }
    },
    messages: {
        firstName : "First Name is required",
        inputEmail: {
            required: "Email is required",
            email: "Enter valid email address"
        },
        password: "Password is required",
        confirmPassword: "Password did not matched"
    },
    submitHandler: function (form) {
        $('#loginSpinner').show();
        $('#btnRegister').prop('disabled', true);
        var form = new FormData();
        form.append("FirstName", $('#firstName').val());
        form.append("MiddleName", $('#inputEmail').val());
        form.append("LastName", $('#middleName').val());
        form.append("Email", $('#inputEmail').val());
        form.append("Password", $('#password').val());

        var settings = {
            "url": "/api/Register",
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
                    $('#btnRegister').prop('disabled', false);
                }
            }
        };

        $.ajax(settings).done(function (data, statusText, xhr) {

            if (xhr.status === 201) {
                window.location.replace('/Account/Login/Login');
            } else {
                $("#alert1Top").show();
                window.setTimeout(function () {
                    $("#alert1Top").hide();
                }, 2000);
                $('#loginSpinner').hide();
                $('#btnRegister').prop('disabled', false);
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