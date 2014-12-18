var _rootUrl = "http://foton.unisw.com";

$(function () {
    weixinInit();
});

function weixinInit() {
    var desc = "【松塔礼盒装买买买】马年末尾我们一起捣塔，像只松鼠一样！";
    var link = _rootUrl;

    // 微信分享
    window.shareData = {
        "imgUrl": _rootUrl + "/img/app.jpg",
        "timeLineLink": link,
        "tTitle": "做一个专注的吃货",
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
