function display(id) {
    var clickedID = id;
    $.ajax({
        url: "/Home/Index",
        data: {
            ID: id
        },
        type: "POST",
        success: function (data) {
            $('.toDelete').remove();
            for (var i = 0; i < data.length; ++i)
            {
                $('#details').append("<p class=\"toDelete\">" + "<b>Artist: </b>" + data[i].ArtistName) + "</p>";
                $('#details').append("<p class=\"toDelete\">" + "<b>Title: </b>" + data[i].Artwork) + "</p><br>";
                $('#details').css({
                    'padding' : 20
                });
                $('#details').append('<br class=\"toDelete\">');
            }
        }
    });
}