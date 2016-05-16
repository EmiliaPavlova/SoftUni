<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>HTML Table</title>
    <link rel="stylesheet" type="text/css" href="6.style.css">
</head>
<body>
    <?php
    function buildTable($name, $phone, $age, $address) {
        echo "<table>";
        echo "<tr><th>Name</th><td>$name</td></tr>";
        echo "<tr><th>Phone number</th><td>$phone</td></tr>";
        echo "<tr><th>Age</th><td>$age</td></tr>";
        echo "<tr><th>Address</th><td>$address</td></tr>";
        echo "</table><br/>";
    }
    buildTable("Gosho", "0882-321-423", 24, "Hadji Dimitar");
    buildTable("Pesho", "0884-888-888", 67, "Suhata Reka");
    ?>
</body>
</html>