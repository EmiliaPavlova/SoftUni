var app = app || {};

app.userController = (function () {
	function UserController(model, viewBag, authorizer) {
		this._model = model;
		this._viewBag = viewBag;
		this._authorizer = authorizer;
	}

	UserController.prototype.homePage = function () {
		$.get('templates/user-not-logged.html', function (templ) {
			$('#user-field').html(templ);
		});
	};
	UserController.prototype.login = function (data) {
		var _this = this;
		this._model.login(data)
			.then(function (response) {
					console.log("Successful login");
					_this._authorizer.setSessionToken(response._kmd.authtoken);
					_this._authorizer.setUsername(response.username);
					_this._authorizer.setUserId(response._id);

					//TODO: need some fix
					$('#login').children().first().remove();
					$('#login').children().first().text('Log out');

					Sammy(function () {
						this.trigger('checkUserStatus', null);
						this.trigger('redirectUrl', {url: '#/'});
					});
				},
				function (error) {
					console.error("Unsuccessful login");
				}
			).done();
	};

	UserController.prototype.register = function (data) {
		var _this = this;
		this._model.register(data)
			.then(
				function (response) {
					console.log("Successful register");
					_this._authorizer.setSessionToken(response._kmd.authtoken);
					_this._authorizer.setUsername(response.username);
					_this._authorizer.setUserId(response._id);

					Sammy(function () {
						this.trigger('checkUserStatus', null);
						this.trigger('redirectUrl', {url: '#/'})
					})
				},
				function (error) {
					console.error("Unsuccessful register!");
				}
			).done();
	};

	UserController.prototype.editProfile = function () {
		//TODO: IMPLEMENT ME
	};

	UserController.prototype.getById = function (id) {
		//var _this = this;
		this._model.getById(id)
			.then(
				function (response) {
					console.log("Successful get user by id");
					console.log(response); // TODO: implement logic
				},
				function (error) {
					console.error("Unsuccessful getting user by id!");
				}
			).done();
	};

	UserController.prototype.getCurrentUserData = function () {
		this._model.getCurrentUserData();
	};

	UserController.prototype.logout = function () {
		var _this = this;
		this._model.logout()
			.then(
				function (response) {
					console.log("Successful logout");
					_this._authorizer.clearStorage();

					Sammy(function () {
						this.trigger('checkUserStatus', null);
					});
				},
				function (error) {
					console.error("Unsuccessful logout!");
				}
			).done();
	};

	UserController.prototype.checkIsAdmin = function () {
		var currentUserId = this._authorizer.getUserId();
		if (currentUserId) {
			this._model.getById(currentUserId)
				.then(function (response) {
						console.log("Successfully checked if user is admin");
						var data = {};
						if (response['permission_level'] === 1) {
							data.isAdmin = true;
						} else {
							data.isAdmin = false;
						}

						Sammy(function () {
							this.trigger('isAdmin', data);
						});
					},
					function (error) {
						console.error("Couldn't check if user is admin!");
					}
				).done();
		} else {
			Sammy(function () {
				this.trigger('isAdmin', {isAdmin: false});
			});
		}
	};

	UserController.prototype.showLoginPage = function (selector) {
		this._viewBag.showLoginPage(selector);
	};

	UserController.prototype.showRegisterPage = function (selector) {
		this._viewBag.showRegisterPage(selector);
	};

	UserController.prototype.showAddNewPost = function (selector, data) {
		this._viewBag.showAddNewPost(selector, data);
	};

	UserController.prototype.showUserControls = function (selector) {
		var isLogged = this._authorizer.getSessionToken() || false;
		this._viewBag.showUserControls(selector, isLogged);
	};

	return UserController;
})();