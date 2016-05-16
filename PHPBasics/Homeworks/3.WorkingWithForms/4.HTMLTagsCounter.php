<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>HTML Tags Counter</title>
</head>
<body>

<?php
echo "<form action='#' method='post'>";
echo "<label for='input'>Enter HTML tags: </label><br />";
echo "<input type='text' name='tag' id='tag' />";
echo " <input type='submit' name='submit' value='Submit'/> ";
echo "</form>";

$validTags = ["!DOCTYPE","a","abbr","address","area","article","aside","audio","b","base","bdi","bdo","blockquote",
    "body","br","button","canvas","caption","cite","code","col","colgroup","datalist","dd","del","details","dfn",
    "dialog","div","dl","dt","em","embed","fieldset","figcaption","figure","footer","form","h1", "h2","h3","h4","h5",
    "h6","head","header","hgroup","hr","html","i","iframe","img","input","ins","kbd","keygen","label","legend","li",
    "link","main","map","mark","menu","menuitem","meta","meter","nav","noscript","object","ol","optgroup","option",
    "output","p","param","pre","progress","q","rp","rt","ruby","s","samp","script","section","select","small","source",
    "span","strong","style","sub","summary","sup","table","tbody","td","textarea","tfoot","th","thead","time","title",
    "tr","track","u","ul","var","video","wbr"];

session_start();
$result = '';
$_SESSION['count'];

if(isset($_POST['submit'])) {
    $tag = htmlentities($_POST['tag']);
    if (array_search($tag, $validTags) === false) {
        $result = 'Invalid HTML Tag!';
    } else {
        $result = 'Valid HTML Tag!';
        $_SESSION['count']++;
    }

    $score = $_SESSION['count'];
    echo "<h3>$result</h3>";
    echo "<h3>Score: $score</h3>";
}

?>
</body>
</html>