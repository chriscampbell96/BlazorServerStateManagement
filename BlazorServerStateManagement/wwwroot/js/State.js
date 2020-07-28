window.stateManager = {
	save: function (key, str) {
		localStorage[key] = str;
	},
	load: function (key) {
		return localStorage[key];
	},
	remove: function (key) {
		localStorage.removeItem(key);
    }
};