//let confirmed = false;
let maleOutfitMax = 2;
let femaleOutfitMax = 10;
let selectedParent;
let skinList = ["AbigailCutscene","Acult02AMO","AfriAmer01AMM","Agent14Cutscene","AgentCutscene","AirHostess01SFY","AlDiNapoli","AmandaTownley","AmmuCity01SMY","AmmuCountrySMM","Andreas","AndreasCutscene","AnitaCutscene","AntonB","AntonCutscene","ArmBoss01GMM","ArmGoon01GMM","ArmGoon02GMY","ArmLieut01GMM","ArmyMech01SMY","Ashley","AutoShop01SMM","Autoshop02SMM","AviSchwartzman","Azteca01GMY","BabyD","BallaEast01GMY","BallaOrig01GMY","Ballas01GFY","BallasOGCutscene","BallaSout01GMY","Bankman01","Bankman","Barman01SMY","Barry","Bartender01SFY","Baygor","BayWatch01SFY","BayWatch01SMY","Beach01AFM","Beach01AFY","Beach01AMM","Beach01AMO","Beach01AMY","Beach02AMM","Beach02AMY","Beach03AMY","BeachVesp01AMY","Beachvesp02AMY","Benny","BestMen","BeverlyCutscene","BevHills01AFM","Bevhills01AFY","BevHills01AMM","BevHills01AMY","BevHills02AFM","BevHills02AFY","BevHills02AMM","BevHills02AMY","Bevhills03AFY","BevHills04AFY","BikeHire01","BikerChic","BoatStaff01F","BoatStaff01M","BodyBuild01AFM","Bouncer01SMM","Brad","BreakDance01AMY","Bride","BurgerDrugCutscene","BusBoy01SMY","Busicas01AMY","Business01AFY","Business01AMM","Business01AMY","Business02AFM","Business02AFY","Business02AMY","Business03AFY","Business03AMY","Business04AFY","Busker01SMO","Car3Guy1","Car3Guy2","CarBuyerCutscene","CCrew01SMM","Chef01SMY","Chef","ChemWork01GMM","ChiBoss01GMM","ChiGoon01GMM","ChiGoon02GMM","ChinGoonCutscene","Chip","Clay","ClayPain","Cletus","Clown01SMY","CntryBar01SMM","ComJane","Construct01SMY","Construct02SMY","CrisFormageCutscene","CustomerCutscene","Cyclist01","Cyclist01amy","DaleCutscene","DaveNortonCutscene","Dealer01SMY","DebraCutscene","Denise","DeniseFriendCutscene","Devin","DevinSec01SMY","DHill01AMY","Dom","Doorman01SMY","DownTown01AFM","DownTown01AMY","Dreyfuss","DrFriedlander","EastSA01AFM","EastSA01AFY","EastSA01AMM","Eastsa01AMY","EastSA02AFM","EastSA02AFY","EastSa02AMM","EastSA02AMY","EastSA03AFY","EdToh","Epsilon01AFY","Epsilon01AMY","Epsilon02AMY","ExArmy01","FabienCutscene","FamCA01GMY","FamDD01","FamDNF01GMY","FamFor01GMY","Families01GFY","Farmer01AMM","FatBla01AFM","FatCult01AFM","FatLatin01AMM","FatWhite01AFM","FBISuit01","FemBarberSFM","FIBMugger01","FIBOffice02SMM","FilmDirector","FinGuru01","Fitness01AFY","Fitness02AFY","FosRepCutscene","Franklin","Gay01AMY","Gay02AMY","GenFat01AMM","GenFat02AMM","GenHot01AFY","GenStreet01AFO","GenStreet01AMO","GenStreet01AMY","GenStreet02AMY","GenTransportSMM","GlenStank01","Golfer01AFY","Golfer01AMM","Golfer01AMY","Griff01","Grip01SMY","GroomCutscene","GroveStrDlrCutscene","GuadalopeCutscene","Guido01","GunVend01","GurkCutscene","Hacker","HairDress01SMM","Hao","HasJew01AMM","HasJew01AMY","HighSec01SMM","HighSec02SMM","Hiker01AFY","Hiker01AMY","HillBilly01AMM","HillBilly02AMM","Hippie01","Hippie01AFY","Hippy01AMY","Hipster01AFY","Hipster01AMY","Hipster02AFY","Hipster02AMY","Hipster03AFY","Hipster03AMY","Hipster04AFY","Hooker01SFY","Hooker02SFY","Hooker03SFY","HotPosh01","HughCutscene","Hunter","ImranCutscene","Indian01AFO","Indian01AFY","Indian01AMM","Indian01AMY","JackHowitzerCutscene","Janet","JanitorSMM","JayNorris","JetSki01AMY","JewelAss01","JewelAss","JewelSec01","JewelThief","JimmyBoston","JimmyDisanto","JoeMinuteman","Josef","Josh","Juggalo01AFY","Juggalo01AMY","KerryMcintosh","KorBoss01GMM","Korean01GMY","Korean02GMY","KorLieut01GMY","KTown01AFM","KTown01AFO","KTown01AMM","KTown01AMO","KTown01AMY","KTown02AFM","KTown02AMY","LamarDavis","Lathandy01SMM","Latino01AMY","Lazlow","LesterCrest","LifeInvad01","LifeInvad01SMM","LifeInvad02","LineCookSMM","Lost01GFY","Lost01GMY","Lost02GMY","Lost03GMY","LSMetro01SMM","Magenta","Maid01SFM","Malibu01AMM","Mani","Manuel","Mariachi01SMM","Markfost","Marnie","MartinMadrazoCutscene","Maryann","Maude","MethHead01AMY","MexBoss01GMM","MexBoss02GMM","MexCntry01AMM","MexGang01GMY","MexGoon01GMY","MexGoon02GMY","MexGoon03GMY","MexLabor01AMM","Mexthug01AMY","Michael","Migrant01SFY","Migrant01SMM","MilitaryBum","Milton","MimeSMY","Miranda","Mistress","Misty01","Molly","Motox01AMY","Motox02AMY","MovieStar","MovPrem01SFY","MovPrem01SMM","MPros01","MrK","MrsPhillips","MrsThornhill","Natalia","NervousRon","Nigel","OGBoss01AMM","OldMan1A","OldMan2","Omega","Oneil","Ortega","OscarCutscene","Paige","Paparazzi01AMM","Paparazzi","Paper","Party01","PartyTarget","Patricia","Pilot01SMM","PoloGoon01GMY","PoloGoon02GMY","Polynesian01AMM","Polynesian01AMY","Popov","PoppyMich","PornDudesCutscene","Postal01SMM","Postal02SMM","Priest","Princess","PrologueDriver","PrologueHostage01","PrologueHostage01AFM","PrologueHostage01AMM","PrologueMournFemale01","PrologueMournMale01","RampGang","RampHic","RampHipster","RampMarineCutscene","RampMex","RivalPaparazzi","RoadCyc01AMY","Robber01SMY","RoccoPelosi","Runner01AFY","Runner01AMY","Runner02AMY","RurMeth01AFY","RurMeth01AMM","RussianDrunk","Salton01AFM","Salton01AFO","Salton01AMM","Salton01AMO","Salton01AMY","Salton02AMM","Salton03AMM","Salton04AMM","SalvaBoss01GMY","SalvaGoon01GMY","SalvaGoon02GMY","SalvaGoon03GMY","SBikeAMO","SCDressy01AFY","ScreenWriter","ShopHighSFM","ShopLowSFY","ShopMaskSMY","ShopMidSFY","SiemonYetarian","Skater01AFY","Skater01AMM","Skater01AMY","Skater02AMY","Skidrow01AFM","SkidRow01AMM","SoCenLat01AMM","Solomon","SouCent01AFM","SouCent01AFO","SouCent01AFY","SouCent01AMM","SouCent01AMO","SouCent01AMY","SouCent02AFM","SouCent02AFO","SouCent02AFY","SouCent02AMM","SouCent02AMO","SouCent02AMY","SouCent03AFY","SouCent03AMM","SouCent03AMO","SouCent03AMY","SouCent04AMM","SouCent04AMY","SouCentMC01AFM","SpyActor","SpyActress","StBla01AMY","Stbla02AMY","SteveHain","StLat01AMY","StLat02AMM","Stretch","StrPreach01SMM","StrPunk01GMY","StrPunk02GMY","StrVend01SMM","StrVend01SMY","StWhi01AMY","StWhi02AMY","SunBathe01AMY","SweatShop01SFM","SweatShop01SFY","Talina","Tanisha","TaoCheng","TaosTranslator","TapHillBilly","Tattoo01AMO","Tennis01AFY","Tennis01AMM","TennisCoach","Terry","TomCutscene","TomEpsilon","Tonya","Tourist01AFM","Tourist01AFY","Tourist01AMM","Tourist02AFY","TracyDisanto","Tramp01","Tramp01AFM","Tramp01AMM","Tramp01AMO","TrampBeac01AFM","TrampBeac01AMM","TranVest02AMM","Trevor","Trucker01SMM","TylerDixon","UndercoverCopCutscene","UPS01SMM","UPS02SMM","Vagos01GFY","VagosFun01","VagosSpeak","Valet01SMY","VinDouche01AMY","Vinewood01AFY","VineWood01AMY","Vinewood02AFY","VineWood02AMY","Vinewood03AFY","Vinewood03AMY","Vinewood04AFY","Vinewood04AMY","Wade","Waiter01SMY","WeiCheng","WillyFist","WinClean01SMY","XMech01SMY","XMech02SMY","Yoga01AFY","Yoga01AMY","Zimbor"];

