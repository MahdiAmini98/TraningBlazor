export function beforeServerStart() {
    //

    var script = document.createElement('script');
    script.src = 'js/beforeStartScript.js';
    document.head.appendChild(script);
    console.log("beforeServerStart لود شد");
}

export function afterServerStarted(balzor) {
    //
    var script = document.createElement('script');
    script.src = 'js/afterStartedScript.js';
    document.head.appendChild(script);
    console.log("afterStartedScript.js لود شد");

}