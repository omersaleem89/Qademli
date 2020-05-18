$(() => {
    LoadData(localStorage.getItem("token"));
    LoadStatus();
});

var LoadStatus = () => {
    $.ajax({
        type: "GET",
        url: "/api/ApplicationStatus",
        data: "{}",
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        success: function (data) {
            var s = '<option value="">Select Status</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].Name + '</option>';
            }
            $("#status").html(s);
        }
    });
}

var LoadData = (token) => {
    var settings = {
        "url": "/api/Application",
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + token
        },
        error: function (jqXHR, textStatus, errorThrown) { window.location.replace('/Account/Login/Login'); }
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
            console.log(data);
            $('#tBody').empty();
            if (data.length > 0) {
                $.each(data, function (index, item) {
                    var str = `<tr>
                                <td class="align-middle text-center">${index + 1}</td>
                                <td class="align-middle text-center">${item.User}</td>
                                <td class="align-middle text-center">${item.Topic}</td>
                                <td class="align-middle text-center">${item.Goal}</td>
                                <td class="align-middle text-center">${item.Comment}</td>
                                <td class="align-middle text-center">${moment(item.Date).format("DD MMM, YYYY")}</td>
                                <td class="align-middle text-center">${item.Fee} ${item.Currency}</td>
                                <td class="align-middle text-center">${item.ApplicationStatus}</td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="updateModal('${item.ID}','${item.GoalID}','${item.StatusID}','${item.TopicID}','${item.UserID}','${item.Comment}','${item.Fee}','${item.Currency}')">Update</button>
                                    <button class="btn btn-danger" >View</button>
                                </td>
                            </tr>`;
                    $('#tBody').append(str);
                });

            }
        } else {
            window.location.replace('/Account/Login/Login');
        }
    });
}

let updateModal = (ID, GoalID, StatusID, TopicID, UserID, Comment, Fee, Currency) => {
    $('#myModal').modal('show');
    $('#status').val(StatusID);
    $('#comment').val(Comment);
    $('#appid').val(ID);
}

$(() => {

    //Update Application
    $('#myModal form').validate({
        rules: {
            comment: "required",
            status: "required"
        },
        messages: {
            comment: "Choose Comment",
            status: "Choose Status"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("Comment", $('#comment').val());
            form.append("StatusID", $('#status').val());

            var settings = {
                "url": "/api/Application/" + $('#appid').val(),
                "method": "PUT",
                "timeout": 0,
                "processData": false,
                "mimeType": "multipart/form-data",
                "contentType": false,
                "data": form,
                "headers": {
                    "Authorization": "Bearer " + localStorage.getItem("token")
                }
            };

            $.ajax(settings).done(function (data, statusText, xhr) {
                if (xhr.status === 204) {
                    LoadData(localStorage.getItem("token"));
                    $('#myModal').modal('hide');
                    // console.log(data);
                } else {
                    window.location.replace('/Account/Login/Login');
                }
            });

        }
    });
})