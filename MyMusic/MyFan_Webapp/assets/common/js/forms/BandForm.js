function FormModel() {
    var self = this;
    self.inputUsername = $("#inputUsername").val();
    self.inputPassword = $("#Password").val();
    self.inputConfirmPassword = $("#inputConfirmPassword").val();
    self.inputName = $("#inputName").val();
    self.inputHashtag = $("#inputHashtag").val();
    self.inputDateCreation = $("#inputDateCreation").val();
    self.selectCountry = parseInt($("#selectCountry :selected").attr('id'));

    var selectedGenres = [];
    $('#selectGenres :selected').each(function (i, selected) {
        selectedGenres[i] = parseInt($(selected).attr('id'));
    });
    self.selectGenres = selectedGenres;

    var inputMembers = [];
    $('#profs input').each(function () {
        var name = $(this).val();
        inputMembers.push(name);
    })
    inputMembers.splice(-1, 1);

    self.inputMembers = inputMembers;

    self.inputBiography = $("#inputBiography").val();

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
            DateCreation: {
                required: false,
                date: true
            },
            Hashtag: {
                required: true,
                minlength: 2
            },
            Country: {
                required: true
            },
            Genres: {
                required: true
            },
            prof1: {
                required: true
            },
            Biography: {
                required: false
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
            Genres: {
                required: "Pick at least one musical genre"
            }
        }
    });

    var next = 1;
    $(".add-more").click(function (e) {
        e.preventDefault();
        var addto = "#field" + next;
        var addRemove = "#field" + (next);
        next = next + 1;
        var newIn = '<input autocomplete="off" class="input form-control" id="field' + next + '" placeholder="Member Name" name="field' + next + '" type="text">';
        var newInput = $(newIn);
        var removeBtn = '<button id="remove' + (next - 1) + '" class="btn btn-danger remove-me" >-</button></div><div id="field">';
        var removeButton = $(removeBtn);
        $(addto).after(newInput);
        $(addRemove).after(removeButton);
        $("#field" + next).attr('data-source', $(addto).attr('data-source'));
        $("#count").val(next);

        $('.remove-me').click(function (e) {
            e.preventDefault();
            var fieldNum = this.id.charAt(this.id.length - 1);
            var fieldID = "#field" + fieldNum;
            $(this).remove();
            $(fieldID).remove();
        });
    });


   


    $('#submit').click(function () {
        if ($("#form").valid()) {
            $('#submit').prop('disabled', true);
            var request = new FormModel();
            console.log(request);
            $.ajax({
                url: "RegisterBand",
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