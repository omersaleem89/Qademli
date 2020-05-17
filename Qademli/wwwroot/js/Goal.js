$(() => {
    LoadData(localStorage.getItem("token")); 
    LoadTopic("topic1","");
});

var LoadTopic = (id,topicid) => {
    $.ajax({
        type: "GET",
        url: "/api/Topic",
        data: "{}",
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        success: function (data) {
            var s = '<option value="">Select Topic</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].Name + '</option>';
            }
            $("#" + id).html(s);
            $("#" + id).val(topicid);
        }
    });  
}

var LoadData = (token) => {
    var settings = {
        "url": "/api/Goal/GetGoalWithTopic",
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
                                <td class="align-middle text-center">${item.Name}</td>
                                <td class="align-middle text-center"><img src="${item.Image}" width="75" height="75"/></td>
                                <td class="align-middle text-center">${item.TopicName}</td>
                                <td class="align-middle text-center">${item.Fee} ${item.Currency}</td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="editModal('${item.ID}','${item.Name}','${item.TopicID}','${item.Fee}','${item.Currency}')">Edit</button>
                                    <button class="btn btn-danger" onclick="deleteModal('${item.ID}','${item.Name}')">Delete</button>
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

var openModal = () => {
    $('#myModal').modal('show');
}



var editModal = (id, name, topicid, fee,currency) => {
    $('#myModal2').modal('show');
    var str = `
                <input id="goalid" value="${id}" hidden/>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Topic</label>
                        <select class="form-control" id="topic2" name="topic2"></select>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Name</label>
                        <input type="text" value="${name}" class="form-control" id="name2" name="name2" />
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Image</label>
                        <input type="file" class="form-control" id="image2" name="image2" accept="image/*"/>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Fee</label>
                        <input type="number" value="${fee}" class="form-control" id="fee2" name="fee2">
                    </div>
                    <div class="form-group">
                        <label for="exampleInputPassword1">Currency</label>
                        <input type="text" value="${currency}" class="form-control" id="currency2" name="currency2">
                    </div>
                    <button type="submit" class="btn btn-primary">Save</button>
                `;
    $('#editGoalForm').html(str);
    LoadTopic("topic2", topicid);
    
}

var deleteModal = (id, name) => {
    $('#myModal3').modal('show');
    $('#modalTitle3').html('Do you want to delete ' + name);
    $('#modalBody3').html(`<button class="btn btn-primary" onclick="deleteUser('${id}')">Yes</button> <button class="btn btn-danger" class="close" data-dismiss="modal" aria-label="Close">No</button>`);
}

var deleteUser = (id) => {
    var settings = {
        "url": "/api/Goal/" + id,
        "method": "DELETE",
        "timeout": 0,
        error: function (jqXHR, textStatus, errorThrown) { window.location.replace('/Account/Login/Login'); },
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        }
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 404) {
            window.location.replace('/Screen/Login');

            // console.log(data);
        } else {
            LoadData(localStorage.getItem("token"));
            $('#myModal3').modal('hide');
        }
    });
}


$(() => {
    //Add Goal
    $('#myModal form').validate({
        rules: {
            topic1: "required",
            name1: "required",
            image1: {
                required: true
            },
            fee1: "required",
            currency1: "required",
        },
        messages: {
            topic1: "Choose Topic",
            name1: "Name is required",
            image1:{
                required: "Image is Required"
            },
            fee1: "Fee is required",
            currency1: "Currency is required",
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("TopicID", $('#topic1').val());
            form.append("Name", $('#name1').val());
            form.append("Image", $('input[type=file]')[0].files[0]);
            form.append("Fee", $('#fee1').val());
            form.append("Currency", $('#currency1').val());

            var settings = {
                "url": "/api/Goal",
                "method": "POST",
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
                if (xhr.status === 201) {
                    LoadData(localStorage.getItem("token"));
                    $('#myModal').modal('hide');
                    // console.log(data);
                } else {
                    window.location.replace('/Accoun/Login/Login');
                }
            });

        }
    });

    //Edit User
    $('#myModal2 form').validate({
        rules: {
            topic2: "required",
            name2: "required",
            fee2: "required",
            currency2: "required",
        },
        messages: {
            topic2: "Choose Topic",
            name2: "Name is required",
            fee2: "Fee is required",
            currency2: "Currency is required",
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("TopicID", $('#topic2').val());
            form.append("Name", $('#name2').val());
            form.append("Image", $('#image2')[0].files[0]);
            form.append("Fee", $('#fee2').val());
            form.append("Currency", $('#currency2').val());

            var settings = {
                "url": "/api/Goal/" + $('#goalid').val(),
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
                    $('#myModal2').modal('hide');
                    // console.log(data);
                } else {
                    window.location.replace('/Account/Login/Login');
                }
            });

        }
    });
})