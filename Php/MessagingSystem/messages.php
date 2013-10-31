<?php

session_start();
$pageTitle = 'Messages';
include './includes/header.php';

if (!isset($_SESSION['username'])) {
    header('Location: index.php');
    exit;
}

echo $_SESSION['username'];

logout();
getMessages();
?>
<a href="new-message.php">Create new message</a>
<form method="POST">
    <input type="submit" name="logout" value="Logout" />
</form>
<?

if ($messages) {
    echo '<ul>';

    foreach ($messages as $message) {
        echo '<li>
                <h3>' . $message['title'] . '</h3>
                <p>from: "' . $message['author'] . '"</p>
                <p>sent on: ' . $message['dateCreated'] . '</p>
                <p>message: ' . $message['body'] . '</p>
            </li>';
    }

    echo '</ul>';
} else {
    echo '<p>You dont have any messages!</p>';
}
?>
<?php include './includes/footer.php'; ?>