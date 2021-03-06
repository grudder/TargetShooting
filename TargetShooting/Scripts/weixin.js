var _rootUrl = "http://foton.unisw.com";

$(function () {
    weixinInit();
});

function weixinInit() {
    var desc = "史上最靠谱送礼游戏，拼手气，福田汽车送公仔送到手软！";
    var link = _rootUrl;

    // 微信分享
    window.shareData = {
        "imgUrl": _rootUrl + "/img/app.jpg",
        "timeLineLink": link,
        "tTitle": "福田微信打靶",
        "tContent": desc
    };

    document.addEventListener('WeixinJSBridgeReady', function onBridgeReady() {
        WeixinJSBridge.call('hideToolbar');
        WeixinJSBridge.on('menu:share:appmessage', function (argv) {
            WeixinJSBridge.invoke('sendAppMessage', {
                "img_url": window.shareData.imgUrl,
                "link": window.shareData.timeLineLink,
                "desc": window.shareData.tContent,
                "title": window.shareData.tTitle
            }, onShareComplete);
        });

        WeixinJSBridge.on("menu:share:timeline", function (argv) {
            WeixinJSBridge.invoke("shareTimeline", {
                "img_url": window.shareData.imgUrl,
                "link": window.shareData.timeLineLink,
                "title": window.shareData.tContent,
                "desc": window.shareData.tTitle
            }, onShareComplete);
        });
    }, false);

    function onShareComplete() {
    }
}
