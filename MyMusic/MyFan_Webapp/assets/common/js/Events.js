function GetMyReview(fanId, bandId, eventId) {

    var request = {
        fanId: fanId,
        bandId: bandId,
        eventId: eventId
    }
    console.log("mine " + request)
    $.ajax({
        url: "/Fans/" + fanId + "/Bands/" + bandId + "/Events/Review/" + eventId,
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            console.log(data);

                $("#reviews_show").append(

                '<div id="review-section-viewing" class="row">' +
                  ' <div class="row ">' +
                      ' <div class="col-xs-12 review-box">' +

                          ' <div class="row">' +

                               '<div class="col-xs-6 review-user"><h3>' + data.Author + '</h3></div>' +

                              ' <div class="col-xs-6"><img class="img-circle" src="/assets/common/img/califications/' + data.Calification + '.png"></div>' +
                           '</div>' +

                           '<div class="row">' +

                               '<div class="col-xs-12">' +
                                  ' <p>' + data.Comment + '</p>' +
                               '</div>' +
                           '</div>' +
                       '</div>' +
                   '</div><button type="button" onclick="DeleteMyReview(@Model.Id,@Model"></button>' +
               '</div><br/>')

            
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;

}


function GetEventReviews(fanId, bandId, eventId, isConcert) {
    console.log("Called event " + isConcert);

    if (isConcert != true) {
        console.log("was not concert");
        return false;
    }

    GetMyReview(fanId, bandId, eventId);
    var request = {
        fanId: fanId,
        bandId: bandId,
        eventId: eventId
    }
    console.log(request)
    $.ajax({
        url: "/Fans/" + fanId + "/Bands/" + bandId + "/Events/Reviews/" + eventId,
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            console.log(data);
            for (i = 0; i < data.length; i++) {
                $("#reviews_show").append(

                '<div id="review-section-viewing" class="row">' +
                  ' <div class="row ">' +
                      ' <div class="col-xs-12 review-box">' +

                          ' <div class="row">' +

                               '<div class="col-xs-6 review-user"><h3>' + data[i].Author + '</h3></div>' +

                              ' <div class="col-xs-6"><img class="img-circle" src="/assets/common/img/califications/' + data[i].Calification + '.png"></div>' +
                           '</div>' +

                           '<div class="row">' +

                               '<div class="col-xs-12">' +
                                  ' <p>' + data[i].Comment + '</p>' +
                               '</div>' +
                           '</div>' +
                       '</div>' +
                   '</div>' +
               '</div><br/>')

            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;
}



function GetEventReviewsInBand(bandId, eventId, isConcert) {
    console.log("Called event isnide band" + bandId + " " + " "+eventId + isConcert);

    if (isConcert != true) {
        console.log("was not concert");
        return false;
    }

    var request = {
        userId: bandId,
        id: eventId
    }
    console.log(request)
    $.ajax({
        url: "/Bands/" + bandId + "/Events/Reviews/" + eventId,
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {

            console.log(data);
            for (i = 0; i < data.length; i++) {
                $("#reviews_show").append(

                '<div id="review-section-viewing" class="row">' +
                  ' <div class="row ">' +
                      ' <div class="col-xs-12 review-box">' +

                          ' <div class="row">' +

                               '<div class="col-xs-6 review-user"><h3>' + data[i].Author + '</h3></div>' +

                              ' <div class="col-xs-6"><img class="img-circle" src="/assets/common/img/califications/' + data[i].Calification + '.png"></div>' +
                           '</div>' +

                           '<div class="row">' +

                               '<div class="col-xs-12">' +
                                  ' <p>' + data[i].Comment + '</p>' +
                               '</div>' +
                           '</div>' +
                       '</div>' +
                   '</div>' +
               '</div><br/>')

            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;
}