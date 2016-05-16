<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Print Tags</title>
</head>
<body>

    <?php
    echo "<form action='1.PrintTags.php' method='get'>";
    echo "<input type='text' name='input' value='Pesho, homework, homework, exam, course, PHP' />";
    echo "<input type='submit' name='submit' value='Submit'/>";
    echo "</form>\n";

    if (isset($_GET['submit'])) {
        $tags = explode(", ", htmlentities($_GET['input']));
        for ($i = 0; $i < count($tags); $i++) {
            echo "$i : $tags[$i] <br />";
        }
    }
    ?>
</body>
</html>