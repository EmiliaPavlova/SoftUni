<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Non-Repeating Digits</title>
</head>
<body>
    <?php
    function nonRepeatingDigits($N) {
        $max = min(987, $N);
        $result = array();
        for ($i = 102; $i <= $max; $i += 1) {
            $first = floor($i / 100);
            $second = floor($i / 10) % 10;
            $third = $i % 10;

            if ($first != $second && $second != $third && $third != $first) {
                array_push($result, $i);
            }
        }
        if (sizeof($result) > 0) {
            echo join(', ', $result) . '</br></br>';
        } else {
            echo 'no' . '</br></br>';
        }
    }

    nonRepeatingDigits(1234);
    nonRepeatingDigits(145);
    nonRepeatingDigits(15);
    nonRepeatingDigits(247);
    ?>
</body>
</html>