<?php
$text = str_split($_GET['text']); //Hi PHP5
$minFontSize = intval($_GET['minFontSize']); //4
$maxFontSize = intval($_GET['maxFontSize']); //8
$step = intval($_GET['step']);//3
$font = $minFontSize;
$fontSizeIncreasing = true;

foreach ($text as $sign) {

    isEven($sign, $font);

    if (ctype_alpha($sign)) {

        if ($font < $maxFontSize && $fontSizeIncreasing) {
            $font += $step;

            if ($font >= $maxFontSize) {
                $fontSizeIncreasing = false;
            }
        }

        else if ($font > $minFontSize && $fontSizeIncreasing === false) {
            $font -= $step;

            if ($font <= $minFontSize) {
                $fontSizeIncreasing = true;
            }
        }
    }
}

function isEven ($sign, $font) {
    $sign = htmlspecialchars($sign);
    if (ord($sign) % 2 == 0) {
        echo "<span style='font-size:$font;text-decoration:line-through;'>$sign</span>";
    } else {
        echo "<span style='font-size:$font;'>$sign</span>";
    }
}