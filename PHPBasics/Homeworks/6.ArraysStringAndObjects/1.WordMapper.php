<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Word Mapping</title>
    <style>
        textarea {
            width: 600px;
            display: block;
        }
        table {
            margin: 10px;
        }
        table, tr, td, th {
            border: 1px solid black;
        }
        td {
            padding: 5px;
        }
    </style>
</head>
<body>
<form action="1.WordMapper.php" method="post">
    <textarea id="input" name="input"></textarea>
    <input type="submit" name="submit" value="Count words" />
</form>

<?php
if (isset($_POST['submit']) && isset($_POST['input'])):
    preg_match_all("/\\w+/", strtolower($_POST['input']), $words);
    $result = array();
    foreach ($words[0] as $word) {
        if (!array_key_exists($word, $result)) {
            $result[$word] = 1;
        } else {
            $result[$word]++;
        }
    }
    ?>

    <table>
        <?php foreach($result as $key=>$value): ?>
            <tr>
                <td><?php echo htmlentities($key) ?></td>
                <td><?php echo $value ?></td>
            </tr>
        <?php endforeach; ?>
    </table>
<?php endif; ?>

</body>
</html>