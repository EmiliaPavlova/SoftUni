<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Find Primes in Range</title>
    <style>
    section {
        margin: 10px 0;
        width: 600px;
    }
    </style>
</head>
<body>
<form action="4.PrimesInRange.php" method="post">
    <label for="start">Starting Index:</label>
    <input type="text" name="start" id="start">
    <label for="end">End:</label>
    <input type="text" name="end" id="end">
    <input type="submit" name="submit" id="submit" value="Submit">
</form>

<section>

    <?php
    function isPrime($num) {
        if ($num < 2) {
            return false;
        } else if ($num == 2) {
            return true;
        } else {
            for ($divisor = 2; $divisor <= (int)sqrt($num); $divisor++) {
                if ($num % $divisor == 0) {
                    return false;
                }
            }
        }
        return true;
    }

    if(isset($_POST['submit']) &&
        $_POST['start'] != '' && $_POST['end'] != '' &&
        is_numeric($_POST['start']) && is_numeric($_POST['end'])):

        $start = $_POST['start'];
        $end = $_POST['end'];

        for ($i = $start; $i <= $end; $i++):
            if (isPrime($i)):
                ?>
                <strong><?php echo $i ?></strong>
            <?php else:
                echo $i;
            endif;

            if ($i != $end):
                echo ", ";
            endif;
        endfor;
    endif;
    ?>
</section>

</body>
</html>
