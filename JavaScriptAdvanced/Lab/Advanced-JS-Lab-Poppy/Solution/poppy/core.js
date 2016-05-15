var poppy = (function() {
    function pop(type, title, message, callback) {
        var popup;
        switch (type) {
            case 'success' :
                popup = popups.createSuccess(title, message);
                break;
            case 'info' :
                popup = popups.createInfo(title, message);
                break;
            case 'error' :
                popup = popups.createError(title, message);
                break;
            case 'warning' :
                popup = popups.createWarning(title, message, callback);
                break;
        }

        // generate view from view factory
        var view = createPopupView(popup);

        processPopup(view, popup);
    }

    function processPopup(domView, popup) {
        domView.style.transition = 'opacity 800ms';
        domView.style.opacity = 0;
        document.body.appendChild(domView);

        setTimeout(function () {
            domView.style.opacity = 1;
        }, 500);

        if(popup._popupData.type === 'warning') {
            domView.addEventListener('click', function() {
                popup._popupData.callback();
            });
        }

        if(popup._popupData.type === 'info') {
            var btns = document.getElementsByClassName('poppy-close-button');

            var arr = Array.prototype.slice.call(btns);
            arr.forEach(function(btn) {
                btn.addEventListener('click', function(ev)  {
                    fadeOut(domView);
                });
            })
        }
        if(popup._popupData.type === 'error') {
            domView.addEventListener('click', function() {
                fadeOut(domView)
            })
        }

        if(popup._popupData.autoHide) {
            setTimeout(function() {
                fadeOut(domView);
            }, popup._popupData.timeout);
        }
    }

    function fadeOut(domView) {
        var timeoutID = setTimeout(function() {
            domView.style.opacity = 0;
            clearTimeout(timeoutID);
        }, 500);


        setTimeout(function() {
            document.body.removeChild(domView);
        }, 800);
    }

    return {
        pop: pop
    }
}());

