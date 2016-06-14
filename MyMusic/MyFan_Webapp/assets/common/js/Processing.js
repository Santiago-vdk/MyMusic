
    function base64(file, callback) {
        var coolFile = {};
        function readerOnload(e) {
            var base64 = btoa(e.target.result);
            coolFile.base64 = base64;
            callback(coolFile)
        };

        var reader = new FileReader();
        reader.onload = readerOnload;

        var file = file[0].files[0];
        coolFile.filetype = file.type;
        coolFile.size = file.size;
        coolFile.filename = file.name;
        reader.readAsBinaryString(file);
    }

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


    function toDataUrl(url, callback, outputFormat) {
        var img = new Image();
        img.crossOrigin = 'Anonymous';
        img.onload = function () {
            var canvas = document.createElement('CANVAS');
            var ctx = canvas.getContext('2d');
            var dataURL;
            canvas.height = this.height;
            canvas.width = this.width;
            ctx.drawImage(this, 0, 0);
            dataURL = canvas.toDataURL(outputFormat);
            callback(dataURL);
            canvas = null;
        };
        img.src = url;
    }

