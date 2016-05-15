/**********************************
**********MADE BY SANITY***********
**********************************/

var poppy = (function() {
	function unfade(element) {
		var popupOpacity = 0.1;
		element.style.display = 'block';
		var timer = setInterval(function () {
			if (popupOpacity >= 1){
				clearInterval(timer);
			}
			element.style.opacity = popupOpacity;
			element.style.filter = 'alpha(opacity=' + popupOpacity * 100 + ")";
			popupOpacity += popupOpacity * 0.1;
		}, 10);
	}
	
	function fade(element, popup) {
		if(popup._popupData.timeout != 0)
		{
			setTimeout(function(){
				var popupOpacity = 1;  // initial opacity
				var timer = setInterval(function () {
					if (popupOpacity <= 0.1){
						clearInterval(timer);
						element.style.display = 'none';
						document.body.removeChild(element);
					}
					element.style.opacity = popupOpacity;
					element.style.filter = 'alpha(opacity=' + popupOpacity * 100 + ")";
					popupOpacity -= popupOpacity * 0.1;
				}, 50);
			}, popup._popupData.timeout * 1000);
		}
	}
	
	
	function processPopup(domView, popup) {
		switch(popup._popupData.type){
			case "info":
				domView.firstElementChild.firstElementChild.addEventListener('click', function(){
					fade(domView, popup)
				});
				break;
			case "error":
				domView.addEventListener('click', function(){
					fade(domView, popup)
				});
				break;
			case "warning":
				domView.addEventListener('click', function(){
					popup._popupData.callback.call();
				});
				break;
		}
		document.body.appendChild(domView);
		unfade(domView);
		
		if(popup._popupData.type === "success"){
			fade(domView, popup);
		}
	}
	
	function pop(type, title, message) {
		var popup;
		switch (type) {
			case 'success':
				popup = new popupModule.SuccessPopup(title, message, type);
				console.log(popup);
				break;
			case 'info':
				popup = new popupModule.InfoPopup(title, message, type);
				break;
			case 'error':
				popup = new popupModule.ErrorPopup(title, message, type);
				break;
			case 'warning':
				popup = new popupModule.WarningPopup(title, message, type, arguments[3]);
				break;
		}
		// generate view from view factory
		var view = createPopupView(popup);

		processPopup(view, popup);
	}


	return {
		pop: pop
	}
})();
