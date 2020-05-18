$(() => {
    LoadData(localStorage.getItem("token"));
});


var LoadData = (token) => {
    var settings = {
        "url": "/api/GoalProperty",
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
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="editModal('${item.ID}','${item.Name}')">Edit</button>
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



var editModal = (id, name) => {
    $('#myModal2').modal('show');
    var str = `
                <input id="goalid" value="${id}" hidden/>
                    
                    <div class="form-group">
                        <label for="exampleInputEmail1">Name</label>
                        <input type="text" value="${name}" class="form-control" id="name2" name="name2" />
                    </div>
                    <button type="submit" class="btn btn-primary">Save</button>
                `;
    $('#editGoalForm').html(str);

}

var deleteModal = (id, name) => {
    $('#myModal3').modal('show');
    $('#modalTitle3').html('Do you want to delete ' + name);
    $('#modalBody3').html(`<button class="btn btn-primary" onclick="deleteUser('${id}')">Yes</button> <button class="btn btn-danger" class="close" data-dismiss="modal" aria-label="Close">No</button>`);
}

var deleteUser = (id) => {
    var settings = {
        "url": "/api/GoalProperty/" + id,
        "method": "DELETE",
        "timeout": 0,
        error: function (jqXHR, textStatus, errorThrown) { window.location.replace('/Account/Login/Login'); },
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        }
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 404) {
            window.location.replace('/Account/Login/Login');

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
            name1: "required"
        },
        messages: {
            name1: "Name is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("Name", $('#name1').val());

            var settings = {
                "url": "/api/GoalProperty",
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

    //Edit Goal Property
    $('#myModal2 form').validate({
        rules: {
            name2: "required"
        },
        messages: {
            name2: "Name is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("Name", $('#name2').val());
            form.append("ID", $('#goalid').val());

            var settings = {
                "url": "/api/GoalProperty/" + $('#goalid').val(),
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