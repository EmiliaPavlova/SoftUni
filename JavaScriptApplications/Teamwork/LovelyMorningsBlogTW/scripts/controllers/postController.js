var app = app || {};

app.postController = (function () {
	function PostController(model, viewBag, authorizer) {
		this._model = model;
		this._viewBag = viewBag;
		this._authorizer = authorizer;
	}

	PostController.prototype.addPost = function (data) {
		this._model.addPost(data)
			.then(
				function (response) {
					console.log("Successfully added post");
				},
				function (error) {
					console.error("Couldn't add post");
				}
			).done();
	};

	PostController.prototype.showPostPageById = function (selector, postId) {
		var _this = this;

		var promises = [this._model.getPostById(postId),
			this._model.getCommentsByPostId(postId)]

		Q.all(promises)
			.then(function (post) {
					console.log("Successfully got post by id");
					_this._viewBag.showPostPageById(selector, post);
				},
				function (error) {
					console.error("Couldn't get post by id");
				}
			).done();
	};

	PostController.prototype.showAllPosts = function (selector) {
		var _this = this;
		this._model.getAllPosts()
			.then(function (response) {
					console.log("Successfully got all posts titles");
					_this._viewBag.showAllPosts(selector, response);
				},
				function (error) {
					console.error("Couldn't get all posts");
				}
			);
	};

	PostController.prototype.showLastPost = function (selector) {
		var _this = this;
		this._model.getLastPost()
			.then(
				function (response) {
					console.log("Successfully got last post");
					var lastPost = response[0];

					_this._viewBag.showLastPost(selector, lastPost);
				},
				function (error) {
					console.error("Couldn't get last post");
				}
			);
	};

	PostController.prototype.showAddPost = function (selector) {
		var _this = this;
		_this._viewBag.showAddPost(selector);
	};

	//PostController.prototype.searchInPosts = function () {
	//	//TODO: this shit is not MVC and not working properly need fix
	//	var _this = this;
	//	var value = $('#search-field').children().first().val();
	//	$('#search').on('click', function () {
	//		_this._model.getAllPosts().then().then(
	//			function (success) {
	//				var searched = success.filter(function (e) {
	//					return e.title = value;
	//				});
	//				console.log(searched);
	//			},
	//			function (error) {
	//				console.log("Something went wrong :(", error);
	//			}
	//		).done()
	//	});
	//};

	PostController.prototype.showPostsTags = function (selector) {
		var _this = this;
		this._model.getPostsTags()
			.then(
				function (response) {
					console.log("Successfully got posts tags");

					_this._viewBag.showAllTags(selector, response);
				},
				function (error) {
					console.error("Couldn't get last post");
				}
			);
	};

	return PostController;
})();