let character = new Character();
function Character () {
    this.type = true;
    this.ped = Math.floor(Math.random() * skinList.length);
    this.heritage = {
        mom: 21,
        dad: 0,
        shapemix: 0.5,
        skinmix: 0.5
    };
    this.eyeColor = 0;
    this.hairData = {
        style: 0,
        color: 0,
        highlight: 0,
        eyebrow: 34,
        eyebrowColor: 0,
        facialHair: 29,
        facialHairColor: 0
    };
    this.details = {
        blemishes: 255,
        ageing: 255,
        complexion: 255,
        sunDamage: 255,
        freckles: 255,
        bodyBlemishes: 255,
        isBodyBlemishesOn: false
    };

    this.outfit = 0;
    this.gender = false;
    // this.gender = resourceCall("getGender");
    if (this.gender) {
        document.getElementById("resemblance").setAttribute("min", 0.4);
        document.getElementById("resemblance").setAttribute("value", 0.7);
    } else {
        document.getElementById("resemblance").setAttribute("max", 0.6);
        document.getElementById("resemblance").setAttribute("value", 0.3);
        document.getElementById("facialhair").style.display = "none";
    }

    this.save = function(freemode) { if (character.type) resourceCall("saveCharacter", JSON.stringify(this)); else resourceCall("savePed", skinList[this.ped]); }
    this.setHeritage = function() { resourceCall("setHeritage", JSON.stringify(this.heritage)); }
    this.setEyeColor = function() { resourceCall("setEyeColor", this.eyeColor); }
    this.setHairData = function() { resourceCall("setHairData", JSON.stringify(this.hairData), this.hairData.style); }
    this.setDetails = function() { resourceCall("setDetails", JSON.stringify(this.details)); }
    this.setOutfit = function() { resourceCall("setOutfit", this.outfit); }
    this.setPed = function(freemode) { if (freemode) resourceCall("setFreemodePed", JSON.stringify(this)); else resourceCall("setPed", skinList[this.ped]); }
}

