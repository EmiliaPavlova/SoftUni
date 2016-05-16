var app = app || {};

app.postViews = (function () {
	function PostViews() {
	}

	PostViews.prototype.showLastPost = function (selector, lastPost) {
		$.get('templates/home-page-post.html', function (template) {
			var data = {
				'title': lastPost.title,
				'content': lastPost.content,
				'date': lastPost._kmd.lmt.replace('T', ' ').substr(0,16),
				'date': lastPost._kmd.ect = lastPost._kmd.ect.replace('T', ' ').substr(0, 19),
				'id': lastPost._id
			};
			var outputHtml = Mustache.render(template, data);
			$(selector).html(outputHtml);
		});
	};

	PostViews.prototype.showPostPageById = function (selector, post) {
		$.get('templates/post.html', function (template) {
			var comments = [];
			post[1].forEach(function (comment) {
				var currentComment = {
					'author': comment.author,
					'date': comment._kmd.ect.replace('T', ' ').substr(0,16),
					'date': comment._kmd.ect = comment._kmd.ect.replace('T', ' ').substr(0, 19),
					'content': comment.content
				};

				comments.push(currentComment);
			});

			var data = {
				'title': post[0].title,
				'content': post[0].content,
				'date': post[0]._kmd.lmt.replace('T', ' ').substr(0,16),
				'date': post[0]._kmd.lmt = post[0]._kmd.lmt.replace('T', ' ').substr(0, 19),
				'comments': comments
			};

			var outputHtml = Mustache.render(template, data);
			$(selector).html(outputHtml);
		});
	};

	PostViews.prototype.showAllPosts = function (selector, posts) {
		$.get('templates/all-posts.html', function (template) {
			var data = {posts: posts};
			var outputHtml = Mustache.render(template, data);
			$(selector).html(outputHtml);
		});
	};

	PostViews.prototype.showAllTags = function (selector, tagsArr) {
		$.get('templates/tags.html', function (template) {
			var tags = [];
			tagsArr.forEach(function (el) {
				if (el.hasOwnProperty('tags')) {
					el['tags']
						.forEach(function (tag) {
							tags.push(tag);
						});
				}
			});
			var tagsObj = app.helpers.arrToObject(tags); // contains all the tags and their number of appearance

			var outputArr = [];
			for (var key in tagsObj) {
				if (tagsObj.hasOwnProperty(key)) {
					var currentObj = {
						tagName: key,
						tagCount: tagsObj[key]
					};

					outputArr.push(currentObj);
				}
			}

			outputArr = outputArr.sort(function (a, b) {
				return a.tagCount < b.tagCount
			}).slice(0, 5);


			var data = {tags: outputArr};

			var outputHtml = Mustache.render(template, data);
			$(selector).html(outputHtml);
		});
	};

	PostViews.prototype.showAddPost = function (selector) {
		$.get('templates/add-post-page.html', function (template) {
			$(selector).html(template);
			$('#post-submit').on('click', function (e) {
				var title = $('#post-title').val(),
					content = $('#post-content').val(),
					tags = $('#post-tags').val().split(' ');

				Sammy(function () {
					this.trigger('addPost', {
						title: title,
						content: content,
						tags: tags
					});
					this.trigger('redirectUrl', {url: '#/'});
				})
			})
		});
	};

	return PostViews;
})();
