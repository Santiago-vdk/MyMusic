
function EventModel() {
    var self = this;
    self.EventTitle = $("#EventTitle").val();
    self.EventDate = $("#EventDate").val();
    self.EventTime = $("#EventTime").val();
    self.EventType = $("#EventTypeID :selected").attr("id");
    self.EventState = parseInt($("#EventStateID :selected").attr("id"));
    self.EventLocation = $("#EventLocation").val();
    self.EventContent = $("#EventContent").val();


}
jQuery(function ($) {
    $("#form-new-event").validate({
        rules: {
            EventTitle: {
                required: true,
                minlength: 10
            },
            EventDate: {
                required: true,
                date: true
            },
            EventTime: {
                required: true
            },
            EventType: {
                required: true
            },
            EventState: {
                required: true
            },
            EventState: {
                required: true
            },
            EventLocation: {
                required: true,
                minlength:25
            },
            EventContent: {
                required: true,
                minlength:25
            }


        }
    });

    $("#form-new-event :input").change(function () {
        $("#form-new-event").data("changed", true);

    });

    $('#post-event').click(function () {
        if ($("#form-new-event").valid()) {

            var request = new EventModel();
            console.log(request);

            if ($("#form-new-event").data("changed")) {
                alert("Put New");

                $.ajax({
                    url: "NewEvent",
                    dataType: 'json',
                    contentType: 'application/json',
                    type: "POST",
                    data: JSON.stringify(request),
                    beforeSend: function () {
                        $('#update-form-band').prop('disabled', true);
                        $('#loading').removeClass("hide");
                    },
                    success: function (data, status) {
                        $('#update-form-band').prop('disabled', false);
                        $('#loading').addClass("hide");
                        if (data.isRedirect) {
                            window.location.href = data.redirectUrl;
                        }
                    },
                    error: function () {
                        alert('Something goes wrong!');
                        $('#update-form-band').prop('disabled', false);
                        $('#loading').addClass("hide");
                    }
                });
            }




            return false;
        }
    });
});