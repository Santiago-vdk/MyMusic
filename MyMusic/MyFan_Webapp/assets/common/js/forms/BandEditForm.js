var picChanged = false;
function FormEditModel() {
    var self = this;
    self.inputName = $("#inputName").val();
    self.inputDateCreation = $("#inputDateCreation").val();
    self.inputHashtag = $("#inputHashtag").val();

    self.selectCountry = parseInt($("#selectCountry :selected").attr('id'));
    self.inputBiography = $("#inputBiography").val();

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

    if (picChanged) {
        alert("Submit because it changed");
        self.profilePicture = $('#profile-pic').attr('src');
    }

}
jQuery(function ($) {

    var next = 1;
    $(".add-more").click(function (e) {
        alert("esta");
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


    $("#form-edit").validate({
        rules: {
            imgInp: {
                required: false
            },
            Name: {
                required: true,
                minlength: 3
            },
            DateCreation: {
                required: true,
                date: true
            },
           
            Country: {
                required: true
            },
            Genres: {
                required: true
            }
        },
        messages: {
            Genres: {
                required: "Pick at least one musical genre"
            }
        }
    });

    $("#form-edit :input").change(function () {
        $("#form-edit").data("changed", true);

    });

    $("#img-profile-edit img").change(function () {
        $("#img-profile-edit img").data("changed", true);
        alert("image changed");
    });




    $("#profile-pic").data("changed", false);


    $('#update-form').click(function () {
        if ($("#form-edit").valid()) {

            var request = new FormEditModel();
            console.log(request);

            if ($("#form-edit").data("changed")) {
                alert("Put Edit");
                
                /*$.ajax({
                    url: "UpdateProfile",
                    dataType: 'text',
                    contentType: 'application/json',
                    type: "POST",
                    data: JSON.stringify(request),
                    beforeSend: function () {
                        $('#update-form').prop('disabled', true);
                    },
                    success: function (data, status) {
                        $('#update-form').prop('disabled', false);
                        location.reload();
                    },
                    error: function () {
                        alert('Something goes wrong!');
                    }
                });*/
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
        picChanged = true;
        readURL(this);
    });


});