﻿function follow(fanId, bandId) {
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
            if (data.state == true) {
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
                $("#Follow_Button").text('Follow');
            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
}

function updateBody(fanId, bandId) {
    isFollowing(fanId, bandId);
    getPopularity(fanId, bandId);
}



function getPopularity(fanId, bandId) {
    var request = {
        fanId: fanId,
        bandId: bandId
    }

    

    $.ajax({
        url: "/Fans/" + fanId + "/GetBandStats",
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {
            console.log(data);
    

            $("#BandFollowers").html(abbreviateNumber(data.Followers));

            switch (data.Calification) {
                case 0:
                    break;
                case 1:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/Acetato-wood.png");
                    break;
                case 2:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/Acetato-silver.png");
                    break;
                case 3:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/Acetato-gold.png");
                    break;
                case 4:
                    d$("#BandCalification").attr("src", "/assets/common/img/califications/Acetato-original.png");
                    break;
                case 5:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/Acetato-rare.png");
                    break;
          
            } 
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
}

function abbreviateNumber(value) {
    var newValue = value;
    if (value >= 1000) {
        var suffixes = ["", "k", "m", "b", "t"];
        var suffixNum = Math.floor(("" + value).length / 3);
        var shortValue = '';
        for (var precision = 2; precision >= 1; precision--) {
            shortValue = parseFloat((suffixNum != 0 ? (value / Math.pow(1000, suffixNum)) : value).toPrecision(precision));
            var dotLessShortValue = (shortValue + '').replace(/[^a-zA-Z 0-9]+/g, '');
            if (dotLessShortValue.length <= 2) { break; }
        }
        if (shortValue % 1 != 0) shortNum = shortValue.toFixed(1);
        newValue = shortValue + suffixes[suffixNum];
    }
    return newValue;
}


function isFollowing(fanId, bandId) {
    var request = {
        fanId: fanId,
        bandId: bandId
    }
    
    $.ajax({
        url: "/Fans/" + fanId + "/isFollowingBand",
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            if (data.state == true) {
           
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

