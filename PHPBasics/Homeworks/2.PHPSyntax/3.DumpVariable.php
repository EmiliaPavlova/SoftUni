<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Sum Two Numbers</title>
</head>
<body>
    <?php
    function isNumber($var) {
        if (is_numeric($var)) {
            var_dump($var);
        } else {
            echo gettype($var) . "</br>";
        }
    }

    isNumber("hello");
    isNumber(15);
    isNumber(1.234);
    isNumber(array(1,2,3));
    isNumber((object)[2,34]);
    ?>
</body>
</html>