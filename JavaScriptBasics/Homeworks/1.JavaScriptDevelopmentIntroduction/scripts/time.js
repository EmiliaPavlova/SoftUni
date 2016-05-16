function timerFunc() {
    var now = new Date();
    document.getElementById("clock").value = "" + now.toUTCString();
}
setInterval('timerFunc()', 1000);