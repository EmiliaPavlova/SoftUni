<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Show Annual Expenses</title>
    <style>
        table {
            margin: 10px;
        }

        thead {
            font-weight: bold;
        }

        td, th {
            padding: 5px;
            text-align: center;
        }

        table, tr, td, th {
            border: 1px solid black;
        }

    </style>
</head>
<body>
<form action="3.AnnualExpenses.php" method="post">
    <label for="input">Enter number of years:</label>
    <input type="text" name="years" id="input">
    <input type="submit" name="submit" id="submit" value="Show costs">
</form>

<?php
if (isset($_POST['submit']) && $_POST['years'] != ''):
    $count = intval($_POST['years']);
    date_default_timezone_set("Europe/Sofia");
    $year = date('Y');
?>
    <table>
        <thead>
            <tr>
                <th>Year</th>
                <th>January</th>
                <th>February</th>
                <th>March</th>
                <th>April</th>
                <th>May</th>
                <th>June</th>
                <th>July</th>
                <th>August</th>
                <th>September</th>
                <th>October</th>
                <th>November</th>
                <th>December</th>
                <th>Total</th>
            </tr>
        </thead>
        <tbody>

        <?php
        for($i = $year; $i > $year - $count; $i--):
        ?>
            <tr>
                <td><?php echo $i; ?></td>

                <?php
                $total = 0;
                for($month = 0; $month <= 11; $month++):
                    $costs = rand(0, 999);
                    $total += $costs;
                ?>
                <td><?php echo $costs; ?></td>
                <?php endfor; ?>
                <td><?php echo $total ?></td>
            </tr>
        <?php endfor; ?>
        </tbody>
    </table>
<?php endif; ?>

</body>
</html>
