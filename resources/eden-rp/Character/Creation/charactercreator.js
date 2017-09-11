let gender, player;
let res = API.getScreenResolution();
let ccBrowser = API.createCefBrowser(500, res.Width - 200, true);
let mainCamera = API.createCamera(new Vector3(403.0451, -999.7356, -98.50407), new Vector3(-5.0, 0.0, 2.13924));
let faceCamera = API.createCamera(new Vector3(402.9551, -997.3856, -98.21407), new Vector3(-5.0, 0.0, 2.13924));

let outfitList = [
    [
        {torso: 2, top: 2, topTex: 5, undershirt: 2, undershirtTex: 0, legs: 43, legsTex: 4, feet: 3, feetTex: 0, acc: 2, accTex: 0},
        {torso: 3, top: 3, topTex: 11, undershirt: 2, undershirtTex: 0, legs: 27, legsTex: 0, feet: 1, feetTex: 1, acc: 0, accTex: 0},
        {torso: 5, top: 6, topTex: 4, undershirt: 95, undershirtTex: 0, legs: 23, legsTex: 5, feet: 42, feetTex: 2, acc: 2, accTex: 0},
        {torso: 15, top: 16, topTex: 0, undershirt: 15, undershirtTex: 0, legs: 25, legsTex: 6, feet: 10, feetTex: 1, acc: 0, accTex: 0},
        {torso: 4, top: 37, topTex: 3, undershirt: 15, undershirtTex: 0, legs: 15, legsTex: 0, feet: 15, feetTex: 1, acc: 6, accTex: 0},
        {torso: 6, top: 121, topTex: 11, undershirt: 15, undershirtTex: 0, legs: 4, legsTex: 9, feet: 3, feetTex: 8, acc: 6, accTex: 0},
        {torso: 15, top: 171, topTex: 4, undershirt: 15, undershirtTex: 0, legs: 11, legsTex: 12, feet: 1, feetTex: 8, acc: 1, accTex: 0},
        {torso: 0, top: 9, topTex: 7, undershirt: 15, undershirtTex: 0, legs: 51, legsTex: 0, feet: 11, feetTex: 3, acc: 1, accTex: 0},
        {torso: 5, top: 63, topTex: 5, undershirt: 66, undershirtTex: 4, legs: 1, legsTex: 6, feet: 7, feetTex: 4, acc: 0, accTex: 0}
    ],
    [
        {torso: 1, top: 3, topTex: 3, undershirt: 5, undershirtTex: 2, legs: 7, legsTex: 1, feet: 8, feetTex: 9, acc: 0, accTex: 1},
        {torso: 2, top: 1, topTex: 3, undershirt: 5, undershirtTex: 2, legs: 7, legsTex: 1, feet: 8, feetTex: 9, acc: 0, accTex: 1}
    ]
];

function setHeritage(heritage) { API.triggerServerEvent("heritageChanged", heritage); }
function setEyeColor(color) { API.triggerServerEvent("eyeColorChanged", color); }
function setHairData(hairData, style) {
    player = API.getLocalPlayer();
    API.setPlayerClothes(player, 2, style, 0);
    API.triggerServerEvent("hairDataChanged", hairData);
}
function setDetails(details) { API.triggerServerEvent("detailsChanged", details); }
function setOutfit(index) {
    player = API.getLocalPlayer();
    let outfit = outfitList[gender][index];
    API.setPlayerClothes(player, 3, outfit.torso, 0);
    API.setPlayerClothes(player, 11, outfit.top, outfit.topTex);
    API.setPlayerClothes(player, 8, outfit.undershirt, outfit.undershirtTex);
    API.setPlayerClothes(player, 4, outfit.legs, outfit.legsTex);
    API.setPlayerClothes(player, 6, outfit.feet, outfit.feetTex);
    API.setPlayerClothes(player, 7, outfit.acc, outfit.accTex);
}
function setPed(name) { API.setPlayerSkin(API.pedNameToModel(name)); }
function setFreemodePed(data){
    if (!gender) setPed("FreemodeFemale01"); else setPed("FreemodeMale01");
    API.triggerServerEvent("sendFreemodeNative", data);
}
function savePed(ped) { API.triggerServerEvent("savePed", ped); }
function saveCharacter(data) { API.triggerServerEvent("saveCharacter", data); }

API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {
        case "ccmenu": {
            //API.setHudVisible(false);
            API.setActiveCamera(mainCamera);
            API.waitUntilCefBrowserInit(ccBrowser);
            API.setCefBrowserPosition(ccBrowser, 50.0, 50.0);
            API.loadPageCefBrowser(ccBrowser, "Character/Creation/menu.html");
            API.waitUntilCefBrowserLoaded(ccBrowser);
            API.showCursor(true);
            if (!args[0]) gender = 0; else gender = 1;
            break;
        }
    }
});

function switchCamera(toFace) {
    let currentCam = API.getActiveCamera();
    if (toFace) API.interpolateCameras(currentCam, faceCamera, 1000.0, true, true); else API.interpolateCameras(currentCam, mainCamera, 1000.0, true, true);
}

function getGender() { return gender; }
