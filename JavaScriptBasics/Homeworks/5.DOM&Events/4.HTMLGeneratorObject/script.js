var HTMLGen = {};

HTMLGen.createParagraph = function (id, text) {
    var paragraph = document.createElement('p');
    var content = document.createTextNode(text);
    paragraph.appendChild(content);
    document.getElementById(id).appendChild(paragraph);
};

HTMLGen.createDiv = function (id, classDiv) {
    var div = document.createElement('div');
    document.getElementById(id).appendChild(div).className = classDiv;
};

HTMLGen.createLink = function (id, text, url) {
    var link = document.createElement('a');
    var content = document.createTextNode(text);
    link.appendChild(content);
    link.href = url;
    document.getElementById(id).appendChild(link);
};

HTMLGen.createParagraph('wrapper', 'Soft Uni');
HTMLGen.createDiv('wrapper', 'section');
HTMLGen.createLink('book', 'C# basics book', 'http://www.introprogramming.info/');