function switchTab(tab, element, color) {
    let i, contents, links;
    contents = document.getElementsByClassName("tab");
    links = document.getElementsByClassName("tablink");
    for (i = 0; i < links.length; i++) {
        links[i].style.backgroundColor = "";
    }
    for (i= 0; i < contents.length; i++) {
        contents[i].style.display = "none";
    }
    if (element.parentElement.id == "freemode-nav") document.getElementById("freemode-button").style.backgroundColor = "#9147e5";
    if (element.id == "gta-button") document.getElementById("freemode-nav").style.display = "none"; else document.getElementById("freemode-nav").style.display = "block";
    document.getElementById(tab).style.display = "block";
    element.style.backgroundColor = color;
}

function showSelector(parent) {
    let frame = document.getElementById("parentselector");
    frame.contentWindow.postMessage(parent, '*');
    frame.style.display = "block";
    this.selectedParent = parent;
}

window.addEventListener("message", function(event) {
    let element = document.getElementById(this.selectedParent);
    element.style.backgroundImage = "url(parents/Face-" + event.data + ".jpg)"
    if (this.selectedParent == "mom") character.heritage.mom = event.data; else character.heritage.dad = event.data;
    character.setHeritage();
});

document.getElementById("resemblance").onchange = function() {
    character.heritage.shapemix = this.value;
    character.setHeritage();
}

