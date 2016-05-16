var app = app || {};

app.authorizer = (function () {
	function Authorizer(appId, appSecret) {
		this.appId = appId;
		this.appSecret = appSecret;
	}

	Authorizer.prototype.getHeaders = function (contentType, useSession) {
		var headers = {};

		if (contentType) {
			headers['Content-Type'] = 'application/json';
		}

		if (useSession) {
			headers['Authorization'] = 'Kinvey ' + this.getSessionToken();
		}
		else {
			headers['Authorization'] = 'Basic ' + btoa(this.appId + ':' + this.appSecret);
		}

		return headers;
	};

	Authorizer.prototype.getGuestHeaders = function (contentType, useSession) {
		var headers = {};

		if (contentType) {
			headers['Content-Type'] = 'application/json';
		}

		if (useSession) {
			headers['Authorization'] = 'Kinvey ' + this.getSessionToken();
		}
		else {
			headers['Authorization'] = 'Basic ' + btoa(this.appId + ':' + this.appSecret);
		}

		return {
			'Authorization': 'Basic ' + btoa('guest:guest'),
			'Content-Type': 'application/json'
		};
	};

	Authorizer.prototype.getSessionToken = function () {
		return sessionStorage.getItem('sessionToken');
	};

	Authorizer.prototype.setSessionToken = function (sessionToken) {
		sessionStorage.setItem('sessionToken', sessionToken);
	};

	Authorizer.prototype.getUserId = function () {
		return sessionStorage.getItem('userId');
	};

	Authorizer.prototype.setUserId = function (userId) {
		sessionStorage.setItem('userId', userId);
	};

	Authorizer.prototype.getUsername = function () {
		return sessionStorage.getItem('username');
	};

	Authorizer.prototype.setUsername = function (username) {
		sessionStorage.setItem('username', username);
	};

	Authorizer.prototype.clearStorage = function () {
		sessionStorage.clear();
	};

	return Authorizer;
})();