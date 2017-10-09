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
fade = 1;
interval = 0;
function fadeOut() {
    if(interval === 0)
        interval = setInterval(fadeOut, 100);
    else {
        fade -= .1;
        $("body").css("opacity", fade);
        if(fade < 0) {
            clearInterval(interval);
            console.log(interval);
            //$("body").css("opacity", "1");
        }  
    }
}
function revertOpacity() {
    clearInterval(interval);
    fade = 1;
    $("body").css("opacity", "1");
}