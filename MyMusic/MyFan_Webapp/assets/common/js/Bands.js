function follow(fanId, bandId) {
    console.log("Fan with Id " + fanId);
    console.log("Band with Id " + bandId);


    if ($("#Follow_Button").text() == "Unfollow") {
        unfollow(fanId, bandId);
    }

    var request = {
        fanId: fanId,
        bandId: bandId
    }
    console.log(request);
    $.ajax({
        url: "/Fans/" + fanId + "/followBand",
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {
            console.log(data);
            if (data.state == true) {
                alert('Done!');
                $("#Follow_Button").text('Unfollow');
            }
            
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
}

function unfollow(fanId, bandId) {
    console.log("Unfollowing");


    var request = {
        fanId: fanId,
        bandId: bandId
    }
    console.log(request);
    $.ajax({
        url: "/Fans/" + fanId + "/unfollowBand",
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {
            
            if (data.state == true) {
                alert('Done!');
                $("#Follow_Button").text('Follow');
            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
}

function isFollowing(fanId, bandId) {
    console.log("Checking if followed");

    var request = {
        fanId: fanId,
        bandId: bandId
    }
    console.log(request);
    $.ajax({
        url: "/Fans/" + fanId + "/isFollowingBand",
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            if (data.state == true) {
                alert('Done!');
                $("#Follow_Button").text('Unfollow');
            }
            else {
                $("#Follow_Button").text('Follow');
            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
}

