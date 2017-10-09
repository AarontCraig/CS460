function clickMeButton() {
    var input = document.getElementsByClassName("startHidden");
    var i;
    for(i = 0; i < input.length; ++i) {
        input[i].style.display = "block";
    }
}
function typedName() {
    var lName = document.getElementById("lName");
    //if(lName.length)
    console.log(lName.textContent);
}