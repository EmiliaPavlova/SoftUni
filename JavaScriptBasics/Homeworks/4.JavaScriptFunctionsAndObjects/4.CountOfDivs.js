function countDivs(html) {
    var openTags = html.split(/<div[^<]/g).length - 1;
    //not necessary - only for double check:
    var closeTags = html.split(/<\/div>/g).length - 1;
    if (openTags === closeTags) {
        console.log(openTags)
    }
}

countDivs('<!DOCTYPE html>\
<html>\
<head lang="en">\
<meta charset="UTF-8">\
<title>index</title>\
<script src="/yourScript.js" defer></script>\
</head>\
<body>\
<div id="outerDiv">\
<div\
class="first">\
<div><div>hello</div></div>\
</div>\
<div>hi<div></div></div>\
<div>I am a div</div>\
</div>\
</body>\
</html>')