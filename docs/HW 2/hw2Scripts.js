function clickMeButton() {
    var input = document.getElementsByClassName("leftBars");
    var i;
        for(i = 0; i < input.length; ++i) {
            input[i].style.display = "block";
        }
}
fName = 0;
lName = 0;
function typedName() {
    fName = document.getElementById("fName");
    lName = document.getElementById("lName");  
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
        }  
    }
}
function revertOpacity() {
    clearInterval(interval);
    fade = 1;
    $("body").css("opacity", "1");
    //Clear all the other elements
    $(".leftBars, #resultsButton, #dareButton").css("display", "none");
    x = document.getElementById("header");
    x.innerHTML = "Now the results!";
    $("#header").css("color", "Red");
    fillResultsDiv();
}
function fillResultsDiv() {
    list = $("#resultsList");
    var m = "m";
    //Set first element from different choices
    if(fName.value.length <= 4)
        list.html("<li>You will live a short life</li>");
    else if(fName.value.length > 4)
        list.html("<li>You will live a long life</li>");
    //Set second element
    if(String(lName).charCodeAt(0) < m.charCodeAt(0))
        list.append("<li>You will get rich soon</li>");
    else if(String(lName).charCodeAt(0) >= m.charCodeAt(0))
        list.append("<li>You won't be making much money in your life</li>");
    //Set last element
    var d = new Date();
    if((d.getTime() % 2) === 0)
        list.append("<li>You'll find your soulmate soon</li>");
    else
        list.append("<li>Good luck being happy!</li>");
}