var app = app || {};

app.helpers = (function () {
	function getUrlVars() {
		var url = window.location.href;
		var vars = [], hash;
		var hashes = url.slice(url.indexOf('?') + 1).split('&');
		for (var i = 0; i < hashes.length; i++) {
			hash = hashes[i].split('=');
			vars.push(hash[0]);
			vars[hash[0]] = hash[1];
		}

		return vars;
	}

	function arrToObject(arr) {
		var rv = {};
		for (var i = 0; i < arr.length; ++i)
			if ((arr[i] !== undefined) && (rv[arr[i]] === undefined)) {
				rv[arr[i]] = 0;
				rv[arr[i]]++;
			} else {
				rv[arr[i]]++;
			}
		return rv;
	}

	return {
		getUrlVars: getUrlVars,
		arrToObject: arrToObject
	}
})();