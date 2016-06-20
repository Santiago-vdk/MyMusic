var albumID = -1;
function NewAlbumModel() {
    var self = this;
    self.AlbumName = $("#AlbumName").val();
    self.DateRelease = $("#inputDateRelease").val();
    self.Label = $("#inputLabel").val();

  /*  var selectedGenres = [];
    $('#selectGenres :selected').each(function (i, selected) {
        selectedGenres[i] = parseInt($(selected).attr('id'));
    });*/
    self.Genre =parseInt( $('#selectGenres :selected').attr('id'));

    self.profilePicture = $('#album-pic').attr('src');
    

}
jQuery(function ($) {
    function validateDisc(SongName, Duration, Live, LimitedEdition, UrlVideo){
        if(SongName!="" && Duration!="" && UrlVideo != ""){
            console.log("Listo");

            var request = {
                "albumId":albumID,
                "Name": SongName,
                "Duration": Duration,
                "Live": Live,
                "LimitedEdition": LimitedEdition,
                "UrlVideo":UrlVideo
            }

            console.log(request);

            $.ajax({
                url: "NewSong",
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
                    $('#AddSong').removeClass("hide");

                    var s = '<tr>  <td>' + data.Name + '</td><td>' + data.Duration + '</td><td>' + data.Type + '</td><td>' + data.LimitedEdition + '</td><td>' + '<a href=' + data.Link + ' target="_blank">Go To Link</a> </td>   </tr>';
                    $('#table').append(s);
                },
                error: function () {
                    alert('Something goes wrong!');
                    $('#update-form-band').prop('disabled', false);
                    $('#loading').addClass("hide");
                }
            });

        }
        else {
            alert("Error with the form submited, please check its values and try again...");
        }
    }


   
    var s = ' <div class="row"> <div class="col-md-12"> <form class="form-horizontal"> <div class="form-group"> <label class="col-md-4 control-label" for="nameSong">Name</label> <div class="col-md-4"> <input id="SongNameID" name="SongName" type="text" placeholder="Song Name" class="form-control input-md" required> </div> </div> <div class="form-group"> <label class="col-md-4 control-label" for="nameSong">Duration</label> <div class="col-md-4"> <input id="DurationID" name="Duration" type="text" placeholder="HH:MM:SS" class="form-control input-md" required> </div> </div> <div class="form-group"> <label class="col-md-4 control-label">Live</label> <input type="radio" name="subject" value="true" checked="checked"> Yes <input type="radio" name="subject" value="false"> No </div> <div class="form-group"> <label class="col-md-4 control-label">Limited Edition</label> <input type="radio" name="LimitedEdition" value="true" checked="checked"> Yes <input type="radio" name="LimitedEdition" value="false"> No </div> <div class="form-group"> <label class="col-md-4 control-label">Video</label> <div class="col-md-4"> <input type="text" id="urlVideo" placeholder="YouTube" class="form-control input-md" required/> </div> </div> </form> </div> </div>';

    $("#AddSong").click(function () {
        bootbox.dialog({
            title: "Add a Song",
            message: s,
            buttons: {
                success: {
                    label: "Save",
                    className: "btn-success",
                    callback: function () {
                        var SongName = $('#SongNameID').val();
                        var Duration = $('#DurationID').val();
                        var Live = $('input[name=subject]:checked').val();
                        var LimitedEdition = $('input[name=LimitedEdition]:checked').val();
                        var UrlVideo = $('#urlVideo').val();
/*
                        console.log(SongName);
                        console.log(Duration);
                        console.log(Live);
                        console.log(LimitedEdition);
                        console.log(UrlVideo);*/

                        validateDisc(SongName, Duration, Live, LimitedEdition, UrlVideo);
                    }
                }
            }
        }
        );
    
    
    });



    $("#form-new-album").validate({
        rules: {
            imgInp: {
                required: true
            },
            AlbumName: {
                required: true,
                minlength: 3,
                maxlenght: 20
            },
            DateRelease: {
                required: true,
                date: true
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

    $("#form-new-album :input").change(function () {
        $("#form-new-album").data("changed", true);

    });

    $('#post-album-form').click(function () {
        if ($("#form-new-album").valid()) {

            var request = new NewAlbumModel();
            console.log(request);

            if ($("#form-new-album").data("changed")) {
         

                $.ajax({
                    url: "NewAlbum",
                    dataType: 'json',
                    contentType: 'application/json',
                    type: "POST",
                    data: JSON.stringify(request),
                    beforeSend: function () {
                        $('#post-album-form').prop('disabled', true);
                        $('#loading').removeClass("hide");
                    },
                    success: function (data, status) {
                        $('#post-album-form').prop('disabled', true);
                        $('#loading').addClass("hide");

                        console.log("here " + data.albumId);
                        //var json = JSON.parse(data);
                        //alert(json.albumId);
                        albumID = data.albumId;

                        $("#AlbumName").attr("disabled", true);
                        $("#inputDateRelease").attr("disabled", true);
                        $("#inputLabel").attr("disabled", true);
                        $('#selectGenres').attr("disabled", true);
                        $('#album-pic').attr("disabled", true);
                        $('#imgInp').attr("disabled", true);
                        $('#AddSong').removeClass("hide");
                    },
                    error: function () {
                        alert('Something goes wrong!');
                        $('#post-album-form').prop('disabled', false);
                        $('#loading').addClass("hide");
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
                                $('#album-pic').attr('src', e.target.result);
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