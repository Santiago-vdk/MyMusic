function FormModel() {
    var self = this;
    self.inputUsername = $("#inputUsername").val();
    self.inputPassword = $("#Password").val();
    self.inputConfirmPassword = $("#inputConfirmPassword").val();
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
    $("#form").validate({
        rules: {
            imgInp: {
                required: false
            },
            Username: {
                required: true,
                rangelength: [3, 24],
                remote: {
                    url: "ValidateUsername",
                    type: "post"
                }
            },
            Password: {
                required: true,
                minlength: 5
            },
            ConfirmPassword: {
                required: true,
                minlength: 5,
                equalTo: "#Password"
            },
            Name: {
                required: true,
                minlength: 3
            },
            Birthday: {
                required: true
            },
            Gender: {
                required: true
            },
            Country: {
                required: true
            },
            Genres: {
                required: true
            },
            Accept: {
                required: true
            }
        },
        messages: {
            Username: {
                remote: "Username already in use :("
            },
            ConfirmPassword: {
                equalTo: "Please enter the same password as above"
            },
            Birthday: {
                required: "Come on! Everyone has a birthday"
            },
            Genres: {
                required: "Pick at least one musical genre"
            }
        }
    });

    $('#submit').click(function () {
        if ($("#form").valid()) {
            $('#submit').prop('disabled', true);
            var request = new FormModel();
            $.ajax({
                url: "RegisterFan",
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