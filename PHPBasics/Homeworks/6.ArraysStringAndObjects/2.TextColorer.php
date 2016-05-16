<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Coloring Texts</title>
    <style>
        textarea {
            width: 600px;
            display: block;
        }
        .red {
            color: red;
        }
        .blue {
            color: blue;
        }
    </style>
</head>
<body>
<form action="2.TextColorer.php" method="post">
    <textarea id="input" name="input"></textarea>
    <input type="submit" name="submit" value="Color text" />
</form>

<p>
    <?php
    if (isset($_POST['submit']) && isset($_POST['input'])):
        $chars = str_split(($_POST['input']));
        foreach ($chars as $char):
            if (ord($char) % 2 === 0):
                ?>
                <span class="red"><?php echo $char . ' '; ?></span>
            <?php
            else:
            ?>
                <span class="blue"><?php echo $char . ' '; ?></span>
            <?php endif;
        endforeach;
    endif;
    ?>
</p>

</body>
</html>