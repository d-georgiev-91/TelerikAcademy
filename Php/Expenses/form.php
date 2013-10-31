<?php
$pageTitle = 'Форма';
include 'header.php';
include 'functions/functions.php';

$errorMessage = null;

if ($_POST) {
    $name = $_POST['name'];
    $sum = $_POST['sum'];
    $selectedExpenseType = (int) $_POST['type'];

    if (!validateInput($name, $sum, $selectedExpenseType)) {
        echo '<p id="error-reporter">' . $errorMessage . '</p>';
    } else {
        $data = array('date' => date('d.m.Y'),
            'name' => $name, 
            'sum' => $sum, 
            'selectedExpenseType' => $selectedExpenseType);
        $jsonData = json_encode($data). PHP_EOL;

        if (file_put_contents($dataPath, $jsonData, FILE_APPEND)) {
            echo '<p id="success-message">Successfully added new expense.</p>';
        }
    }
}

function validateInput($name, $sum, $selectedExpenseType) {
    if (!validateName($name)) {
        global $errorMessage;
        $errorMessage = 'Name should be at least three characters long!';
        return false;
    }

    if (!validateSum($sum)) {
        global $errorMessage;
        $errorMessage = 'Sum should be a non negative number!';
        return false;
    }

    if (!validateSelectedExpenseType($selectedExpenseType)) {
        global $errorMessage;
        $errorMessage = 'Invalid expense type!';
        return false;
    }

    return true;
}
?>

<nav>
    <a href="index.php">Списък</a>
</nav>
<section>
    <form method="POST">
        <label for="name">
            Име: 
            <input id="name" name="name" type="text">
        </label>
        <label for="sum">
            Сума:
            <input id="sum" name="sum" type="text">
        </label>
        <label for="type">
            Тип: 
            <select id="type" name="type">
                <?php
                foreach ($expenses as $key => $value) {
                    echo '<option value="' . $key . '">' . $value . '</option>';
                }
                ?>
            </select>
        </label>
        <div>
            <input type="submit" value="Добави" >
        </div>
    </form>
</section>

<?php include 'footer.php'; ?>