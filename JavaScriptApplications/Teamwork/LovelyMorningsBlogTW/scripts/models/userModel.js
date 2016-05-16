var app = app || {};

app.userModel = (function () {
	function UserModel(requester, authorizer) {
		this._requester = requester;
		this._authorizer = authorizer;
		this.serviceUrl = this._requester.baseUrl + 'user/' + this._authorizer.appId;
	}

	UserModel.prototype.login = function (data) {
		return this._requester.post(this.serviceUrl + "/login", data, this._authorizer.getHeaders(true));
	};

	UserModel.prototype.register = function (data) {
		return this._requester.post(this.serviceUrl, data, this._authorizer.getHeaders(true));
	};

	UserModel.prototype.editProfile = function () {
		//TODO: Implement
	};

	UserModel.prototype.getById = function (id) {
		return this._requester.get(this.serviceUrl + "/" + id, this._authorizer.getHeaders(true, true));
	};

	UserModel.prototype.getCurrentUserData = function () {
		return getById(this._authorizer.getUserId());
	};

	UserModel.prototype.logout = function () {
		return this._requester.post(this.serviceUrl + "/_logout", null, this._authorizer.getHeaders(false, true));
	};

	return UserModel;
})();