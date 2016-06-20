
function GetDiskReviews(fanId, bandId, albumId) {
    console.log("Called");
    var request = {
        fanId: fanId,
        bandId: bandId,
        albumId: albumId
    }

    $.ajax({
        url: "/Fans/" + fanId + "/Bands/" + bandId + "/Albums/Reviews/" + albumId ,
        dataType: 'json',
        contentType: 'application/json',
        type: "POST",
        data: JSON.stringify(request),
        success: function (data, status) {
            
            console.log(data);
            for(i = 0; i < data.length; i++){
                $("#reviews_show").append(

                '<div id="review-section-viewing" class="row">'+
                  ' <div class="row ">'+
                      ' <div class="col-xs-12 review-box">'+
                           
                          ' <div class="row">'+
                           
                               '<div class="col-xs-6 review-user"><h3>'+data[i].Author+'</h3></div>'+
                             
                              ' <div class="col-xs-6"><img class="img-circle" src="/assets/common/img/califications/' + data[i].Calification +'.png"></div>'+
                           '</div>'+

                           '<div class="row">'+
                               
                               '<div class="col-xs-12">'+
                                  ' <p>' + data[i].Comment + '</p>' +
                               '</div>'+
                           '</div>'+
                       '</div>'+
                   '</div>'+
               '</div><br/>' )

            }
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });
    return false;
}