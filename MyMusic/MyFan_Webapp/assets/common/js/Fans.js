function SearchModel() {
    var self = this;

    self.name = $("#search_main").val();

    if ($("#search_main").val() == '') {
        self.name = $("#search_secondary").val();
    }

    self.country = parseInt($("#CountryList :selected").attr('id'));

    var selectedGenres = [];
    $('#GenreList :selected').each(function (i, selected) {
        selectedGenres[i] = parseInt($(selected).attr('id'));
    });

    self.genre = selectedGenres;
}



jQuery(function ($) {



 /*

    $('.makeSearch').click(function (e) {
        e.preventDefault();
        alert("submited");
        var request = new SearchModel();
        console.log(request);
        $.ajax({
            url: "/Fans/search/",
            
            
            type: "GET",
            data: request,
            success: function (data, status) {
                alert("Wurks")

            },
            error: function () {
                alert('Something goes wrong!');
            }
        });
        return false;
    });
    */

    //Llena las opciones del formulario
    $('#searchButton').click(function (e) {
        $('#search_main').val('');
        e.preventDefault();
        $.ajax({
            url: '/Users/GetSearch',
            type: "GET",
            dataType: 'json',
            success: function (data) {

                var json = JSON.parse(data);
                var genres = json.genres
                var lengthGenres = $('#GenreList').children('option').length;
                if (lengthGenres > 1) { }
                else {
                    $.each(genres, function (i, genres) {
                        $('#GenreList').append($('<option>', {
                            value: genres.Name,
                            text: genres.Name,
                            id: genres.Id,
                            "data-tokens": genres.Name
                        }));
                    });
                }
                var country = json.locations
                var lengthCountry = $('#CountryList').children('option').length;
                if (lengthCountry > 1) {

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