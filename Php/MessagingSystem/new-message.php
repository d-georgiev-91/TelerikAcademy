<?php
session_start();
$pageTitle = 'New message';
include './includes/header.php';

if (!isset($_SESSION['username'])) {
    header('Location: index.php');
    exit;
}

logout();

$users = getUsers();

if (!$users) {
    echo 'No users registered yet, you cannot send messages';
    exit;
}

try {
    sendMessage();
} catch (Exception $exc) {
    echo $exc->getMessage();
}

?>
<a href="messages.php">View messages</a>
<form method="POST">
    <input type="submit" name="logout" value="Logout" />
</form>
<form method="POST">
    <select name="selectedUser">
        <?php
        foreach ($users as $user) {
            if ($user['username'] == $_SESSION['username']) {
                continue;
            }
            
            echo '<option value="' . $user['userId'] . '">' . $user['username'] . '</option>';
        }
        ?>
    </select>
    <div>
        <label for="title">Title: </label>
        <input id="title" name="title" type="text" />
    </div>
    <div>
        <label for="message">Message: </label>
        <textarea id="message" name="message"></textarea>
    </div>
    <input type="submit" value="Send message" />
</form>
<?php include './includes/footer.php'; ?>