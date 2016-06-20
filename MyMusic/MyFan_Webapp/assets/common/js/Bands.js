﻿function follow(fanId, bandId) {
    console.log("Llamada follow");

    if ($("#Follow_Button").text() == "Unfollow") {
        unfollow(fanId, bandId);
        return false;
    }
    
    var request = {
        fanId: fanId,
        bandId: bandId
    }
    
    $.ajax({
        url: "/Fans/" + fanId + "/followBand",
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            if (data.state == true) {
                $("#Follow_Button").text("Unfollow");
                getPopularity(fanId, bandId);
            }
            else if (data.state == false) {
                $("#Follow_Button").text("Follow");
                getPopularity(fanId, bandId);
            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;
}

function unfollow(fanId, bandId) {
    

    var request = {
        fanId: fanId,
        bandId: bandId
    }
    console.log("Llamada unfollow");
    $.ajax({
        url: "/Fans/" + fanId + "/unfollowBand",
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            if (data.state == "True") {
                $("#Follow_Button").text("Follow");
                console.log("Se hizo el unfollow, ahora lo puede volver a seguir");
                getPopularity(fanId, bandId);
            }
            else if (data.state == "False") {
                $("#Follow_Button").text("Unfollow");
                console.log("No se hizo el unfollow queda igual");
                getPopularity(fanId, bandId);
            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;
}

function updateBody(fanId, bandId) {
    isFollowing(fanId, bandId);
    getPopularity(fanId, bandId);
    return false;
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
        success: function (json, status) {
            var data = JSON.parse(json);
   
            

            $("#BandFollowers").html(abbreviateNumber(data.Followers));

            switch (data.Calification) {
                case 0:
                    break;
                case 1:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/1.png");
                    break;
                case 2:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/2.png");
                    break;
                case 3:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/3.png");
                    break;
                case 4:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/4.png");
                    break;
                case 5:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/5.png");
                    break;
          
            } 
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });

    return false;
}

function updateBodyBand(bandId) {

    getPopularityBand(bandId);
    return false;
}


function getPopularityBand(bandId) {
    var request = {
        fanId:0,
        bandId: bandId
    }
    console.log("here");
    $.ajax({
        url: "/Fans/" + 0 + "/GetBandStats",
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (json, status) {
            var data = JSON.parse(json);



            $("#BandFollowers").html(abbreviateNumber(data.Followers));

            switch (data.Calification) {
                case 0:
                    break;
                case 1:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/1.png");
                    break;
                case 2:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/2.png");
                    break;
                case 3:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/3.png");
                    break;
                case 4:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/4.png");
                    break;
                case 5:
                    $("#BandCalification").attr("src", "/assets/common/img/califications/5.png");
                    break;

            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });

    return false;
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
 
            if (data.state == "True") {
           
                $("#Follow_Button").text("Unfollow");
            }
            else if(data.state == "False"){
                $("#Follow_Button").text("Follow");
            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;
}