document.getElementById("skintone").onchange = function() {
    character.heritage.skinmix = this.value;
    character.setHeritage();
}

document.getElementById("eyecolor-left").onclick = function() {
    if (character.eyeColor > 0) character.eyeColor--; else character.eyeColor = 8;
    character.setEyeColor();
}

document.getElementById("eyecolor-right").onclick = function() {
    if (character.eyeColor < 8) character.eyeColor++; else character.eyeColor = 0;
    character.setEyeColor();
}

document.getElementById("hairstyle-left").onclick = function() {
    let styleMax;
    if (character.gender) styleMax=36; else styleMax=38;
    if (character.hairData.style > 0) character.hairData.style--; else character.hairData.style = styleMax;
    if (!character.hairData.style){
        document.getElementById("haircolor").style.display = "none";
    }
    else document.getElementById("haircolor").style.display = "block";
    character.setHairData();
}

document.getElementById("hairstyle-right").onclick = function() {
    let styleMax;
    if (character.gender) styleMax=36; else styleMax=38;
    if (character.hairData.style < styleMax) character.hairData.style++; else character.hairData.style = 0;
    if (!character.hairData.style){
        document.getElementById("haircolor").style.display = "none";
    }
    else document.getElementById("haircolor").style.display = "block";
    character.setHairData();
}

document.getElementById("haircolor-left").onclick = function() {
    if (character.hairData.color > 0) character.hairData.color--; else character.hairData.color = 63;
    character.setHairData();
}

document.getElementById("haircolor-right").onclick = function() {
    if (character.hairData.color < 63) character.hairData.color++; else character.hairData.color = 0;
    character.setHairData();
}

document.getElementById("highlight-left").onclick = function() {
    if (character.hairData.highlight > 0) character.hairData.highlight--; else character.hairData.highlight = 63;
    character.setHairData();
}

document.getElementById("highlight-right").onclick = function() {
    if (character.hairData.highlight < 63) character.hairData.highlight++; else character.hairData.highlight = 0;
    character.setHairData();
}

document.getElementById("eyebrow-left").onclick = function() {
    if (character.hairData.eyebrow > 0) character.hairData.eyebrow--; else character.hairData.eyebrow = 34;
    if (character.hairData.eyebrow == 34){
        document.getElementById("browcolor").style.display = "none";
        document.getElementById("eyebrow").setAttribute("class", "component");
    } else {
        document.getElementById("browcolor").style.display = "inline-block";
        document.getElementById("eyebrow").setAttribute("class", "component double");
    }
    character.setHairData();
}

