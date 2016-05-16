var app = app || {};

app.postModel = (function () {
	function PostModel(requester, authorizer) {
		this._requester = requester;
		this._authorizer = authorizer;
		this.serviceUrl = this._requester.baseUrl + 'appdata/' + this._authorizer.appId + '/Posts';
	}

	PostModel.prototype.addPost = function (data) {
		return this._requester.post(this.serviceUrl, data, this._authorizer.getHeaders(true, true));
	};

	PostModel.prototype.getPostById = function (id) {
		return this._requester.get(this.serviceUrl + '/' + id, this._authorizer.getGuestHeaders());
	};

	PostModel.prototype.getAllPosts = function () {
		return this._requester.get(this.serviceUrl + '?sort={"_kmd.ect":-1}', this._authorizer.getGuestHeaders());
	};

	PostModel.prototype.getCommentsByPostId = function (postId) {
		return this._requester.get(this._requester.baseUrl + 'appdata/' + this._authorizer.appId +
			'/Comments?query={"post._id":"' + postId + '"}&sort={"_kmd.ect":-1}', this._authorizer.getGuestHeaders());
	};

	PostModel.prototype.getLastPost = function () {
		return this._requester.get(this.serviceUrl + '?sort={"_kmd.ect":-1}&limit=1', this._authorizer.getGuestHeaders())
	};

	PostModel.prototype.getPostsTags = function () {
		return this._requester.get(this.serviceUrl + '?query={}&fields=tags', this._authorizer.getGuestHeaders());
	};

	return PostModel;
})();