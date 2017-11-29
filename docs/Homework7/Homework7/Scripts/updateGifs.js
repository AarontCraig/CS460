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

$('#searchButton').click(function () {
    alert("Pressed");
})

$('.glyphicon').click(function () {
    alert("Pressed me");
})