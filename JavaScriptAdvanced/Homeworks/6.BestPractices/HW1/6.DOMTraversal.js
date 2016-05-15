function traverse(selector) {
    var node = document.querySelector(selector);
    var spacing = spacing || '';

    function traverseNode(node, spacing) {
        var nodeId = node.getAttribute('id') ? ' id=\"' + node.id + '\"' : '';

        if (node.className) {
            //console.log(node.localName);
            console.log(spacing + node.localName + ':' + nodeId +' class="' + node.className + '"');
        }

        for (var i = 0; i < node.childNodes.length; i++) {
            var child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + '   ');
            }
        }
    }

    for (var child in node.childNodes) {
        if (node.childNodes[child].nodeType === document.ELEMENT_NODE) {
            traverseNode(node.childNodes[child], spacing);
        }
    }
}

var selector = ".birds";
traverse(selector);