addEventListener("load", function () {
    setTimeout(hideURLbar, 0);
}, false);

function hideURLbar() {
    window.scrollTo(0, 1);
}


function myFunction() {
    var x = document.getElementById("myInput1");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
    var y = document.getElementById("myInput2");
    if (y.type === "password") {
        y.type = "text";
    } else {
        y.type = "password";
    }
    debugger;
}

