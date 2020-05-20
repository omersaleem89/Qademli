$(() => {
    LoadUniversities();
    LoadLearningCentres()
});

let LoadUniversities = () => {
        var settings = {
            "url": "/api/Goal/GetGoalListByTopicID?id=2",
            "method": "GET",
            "timeout": 0,
            "headers": {
                "Authorization": "Bearer " + localStorage.getItem("token")
            },
            error: function (jqXHR, textStatus, errorThrown) {// window.location.replace('/Account/Login/Login'); 
            }
        };

        $.ajax(settings).done(function (data, statusText, xhr) {
            if (xhr.status === 200) {
                console.log(data);
                $('#uniList').empty();
                if (data.length > 0) {
                    $.each(data, function (index, item) {
                        var str = `<div class="col-md-3">
                            <div class="single_item">
                                <a href="#" class="text-blue">
                                    <img src="${item.Image}" alt="uni-logo" class="uni_logo">
                                    <h4 class="my-0 text-blue">${item.Name}</h4>
                                </a>
                            </div>
                        </div>`;
                        $('#uniList').append(str);
                        if (index === 3) {
                            return false; // breaks
                        }
                    });

                }
            } else {
                //window.location.replace('/Account/Login/Login');
            }
        });
}

let LoadLearningCentres = () => {
    var settings = {
        "url": "/api/Goal/GetGoalListByTopicID?id=1",
        "method": "GET",
        "timeout": 0,
        "headers": {
            "Authorization": "Bearer " + localStorage.getItem("token")
        },
        error: function (jqXHR, textStatus, errorThrown) {// window.location.replace('/Account/Login/Login'); 
        }
    };

    $.ajax(settings).done(function (data, statusText, xhr) {
        if (xhr.status === 200) {
            console.log(data);
            $('#languageList').empty();
            if (data.length > 0) {
                $.each(data, function (index, item) {
                    var str = `<div class="col-md-3">
                            <div class="single_item">
                                <a href="#" class="text-blue">
                                    <img src="${item.Image}" alt="uni-logo" class="uni_logo">
                                    <h4 class="my-0 text-blue">${item.Name}</h4>
                                </a>
                            </div>
                        </div>`;
                    $('#languageList').append(str);
                    if (index === 3) {
                        return false; // breaks
                    }
                });

            }
        } else {
            //window.location.replace('/Account/Login/Login');
        }
    });
}