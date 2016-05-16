<?php
$html = $_GET['html'];
$semanticTags = ["main", "header", "nav", "article", "section", "aside", "footer"];

preg_match_all('/<div.*?\b((id|class)\s*=\s*"(.*?)").*?>/', $html, $htmlArray);
preg_match_all('/<\/div>\s.*?(\w+)\s*-->/', $html, $tagArray);

//var_dump($htmlArray);
//var_dump($tagArray);

foreach ($htmlArray[0] as $key => $match) {
    if (in_array($htmlArray[3][$key], $semanticTags)) {
        $replaceTag = str_replace('div', $htmlArray[3][$key], $match);
        $replaceTag = str_replace($htmlArray[1][$key], '', $replaceTag);
        $replaceTag = preg_replace('/\s*>/', '>', $replaceTag);
        $replaceTag = preg_replace('/\s{2,}/', ' ', $replaceTag);
        $html = str_replace($match, $replaceTag, $html);
    }
}

foreach ($tagArray[0] as $key => $match) {
    $closingTag = $tagArray[1][$key];
    if (in_array($tagArray[1][$key], $semanticTags)) {
        $html = str_replace($match, "</$closingTag>", $html);
    }
}

echo $html;

