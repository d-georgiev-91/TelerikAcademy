<?php
session_start();

$pageTitle = 'MyFiles';
include './includes/header.php';
?>

<a href="upload.php">Go to upload</a>

<?php
$currentUserStorage = $FILESTORAGE . DIRECTORY_SEPARATOR . $USERNAME;

if (!array_key_exists('isLogged', $_SESSION) || !$_SESSION['isLogged']) {
    echo '<h1>Forbidden</h1>';
} elseif (!realpath($currentUserStorage)) {
    echo '<p>Your directory is empty</p>';
} else {
    $files = scandir($currentUserStorage);
    echo '<ul>';
    foreach ($files as $file) {
        if ($file == '.' || $file == '..') {
            continue;
        }
        ?>
        <li>
            <a href="<?php echo $currentUserStorage.DIRECTORY_SEPARATOR.$file; ?>">
                <?php echo $file; ?>
            </a>
        </li>
        <?php
    }
    echo '</ul>';
}

include './includes/footer.php';
?>