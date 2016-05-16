<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Rich People&#39;s Problems</title>
    <style>
        table {
            margin: 10px;
        }

        td {
            padding: 5px;
            text-align: center;
        }

        table, tr, td, th {
            border: 1px solid black;
        }

    </style>
</head>
<body>
<form action="2.CarRandomizer.php" method="post">
    <label for="input">Enter cars</label>
    <input type="text" name="cars" id="input">
    <input type="submit" name="submit" id="submit" value="Show result">
</form>

<?php
    $colors = ["pink", "yellow", "gray", "black", "red", "mocha", "blue", "green", "brown", "purple"];
if (isset($_POST['submit']) && $_POST['cars'] != ''):
    ?>
    <table>
        <thead>
            <tr>
                <th>Car</th>
                <th>Color</th>
                <th>Count</th>
            </tr>
        </thead>
        <tbody>

        <?php
        $cars = explode(", ", $_POST['cars']);
        foreach ($cars as $car):
            $color = $colors[rand(0, count($colors) - 1)];
            $count = rand(1, 5);

        ?>
            <tr>
                <td><?php echo htmlentities($car) ?></td>
                <td><?php echo $color ?></td>
                <td><?php echo $count ?></td>
            </tr>
        <?php endforeach ?>
        </tbody>
    </table>
<?php endif; ?>

</body>
</html>


