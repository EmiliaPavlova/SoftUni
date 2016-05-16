<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Calculate Interest</title>
</head>
<body>

<?php
echo "<form action='#' method='post'>";
echo "<label for='money'>Enter Amount </label>";
echo "<input type='text' name='money' id='money' value='1000' pattern='[0-9]+\.?[0-9]+' /><br />";
echo "<input type='radio' name='currency' value='usd' checked />USD";
echo "<input type='radio' name='currency' value='eur' />EUR";
echo "<input type='radio' name='currency' value='bgn' />BGN<br />";
echo "<label for='interest'>Compound Interest Amount </label>";
echo "<input type='text' name='interest' id='interest' value='12' pattern='[0-9]+\.?[0-9]+' /><br />";
echo "<select name='time'>";
    echo "<option value='6' selected>6 Months</option>";
    echo "<option value='12'>1 Year</option>";
    echo "<option value='24'>2 Years</option>";
    echo "<option value='60'>5 Years</option>";
echo "</select>";
echo " <input type='submit' name='submit' value='Calculate'/> ";

if(isset($_POST['submit'])) {
    $money = floatval(htmlentities($_POST['money']));
    $currency = $_POST['currency'];
    $interest = floatval(htmlentities($_POST['interest']))/12;
    $time = $_POST['time'];
    $percent = (100 + $interest)/100;
    for($i = 0; $i < $time; $i++){
        $money *= $percent;
    }
    if ($currency == "usd") {
        echo '$ ' . number_format($money, 2);
    } else if ($currency == "eur") {
        $unicodeChar = '\u20AC ';
        echo json_decode('"'.$unicodeChar.'"') . " " . number_format($money, 2);
    } else {
        echo number_format($money, 2) . " лв.";
    }
}
echo "</form>";

?>
</body>
</html>
