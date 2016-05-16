var app = app || {};

app.ajaxRequester = (function () {
    //function AjaxRequester() {
    //    this.get = makeGetRequest;
    //    this.post = makePostRequest;
    //    this.put = makePutRequest;
    //    this.delete = makeDeleteRequest;
    //}

    function makeGetRequest(url, headers) {
        return this.makeRequest('GET', url, null, headers);
    }

    function makePostRequest(url, data, headers) {
        return this.makeRequest('POST', url, data, headers);
    }

    function makePutRequest(url, data, headers) {
        return this.makeRequest('PUT', url, data, headers);
    }

    function makeDeleteRequest(url, headers) {
        return this.makeRequest('DELETE', url, null, headers);
    }

    function makeRequest(method, url, data, headers) {
        var queue = Q.defer();

        $.ajax({
            url: url,
            method: method,
            contentType: "application/json",
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

    return {
        get: makeGetRequest,
        post: makePostRequest,
        put: makePutRequest,
        delete: makeDeleteRequest
    }
}());