function validate() {
    var input = document.getElementById('email');
    document.getElementById("emailCheck").innerHTML = input.value;
    var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (regex.test(input.value)) {
        document.getElementById("emailCheck").style.backgroundColor = "lightgreen";
    } else {
        document.getElementById("emailCheck").style.backgroundColor = "red";
    }


}