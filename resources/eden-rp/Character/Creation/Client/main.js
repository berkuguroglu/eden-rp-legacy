let res = API.getScreenResolution();
var menuPool = API.getMenuPool();

var menuMain;
var details;
var skinTypeList = new List(String);
skinTypeList.Add("GTA");
skinTypeList.Add("Freemode");
var skinType = API.createListItem("Skin tipi", "Kullanmak istediginiz skin tipi", skinTypeList, 0);
var menuMain_Heritage = API.createMenuItem("Heritage", "");
var menuMain_Features = API.createMenuItem("Features", "");
var menuMain_Appearence = API.createMenuItem("Appearence", "");
var menuMain_Apparel = API.createMenuItem("Apparel", "");

skinType.OnListChanged.connect(function (sender, new_index) {
    if (new_index === 0) {
        menuMain.Clear();
        menuMain.AddItem(skinType);
    } else {
        SetFreemodeSkinOptions();
    }
    menuMain.RefreshIndex();
});

API.onServerEventTrigger.connect(function (eventName, args) {
    if (eventName === "CCMain") {
        API.setHudVisible(false);
        var pos = new Vector3(403.0451, -999.7356, -98.50407);
        var rot = new Vector3(-5.0, 0.0, 2.13924);
        var cam = API.createCamera(pos, rot);
        API.setActiveCamera(cam);
        API.showCursor(false);
        details = args[1] + " yasinda, ";
        if (args[0] === false) details += "Kadin"; else details += "Erkek";
        menuMain = API.createMenu("Character Creation", details, 30.0, 150.0, 0, true);
        menuMain.AddItem(skinType);
        menuPool.Add(menuMain);
        menuMain.Visible = true;
    }
});

API.onUpdate.connect(function () {
    
    if (menuPool !== null) {
        menuPool.ProcessMenus();
    }
});

function SetFreemodeSkinOptions() {
    menuMain.AddItem(menuMain_Heritage);
    menuMain.AddItem(menuMain_Features);
    menuMain.AddItem(menuMain_Appearence);
    menuMain.AddItem(menuMain_Apparel);
}
/*
var menuMainToHeritage = API.createMenuItem("heritage", "");
menuMainToHeritage.Activated.connect(function (menu, item) {
    menuMain.Visible = false;
    menuHeritage.Visible = true;
});
var menuHeritage = API.createMenu("heritage", "asdf", 30.0, 150.0, 0, true);
*/