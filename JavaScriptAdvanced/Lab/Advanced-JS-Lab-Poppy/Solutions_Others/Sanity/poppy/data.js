/**********************************
**********MADE BY SANITY***********
**********************************/

const successPopupPosition = "bottomLeft",
	  successPopupAutoHide = true,
	  successPopupTimeout = 3,
	  successPopupCloseButton = false,
	  successPopupCallBack = function(){},
	  infoPopupPosition = "topLeft",
	  infoPopupAutoHide = false,
	  infoPopupTimeout = 1,
	  infoPopupCloseButton = true,
	  infoPopupCallBack = function(){},
	  errorPopupPosition = "topRight",
	  errorPopupAutoHide = true,
	  errorPopupTimeout = 0.1,
	  errorPopupCloseButton = false,
	  errorPopupCallBack = function(){},
	  warningPopupPosition = "bottomRight",
	  warningPopupAutoHide = false,
	  warningPopupTimeout = 1,
	  warningPopupCloseButton = false,
	  warningPopupCallBack = function(){
		  location.replace("https://www.youtube.com/watch?v=HMUDVMiITOU");
	  };
	  
Object.prototype.extends = function(parent) {
	this.prototype = Object.create(parent.prototype);
	this.prototype.constructor = this;
}
var popupModule = (function() {
	var Popup = (function() {
		function Popup(title, message, type, position, autoHide, timeout, closeButton, callback){
			var title = title,
				message = message,
				type = type,
				position = position,
				autoHide = autoHide,
				timeout = timeout,
				closeButton = closeButton,
				callback = callback;
			
			this._popupData = {
				title: title,
				message: message,
				type: type,
				position: position,
				autoHide: autoHide,
				timeout: timeout,
				closeButton: closeButton,
				callback: callback
			};
		};
		
		return Popup;
	})();


	var SuccessPopup = (function() {
		function SuccessPopup(title, message, type){
			Popup.call(this, title, message, type, successPopupPosition, successPopupAutoHide, successPopupTimeout, successPopupCloseButton, successPopupCallBack);
		};
		
		SuccessPopup.extends(Popup);

		return SuccessPopup;
	})();

	var InfoPopup = (function() {
		function InfoPopup(title, message, type){
			Popup.call(this, title, message, type, infoPopupPosition, infoPopupAutoHide, infoPopupTimeout, infoPopupCloseButton, infoPopupCallBack);
		};

		InfoPopup.extends(Popup);

		return InfoPopup;
	})();

	var ErrorPopup = (function() {
		function ErrorPopup(title, message, type){
			Popup.call(this, title, message, type, "topRight", errorPopupAutoHide, errorPopupTimeout, errorPopupCloseButton, errorPopupCallBack);
		};

		ErrorPopup.extends(Popup);

		return ErrorPopup;
	})();

	var WarningPopup = (function() {
		function WarningPopup(title, message, type, callback){
			Popup.call(this, title, message, type, warningPopupPosition, warningPopupAutoHide, warningPopupTimeout, warningPopupCloseButton, warningPopupCallBack);
		};

		WarningPopup.extends(Popup);

		return WarningPopup;
	})();
	
	return {
		SuccessPopup: SuccessPopup,
		InfoPopup: InfoPopup,
		ErrorPopup: ErrorPopup,
		WarningPopup: WarningPopup
	}
})();