function FormEditModel() {
    var self = this;
    self.inputName = $("#inputName").val();
    self.inputBirthday = $("#inputBirthday").val();
    self.selectGender = parseInt($("#selectGender :selected").attr('id'));
    self.selectCountry = parseInt($("#selectCountry :selected").attr('id'));

    var selectedGenres = [];
    $('#selectGenres :selected').each(function (i, selected) {
        selectedGenres[i] = parseInt($(selected).attr('id'));
    });
    self.selectGenres = selectedGenres;
    self.profilePicture = $('#profile-pic').attr('src');
}
jQuery(function ($) {
    $("#form-edit").validate({
        rules: {
            imgInp: {
                required: false
            },
            Name: {
                required: true,
                minlength: 3
            },
            Birthday: {
                required: true,
                date: true
            },
            Gender: {
                required: true
            },
            Country: {
                required: true
            },
            Genres: {
                required: true
            }
        },
        messages: {
            Birthday: {
                required: "Come on! Everyone has a birthday"
            },
            Genres: {
                required: "Pick at least one musical genre"
            }
        }
    });
   
    $("#form-edit :input").change(function () {
        $("#form-edit").data("changed", true);

    });

    $('#update-form').click(function () {
        if ($("#form-edit").valid()) {
            $('#update-form').prop('disabled', true);
            var request = new FormEditModel();
            alert("Put Edit");

            if ($("#form-edit").data("changed")) {
                $.ajax({
                    url: "UpdateProfile",
                    dataType: 'text',
                    contentType: 'application/json',
                    type: "POST",
                    data: JSON.stringify(request),
                    success: function (data, status) {
                        window.location.href = "/";
                    },
                    error: function () {
                        alert('Something goes wrong!');
                    }
                });
            }

               
            
            
            return false;
        }
    });

    function readURL(input) {
        if (input.files && input.files[0]) {
            if (input.files[0].size < 2097152) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var image = new Image();
                    image.src = e.target.result;
                    image.onload = function () {
                        // access image size here 		
                        var fileType = this.src.substring(0, 16);
                        if (fileType.includes("jpg") || fileType.includes("png") || fileType.includes("gif")) {
                            if ((this.width > 400) || (this.height > 400)) {
                                alert("Only 400 x 400 images accepted");
                            }
                            else {
                                $('#profile-pic').attr('src', e.target.result);
                            }
                        }
                        else {
                            alert("Invalid file type");
                        }
                    };
                }
                reader.readAsDataURL(input.files[0]);
            }
            else {
                alert("Your file is too big, 2MB max");
            }
        }
    }

    $("#imgInp").change(function (e) {
        readURL(this);
    });


});