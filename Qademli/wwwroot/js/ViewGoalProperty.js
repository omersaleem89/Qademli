$(() => {
    LoadData();
    LoadProperty("property", "");
});

var LoadProperty = (id, propertyid) => {
    $.ajax({
        type: "GET",
        url: "/api/GoalProperty",
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
            $("#" + id).val(propertyid);
        }
    });
}


var LoadData = () => {
    var settings = {
        "url": "/api/ViewGoalProperty/" + $('#goalid').data('goalid'),
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        error: function (jqXHR, textStatus, errorThrown) { window.location.replace('/Account/Login/Login'); }
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
            console.log(data);
            var count = 1;
            $('#tBody').empty();
            if (data.length > 0) {
                $.each(data, function (index1, item1) {
                $.each(item1.GoalPropertyValue, function (index, item) {
                    var str = `<tr>
                                <td class="align-middle text-center">${count++}</td>
                                <td class="align-middle text-center">${item.GoalProperty.Name}</td>
                                <td class="align-middle text-center">${item.Name}</td>
                                <td class="align-middle text-center">
                                    <button class="btn btn-primary" onclick="editModal('${item.ID}','${item.GoalPropertyID}','${item1.ID}','${item.Name}')">Edit</button>
                                    <button class="btn btn-danger" onclick="deleteModal('${item.ID}','${item.Name}')">Delete</button>
                                </td>
                            </tr>`;
                    $('#tBody').append(str);
                });
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

var editModal = (id, GoalPropertyID, GoalDetailID, Name) => {
    $('#myModal2').modal('show');
    var str = `
                <input id="propertyid" value="${id}" data-goaldetailid="${GoalDetailID}" hidden/>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Property</label>
                        <select class="form-control" id="property2" name="property2"></select>
                    </div>
                    <div class="form-group">
                        <label for="exampleInputEmail1">Value</label>
                        <input type="text" class="form-control" id="value2" value="${Name}" name="value2" />
                    </div>
                    <button type="submit" class="btn btn-primary">Save</button>
                `;
    $('#editGoalForm').html(str);
    LoadProperty("property2", GoalPropertyID);
    $('#property2').prop('disabled', true);

}



var deleteModal = (id, name) => {
    $('#myModal3').modal('show');
    $('#modalTitle3').html('Do you want to delete ' + name);
    $('#modalBody3').html(`<button class="btn btn-primary" onclick="deleteUser('${id}')">Yes</button> <button class="btn btn-danger" class="close" data-dismiss="modal" aria-label="Close">No</button>`);
}

var deleteUser = (id) => {
    var settings = {
        "url": "/api/GoalPropertyValue/" + id,
        "method": "DELETE",
        "timeout": 0,
        error: function (jqXHR, textStatus, errorThrown) { window.location.replace('/Account/Login/Login'); },
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        }
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 404) {
//            window.location.replace('/Screen/Login');

            // console.log(data);
        } else {
            LoadData();
            $('#myModal3').modal('hide');
        }
    });
}


$(() => {
    //Add Goal
    $('#myModal form').validate({
        rules: {
            property: "required",
            value: "required"
        },
        messages: {
            property: "Choose Property",
            value: "Value is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("GoalPropertyID", $('#property').val());
            form.append("GoalID", $('#goalid').data('goalid'));
            form.append("Name", $('#value').val());

            var settings = {
                "url": "/api/GoalPropertyValue",
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
                    LoadData();
                    $('#myModal').modal('hide');
                    // console.log(data);
                } else {
                    window.location.replace('/Accoun/Login/Login');
                }
            });

        }
    });

   //Edit Property
    $('#myModal2 form').validate({
        rules: {
            property2: "required",
            value2: "required"
        },
        messages: {
            property2: "Choose Property",
            value2: "Value is required"
        },
        submitHandler: function (form) {
            var form = new FormData();
            form.append("GoalPropertyID", $('#property2').val());
            form.append("GoalID", $('#goalid').data('goalid'));
            form.append("Name", $('#value2').val());
            form.append("ID", $('#propertyid').val());
            form.append("GoalDetailID", $('#propertyid').data('goaldetailid'));

            var settings = {
                "url": "/api/GoalPropertyValue/" + $('#propertyid').val(),
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