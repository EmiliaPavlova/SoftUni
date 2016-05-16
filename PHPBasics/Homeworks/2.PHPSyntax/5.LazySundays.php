<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Lazy Sundays</title>
</head>
<body>
    <?php
    function getSundays($y, $m)
    {
        return new DatePeriod(
            new DateTime("first sunday of $m-$y"),
            DateInterval::createFromDateString('next sunday'),
            new DateTime("last day of $m-$y")
        );
    }

    foreach (getSundays(date("m Y")) as $sunday) {
        echo $sunday->format("jS F, Y") . "</br>";
    }

    ?>
</body>
</html>