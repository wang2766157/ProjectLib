window.MD = function (text) {
    navigator.clipboard.writeText(text).then(function () { alert("已复制到剪贴板!"); })
        .catch(function (error) { alert(error); });
}

window.DownloadFileFun = function (url) {
    var anchor = document.createElement('a');
    anchor.href = url;
    //anchor.download = ''; // 如果需要指定文件名，在这里设置
    anchor.click();
    anchor.remove();
}

window.HLLoad = function () {
    hljs.highlightAll();
}