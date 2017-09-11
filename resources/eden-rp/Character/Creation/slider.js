var cc;
window.addEventListener("message", function(event) {
    cc = event.source;
    var wrapper = document.getElementById("wrapper");
    wrapper.innerHTML = "";
    if (event.data === "mom") {
        for (var i = 21; i < 42; i++) {
            var img = document.createElement("img");
            img.setAttribute("src", "parents/Face-" + i + ".jpg");
            img.setAttribute("onclick", "switchFace(" + i + ")");
            wrapper.appendChild(img);
        }
        var img = document.createElement("img");
        img.setAttribute("src", "parents/Face-45.jpg");
        img.setAttribute("onclick", "45");
        wrapper.appendChild(img);
    } else {
        for (var i = 0; i < 21; i++) {
            var img = document.createElement("img");
            img.setAttribute("src", "parents/Face-" + i + ".jpg");
            img.setAttribute("onclick", "switchFace(" + i + ")");
            wrapper.appendChild(img);
        }
        for (var i = 42; i < 45; i++) {
            var img = document.createElement("img");
            img.setAttribute("src", "parents/Face-" + i + ".jpg");
            img.setAttribute("onclick", "switchFace(" + i + ")");
            wrapper.appendChild(img);
        }
    }
});

function switchFace(face){
    cc.postMessage(face, '*');
}
