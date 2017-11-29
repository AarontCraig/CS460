///$("#btn").click(function() {
    ///alert("Btn clicked!");
///}
function clickedMe() {
    alert("Clicked!");
}
/*
function newSearch() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        document.getElementById("searchBar").innerText = "Hello there";
        document.getElementById("searchBar").innerHTML = "Hello there matey";
    };

    xhttp.open("Get", "ajax_info.txt", true);
    xhttp.send();

    clickedMe();
}*/

/*$.ajax({
    type: "GET",
    url: 
})*/
function update() {
    var query = document.getElementById("searchBar").value;
    var rating = 0;
    if (document.getElementById("y").checked)
        rating = "y";
    else if (document.getElementById("g").checked)
        rating = "g";
    else if (document.getElementById("pg").checked)
        rating = "pg";
    else if (document.getElementById("pg-13").checked)
        rating = "pg-13";
    else
        rating = "r";
    $.ajax({
        url: "/Search/Index",
        data: {
            q: query,
            rating: rating
        },
        dataType: "json",
        type: "GET",
        success: function (data) {
            $('.gif').remove();
            for (var i = 0; i < data.length; ++i) {
                $("#gifs").append("<img src=\"" + data[i].url + "\" " + "class=\"gif\" />");
                $('#gifs img').css({
                    'width': 200,
                    'height': 200
                });
            }
        }
    });
}

function enterCheck(e) {
    if (e.keyCode === 13)
        update();
}