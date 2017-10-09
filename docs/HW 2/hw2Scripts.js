function clickMeButton() {
    var input = document.getElementsByClassName("leftBars");
    var i;
        for(i = 0; i < input.length; ++i) {
            input[i].style.display = "block";
        }
}
function typedName() {
    var fName = document.getElementById("fName");
    var lName = document.getElementById("lName");  
    if(lName.value.length > 2 && fName.value.length > 2) {
        var rButton = document.getElementById("resultsButton");
        rButton.style.display = "block";
    }
    else
        document.getElementById("resultsButton").style.display = "none";
}
function goBlack() {
    var i;
    for(i = 1; i > 0; i -= .0001)
        $("body").css("opacity", i);
}