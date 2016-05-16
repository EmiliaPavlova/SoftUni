<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Most Frequent Tag</title>
</head>
<body>

<?php
echo "<form action='2.MostFrequentTag.php' method='get'>";
echo "<input type='text' name='input' value='Pesho, homework, homework, exam, course, PHP' />";
echo "<input type='submit' name='submit' value='Submit'/>";
echo "</form>\n";

if (isset($_GET['submit'])) {
//    var_dump($_GET);
    $tags = explode(", ", htmlentities($_GET['input']));
    $result = [];
    $maxValue = 0;
    foreach ($tags as $value) {
        $value = trim($value);
        if(!isset($result[$value])) {
            $result[$value] = 1;
        } else {
            $result[$value] ++;
        }
    }
//    var_dump($result);
    arsort($result);
    foreach ($result as $key => $value) {
        echo "$key: $value <br />";
        $maxValue = max($maxValue, $value);
    }
    $mostFreqTag = array_keys($result, $maxValue);
    echo "<br />Most Frequent Tag is: " . implode(', ', $mostFreqTag);
}
?>
</body>
</html>
