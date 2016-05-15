function createParagraph(id, text) {
    var paragraph = document.createElement("p");
    var content = document.createTextNode(text);
    paragraph.appendChild(content);
    document.getElementById(id).appendChild(paragraph)
}

createParagraph('wrapper', 'Some text');