document.getElementById("eyebrow-right").onclick = function() {
    if (character.hairData.eyebrow < 34) character.hairData.eyebrow++; else character.hairData.eyebrow = 0;
    if (character.hairData.eyebrow == 34){
        document.getElementById("browcolor").style.display = "none";
        document.getElementById("eyebrow").setAttribute("class", "component");
    } else {
        document.getElementById("browcolor").style.display = "inline-block";
        document.getElementById("eyebrow").setAttribute("class", "component double");
    }
    character.setHairData();
}

document.getElementById("browcolor-left").onclick = function() {
    if (character.hairData.eyebrowColor > 0) character.hairData.eyebrowColor--; else character.hairData.eyebrowColor = 63;
    character.setHairData();
}

document.getElementById("browcolor-right").onclick = function() {
    if (character.hairData.eyebrowColor < 63) character.hairData.eyebrowColor++; else character.hairData.eyebrowColor = 0;
    character.setHairData();
}

document.getElementById("facialhair-left").onclick = function() {
    console.log("before: " + character.hairData.facialHair);
    if (character.hairData.facialHair > 0) character.hairData.facialHair--; else character.hairData.facialHair = 29;
    if (character.hairData.facialHair == 29) {
        document.getElementById("facialcolor").style.display = "none";
        document.getElementById("facialstyle").setAttribute("class", "component");
    } else {
        document.getElementById("facialcolor").style.display = "inline-block";
        document.getElementById("facialstyle").setAttribute("class", "component double");
    }
    character.setHairData();
}

document.getElementById("facialhair-right").onclick = function() {
    if (character.hairData.facialHair < 29) character.hairData.facialHair++; else character.hairData.facialHair = 0;
    if (character.hairData.facialHair == 29) {
        document.getElementById("facialcolor").style.display = "none";
        document.getElementById("facialstyle").setAttribute("class", "component");
    } else {
        document.getElementById("facialcolor").style.display = "inline-block";
        document.getElementById("facialstyle").setAttribute("class", "component double");
    }
    character.setHairData();
}

document.getElementById("facialcolor-left").onclick = function() {
    if (character.hairData.facialHairColor > 0) character.hairData.facialHairColor--; else character.hairData.facialHairColor = 63;
    character.setHairData();
}

document.getElementById("facialcolor-right").onclick = function() {
    if (character.hairData.facialHairColor < 63) character.hairData.facialHairColor++; else character.hairData.facialHairColor = 0;
    character.setHairData();
}

document.getElementById("blemishes-left").onclick = function() {
    if (document.getElementById("blemishes-switch").checked) {
        if (character.details.blemishes > 0) character.details.blemishes--; else character.details.blemishes = 23;
    }
    character.setDetails();
}

document.getElementById("blemishes-right").onclick = function() {
    if (document.getElementById("blemishes-switch").checked) {
        if (character.details.blemishes < 23) character.details.blemishes++; else character.details.blemishes = 0;
    }
    character.setDetails();
}

document.getElementById("blemishes-switch").onclick = function() {
    if (this.checked) character.details.blemishes = 0; else character.details.blemishes = 255;
    character.setDetails();
}

document.getElementById("ageing-left").onclick = function() {
    if (document.getElementById("ageing-switch").checked) {
        if (character.details.ageing > 0) character.details.ageing--; else character.details.ageing = 14;
    }
    character.setDetails();
}

document.getElementById("ageing-right").onclick = function() {
    if (document.getElementById("ageing-switch").checked) {
        if (character.details.ageing < 14) character.details.ageing++; else character.details.ageing = 0;
    }
    character.setDetails();
}

document.getElementById("ageing-switch").onclick = function() {
    if (this.checked) character.details.ageing = 0; else character.details.ageing = 255;
    character.setDetails();
}

document.getElementById("complexion-left").onclick = function() {
    if (document.getElementById("complexion-switch").checked) {
        if (character.details.complexion > 0) character.details.complexion--; else character.details.complexion = 11;
    }
    character.setDetails();
}

