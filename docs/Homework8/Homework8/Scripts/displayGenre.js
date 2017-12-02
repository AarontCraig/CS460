function display(id) {
    var clickedID = id;
    $.ajax({
        url: "/Home/Index",
        data: {
            ID: id
        },
        type: "POST",
        success: function (data) {
            //$('details').remove();
            for (var i = 0; i < data.length; ++i)
            {
                $('#details').append(data[i].Artwork);
                $('#details').append(data[i].ArtistName);
            }
        }
    });
}