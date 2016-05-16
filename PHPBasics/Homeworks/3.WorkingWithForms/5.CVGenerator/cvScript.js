function addProgrLanguage() {
    var inputDiv = document.createElement("div");
    inputDiv.className = "langProg";
    inputDiv.innerHTML =
        "<input type='text' name='programmingLanguage[]'/> " +
        "<select name=\"programming-language-level[]\">" +
        "<option value=\"Beginner\">Beginner</option>" +
        "<option value=\"Programmer\">Programmer</option>" +
        "<option value=\"Ninja\">Ninja</option>" +
        "</select>";
    document.getElementById('programmingLanguage').appendChild(inputDiv);

}
function addLanguage() {
    var inputDiv = document.createElement("div");
    inputDiv.className = "langSpeak";
    inputDiv.innerHTML =
        "<input type='text' name='language[]'/> " +
        "  <select name=\"Comprehension[]\">"+
        "<option>-Comprehension-</option></option>"+
        "<option value=\"Beginner\">Beginner</option>"+
        "<option value=\"Intermediate\">Intermediate</option>"+
        "<option value=\"Advanced\">Advanced</option>"+
        "</select>"+
        "  <select name=\"Reading[]\">"+
        "<option>-Reading-</option>"+
        "<option value=\"Beginner\">Beginner</option>"+
        "<option value=\"Intermediate\">Intermediate</option>"+
        "<option value=\"Advanced\">Advanced</option>"+
        "</select>"+
        "  <select name=\"Writing[]\">"+
        "<option>-Writing-</option>"+
        "<option value=\"Beginner\">Beginner</option>"+
        "<option value=\"Intermediate\">Intermediate</option>"+
        "<option value=\"Advanced\">Advanced</option>"+
        "</select>";
    document.getElementById('language').appendChild(inputDiv);

}
function removeLanguage(id) {
    var inputDiv = document.getElementById(id);
    var children = inputDiv.children;

    var toRemove = [];

    for (var i in children)
    {
        if (children[i].className == 'langProg' || children[i].className == 'langSpeak')
        {
            toRemove.push(children[i]);
        }
    }

    if (toRemove.length < 1)
    {
        return;
    }

    var el = toRemove[toRemove.length - 1];

    inputDiv.removeChild(el);


}