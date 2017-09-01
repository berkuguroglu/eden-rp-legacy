let loginBrowser, res;

API.onServerEventTrigger.connect(function (eventName, args) {

    switch (eventName) {
        case "login": {
            API.setHudVisible(false);
            res = API.getScreenResolution();
            loginBrowser = API.createCefBrowser(400, 300, true);
            API.waitUntilCefBrowserInit(loginBrowser);
            API.setCefBrowserPosition(loginBrowser, res.Width / 2 - 200, res.Height / 2 - 150);
            API.loadPageCefBrowser(loginBrowser, "core/login/login.html");
            API.showCursor(true);
            break;
        }
        case "loginGranted": {
            API.sendNotification("Giris basarili!");
            API.showCursor(false);
            API.destroyCefBrowser(loginBrowser);
            API.setHudVisible(true);
            API.setActiveCamera(null);
            break;
        }
        case "loginDenied": {
            API.sendNotification("Hatali parola!");
            loginBrowser.call("clean");
            break;
        }
        case "loginCamera": {
            var pos = new Vector3(0.0, 0.0, 164.0);
            var newCam = API.createCamera(pos, pos);
            API.setActiveCamera(newCam);
            break;
        }
    }
});

function login(pass) {
    API.triggerServerEvent("loginCheck", pass);
}