window.loginTask = {
  setLocal: function (key, val) {
    localStorage.setItem(key, val);
  },
  getLocal: function (key) {
    return localStorage.getItem(key);
  },
  removeLocal: function (key) {
    localStorage.removeItem(key);
  }
};
