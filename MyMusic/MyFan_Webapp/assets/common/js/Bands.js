function follow(fanId, bandId) {
    console.log("Fan with Id " + fanId);
    console.log("Band with Id " + bandId);

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
            alert('Done!');
        },
        error: function () {
            alert('Something goes wrong!');

        }
    });


}


