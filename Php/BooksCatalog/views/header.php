<!DOCTYPE html>
<html>
    <head>
        <title><?= $data['title']; ?></title>
        <meta charset="UTF-8">       
    </head>
    <body>
        <?php
        if (!isset($_SESSION['username'])) {
            echo '<a href="index.php?login">Login</a>
                <a href="index.php?register">Register</a>';
        } else {
            echo '<span>' . $_SESSION['username'] . '</span>';
            echo '<a href="#">Logout</a>';
        }
        ?>