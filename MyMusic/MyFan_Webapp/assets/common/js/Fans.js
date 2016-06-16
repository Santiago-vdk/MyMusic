jQuery(function ($) {


    $('#searchButton').click(function (e) {
        
        

        e.preventDefault();
        $.ajax({
            url: '/Users/GetSearch',
            type: "GET",
            dataType: 'json',
            success: function (data) {

                var json = JSON.parse(data);
                var genres = json.genres
                var lengthGenres = $('#GenreList').children('option').length;
                if (lengthGenres > 0) {
                    
                }
                else {
                    $.each(genres, function (i, genres) {
                        $('#GenreList').append($('<option>', {
                            value: genres.Name,
                            text: genres.Name,
                            id: genres.Id
                        }));
                    });
                }
                

                var country = json.locations
                var lengthCountry = $('#CountryList').children('option').length;
                if (lengthCountry > 0) {

                }
                else {
                    $.each(country, function (i, country) {
                        $('#CountryList').append($('<option>', {
                            value: country.Name,
                            text: country.Name,
                            id: country.Id
                        }));
                    });
                }
                

            },
            error: function (xhr, status, error) {
                alert("Upss");
            }
        });
    });





});