var domModule = (function () {
    var getElement = function (selector) {
        return document.querySelector(selector);
    };

    function appendChild(parent, child) {
        if (!(parent instanceof Element)) {
            parent = getElement(parent);
        }

        if (!(child instanceof Element)) {
            child = getElement(parent);
        }

        parent.appendChild(child);
    }

    function removeChild(parent, child) {
        if (!(parent instanceof Element)) {
            parent = getElement(parent);
        }

        if (!(child instanceof Element)) {
            child = getElement(child);
        }

        parent.removeChild(child);
    }

    function retrieveElements(selector) {
        return document.querySelectorAll(selector);
    }

    function addHandler(elements, eventType, eventHandler) {
        if (!(elements instanceof Element) && !Array.isArray(elements)) {
            elements = retrieveElements(elements);
        }

        for (var i in elements) {
            if (elements[i] instanceof HTMLElement) {
                elements[i].addEventListener(eventType, eventHandler, false);
            }
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    }
})();

var liElement = document.createElement("li");
domModule.appendChild(".birds-list", liElement);

domModule.removeChild("ul.birds-list", "li:first-child");

domModule.addHandler("li.bird", "click", function () {
    alert("I'm a bird!")
});
var elements = domModule.retrieveElements(".bird");