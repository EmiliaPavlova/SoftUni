<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Sum of Digits</title>
    <style>
        table {
            margin: 10px;
        }

        table, tr, td, th {
            border: 1px solid black;
        }

    </style>
</head>
<body>
<form action="5.SumOfDigits.php" method="post">
    <label for="input">Input string:</label>
    <input type="text" name="integers" id="input">
    <input type="submit" name="submit" id="submit" value="Submit">
</form>


<table>
<?php
if(isset($_POST['submit']) && $_POST['integers'] != ''):
    $input = explode(", ", $_POST['integers']);
    foreach ($input as $num):
        $sum = 0;
    ?>
        <tr>
            <td><?php echo $num; ?></td>
            <td>
                <?php
                if (is_numeric($num)):
                    while ($num > 0) {
                        $sum += $num % 10;
                        $num /= 10;
                    }
                    echo $sum;
                else:
                    echo "I cannot sum that";
                endif; ?>
            </td>
        </tr>
    <?php
    endforeach;
endif
?>
</table>

</body>
</html>