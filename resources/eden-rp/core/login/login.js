let loginBrowser = API.createCefBrowser(400, 300, true);
let res = API.getScreenResolution();

API.onServerEventTrigger.connect(function (eventName, args) {

    switch (eventName) {
        case "login": {
            API.setHudVisible(false);
            let pos = new Vector3(0.0, 0.0, 164.0);
            let newCam = API.createCamera(pos, pos);
            API.setActiveCamera(newCam);
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
    }
});

function login(pass) {
    API.triggerServerEvent("loginCheck", pass);
}
