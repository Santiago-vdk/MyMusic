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

    $("#imgInp").change(function (e) {
        readURL(this);
    });


});