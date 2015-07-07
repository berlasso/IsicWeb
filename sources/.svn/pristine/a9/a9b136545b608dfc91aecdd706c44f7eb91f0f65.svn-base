// JScript source code

function reloadScripts(toRefreshList, key) {
    var scripts = document.getElementsByTagName('script');
    for (var i = 0; i < scripts.length; i++) {
        var aScript = scripts[i];
        for (var j = 0; j < toRefreshList.length; j++) {
            var toRefresh = toRefreshList[j];
            if (aScript.src && (aScript.src.indexOf(toRefresh) > -1)) {
                new_src = aScript.src.replace(toRefresh, toRefresh + '?k=' + key);
                // console.log('Force refresh on cached script files. From: ' + aScript.src + ' to ' + new_src)
                aScript.src = new_src;
            }
        }
    }
}