document.getElementById("complexion-right").onclick = function() {
    if (document.getElementById("complexion-switch").checked) {
        if (character.details.complexion < 11) character.details.complexion++; else character.details.complexion = 0;
    }
    character.setDetails();
}

document.getElementById("complexion-switch").onclick = function() {
    if (this.checked) character.details.complexion = 0; else character.details.complexion = 255;
    character.setDetails();
}

document.getElementById("freckles-left").onclick = function() {
    if (document.getElementById("freckles-switch").checked) {
        if (character.details.freckles > 0) character.details.freckles--; else character.details.freckles = 11;
    }
    character.setDetails();
}

document.getElementById("freckles-right").onclick = function() {
    if (document.getElementById("freckles-switch").checked) {
        if (character.details.freckles < 11) character.details.freckles++; else character.details.freckles = 0;
    }
    character.setDetails();
}

document.getElementById("freckles-switch").onclick = function() {
    if (this.checked) character.details.freckles = 0; else character.details.freckles = 255;
    character.setDetails();
}

document.getElementById("sundamage-left").onclick = function() {
    if (document.getElementById("sundamage-switch").checked) {
        if (character.details.sunDamage > 0) character.details.sunDamage--; else character.details.sunDamage = 10;
    }
    character.setDetails();
}

document.getElementById("sundamage-right").onclick = function() {
    if (document.getElementById("sundamage-switch").checked) {
        if (character.details.sunDamage < 10) character.details.sunDamage++; else character.details.sunDamage = 0;
    }
    character.setDetails();
}

document.getElementById("sundamage-switch").onclick = function() {
    if (this.checked) character.details.sunDamage = 0; else character.details.sunDamage = 255;
    character.setDetails();
}

document.getElementById("outfit-left").onclick = function() {
    if (character.outfit < 0) {
        if (!character.gender) character.outfit = femaleOutfitMax - 1; else character.outfit = maleOutfitMax - 1;
    } else character.outfit--;
    character.setOutfit();
}

document.getElementById("outfit-right").onclick = function() {
    if (!character.gender) {
        if (character.outfit < femaleOutfitMax - 1) character.outfit++; else character.outfit = 0;
    } else {
        if (character.outfit < maleOutfitMax - 1) character.outfit++; else character.outfit = 0;
    }
    character.setOutfit();
}

document.getElementById("gta-left").onclick = function() {
    if (character.ped > 0) character.ped--; else character.ped = skinList.length - 1;
    character.setPed(false);
}
document.getElementById("gta-right").onclick = function() {
    if (character.ped < skinList.length - 1) character.ped++; else character.ped = 0;
    character.setPed(false);
}

// document.getElementById("native-left").onclick = function() {
// }
// document.getElementById("native-right").onclick = function() {
// }
// document.getElementById("native-switch").onclick = function() {
// }

document.getElementById("face").onmouseenter = function() { resourceCall("switchCamera", true); }
document.getElementById("face").onmouseleave = function() { resourceCall("switchCamera", false); }
document.getElementById("appearance").onmouseenter = function() { resourceCall("switchCamera", true); }
document.getElementById("appearance").onmouseleave = function() { resourceCall("switchCamera", false); }

document.getElementById("save").onclick = function() { character.save(); }

document.getElementsByClassName("tablink")[0].onclick = function () {
    switchTab('gta-tab', this, '#68e552');
    character.type = false;
    character.setPed(false);
};
document.getElementsByClassName("tablink")[1].onclick = function () {
    switchTab('freemode-tab', this, '#9147e5');
    character.type = true;
    character.setPed(true);
};
document.getElementsByClassName("tablink")[2].onclick = function () { switchTab('face', this, '#AF7EE6') };
document.getElementsByClassName("tablink")[3].onclick = function () { switchTab('appearance', this, '#AF7EE6') };
document.getElementsByClassName("tablink")[4].onclick = function () { switchTab('outfit', this, '#AF7EE6') };
document.getElementsByClassName("tablink")[1].click();
document.getElementsByClassName("tablink")[2].click();
