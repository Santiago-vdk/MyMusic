
function NewNoticiaModel() {
    var self = this;
    self.NewTitle = $("#NewTitle").val();
    self.inputContent = $("#inputContent").val();

}
jQuery(function ($) {
    $("#form-new-new").validate({
        rules: {
            NewTitle: {
                required: true,
                minlength: 10
            },
            NewContent: {
                required: true,
                minlength: 50
            }
         
        }
    });

    $("#form-new-new :input").change(function () {
        $("#form-new-new").data("changed", true);

    });

    $('#post-new-form').click(function () {
        if ($("#form-new-new").valid()) {

            var request = new NewNoticiaModel();
            console.log(request);

            if ($("#form-new-new").data("changed")) {
                alert("Put New");

                $.ajax({
                    url: "NewNoticia",
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