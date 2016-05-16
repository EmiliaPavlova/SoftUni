<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>Form Data</title>
    <link rel="stylesheet" type="text/css" href="7.style.css">
</head>
<body>
    <form action="7.GetFormData.php" method="post" name="user-data">
        <input type="text" name="name" id="name" placeholder="Name.." pattern="[A-Za-z\- ]+" required="required"/>
        <input type="text" name="age" id="age" placeholder="Age.." required="required" pattern="[0-9]+"/>
        <section>
            <input type="radio" name="gender" value="m" id="male" checked/>
            <label for="male">Male</label>
        </section>
        <section>
            <input type="radio" name="gender" value="f" id="female"/>
            <label for="female">Female</label>
        </section>
        <input type="submit" name="submit" value="Submit" />
    </form>

    <?php
    if(isset($_POST['submit'])) {
        $name = $_POST["name"];
        $age = $_POST["age"];
        $gender = $_POST["gender"] == 'm' ? "male" : "female";
        if ($name != '' && $age != '' && $gender != '') {
            echo "<p>My name is $name. I am $age years old. I am $gender.</p>";
        }
    }
    ?>

</body>
</html>