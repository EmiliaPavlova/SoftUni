var app = app || {};

app.ajaxRequester = (function () {
	function Requester() {
		this.baseUrl = 'https://baas.kinvey.com/';
	}

	Requester.prototype.get = function (url, headers) {
		return makeRequest('GET', url, null, headers);
	};

	Requester.prototype.post = function (url, data, headers) {
		return makeRequest('POST', url, data, headers);
	};

	Requester.prototype.put = function (url, data, headers) {
		return makeRequest('PUT', url, data, headers);
	};

	Requester.prototype.delete = function (url, headers) {
		return makeRequest('DELETE', url, null, headers);
	};

	function makeRequest(method, url, data, headers) {
		var queue = Q.defer();

		$.ajax({
			url: url,
			method: method,
			data: JSON.stringify(data) || undefined,
			headers: headers,
			success: function (data) {
				queue.resolve(data);
			},
			error: function (data) {
				queue.reject(data);
			}
		});

		return queue.promise;
	}

	return Requester;
})();