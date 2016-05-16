<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Sidebar Builder</title>
    <style>
        label {
            margin: 10px;
            display: block;
        }
        input[type='text'] {
            width: 250px;
        }
        input[type='submit'] {
            margin-left: 10px;
        }
        section {
            padding: 5px;
            width: 150px;
            border-radius: 10px;
            border: 1px solid black;
            margin: 5px;
            background: linear-gradient(skyblue 50%, royalblue 100%);
        }
        h2 {
            border-bottom: 1px solid black;
        }
        ul {
            list-style-type: circle;
        }
        a {
            color: black;
        }
    </style>
</head>
<body>
<form action="3.SidebarBuilder.php" method="post">
    <label for="categories">Categories:
        <input type="text" name="categories" id="categories" value="Knitting, Cycling, Swimming, Dancing" />
    </label>
    <label for="tags">Tags:
        <input type="text" name="tags" id="tags" value="person, free time, love, peace, protest" />
    </label>
    <label for="months">Months:
        <input type="text" name="months" id="months" value="April, May, June, July" />
    </label>
    <input type="submit" name="submit" value="Generate" />
</form>

<?php
if (isset($_POST['submit']) && isset($_POST['categories']) && isset($_POST['tags']) && isset($_POST['months'])):
    $categories = explode(', ', ($_POST['categories']));
    $tags = explode(', ', ($_POST['tags']));
    $months = explode(', ', ($_POST['months']));
?>
    <section>
        <h2>Categories</h2>
        <ul>
            <?php
            foreach ($categories as $link):
            ?>
                <li><a href="#"><?php echo htmlentities($link); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </section>


    <section>
        <h2>Tags</h2>
        <ul>
            <?php
            foreach ($tags as $link):
                ?>
                <li><a href="#"><?php echo htmlentities($link); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </section>

    <section>
        <h2>Months</h2>
        <ul>
            <?php
            foreach ($months as $link):
                ?>
                <li><a href="#"><?php echo htmlentities($link); ?></a></li>
            <?php endforeach; ?>
        </ul>
    </section>
<?php endif; ?>

</body>
</html>