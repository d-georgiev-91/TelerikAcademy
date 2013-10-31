<?php
$pageTitle = 'Всички разходи';
include 'header.php';

$filterType = NULL;

if ($_GET) {
    $filterType = $_GET['filter-type'];
    if ($filterType != 0 && !array_key_exists($filterType, $expenses)) {
        echo '<p id="error-reporter">Invalid expense type!</p>';
    }
}
?>
<nav>
    <a href="form.php">Добави нов разход</a>
</nav>
<section>
    <form method="GET">
        <select name="filter-type">
            <option value="0">Всички</option>
            <?php
            foreach ($expenses as $key => $value) {
                if ($filterType == $key) {
                    echo '<option value="' . $key . '"selected>' . $value . '</option>';
                } else {
                    echo '<option value="' . $key . '">' . $value . '</option>';
                }
            }
            ?>
        </select>
        <input type="submit" value="Филтрирай" />
    </form>
    <table>
        <thead>
        <th>Дата</th>
        <th>Име</th>
        <th>Сума</th>
        <th>Вид</th>
        </thead>
        <tbody>
            <?php
            $totalSum = 0.0;
            if (file_exists($dataPath)):
                $data = file($dataPath);
                foreach ($data as $jsonRecord) {
                    $areRecords = true;
                    $currentRecord = json_decode($jsonRecord, true);
                    $currentExpenseType = $currentRecord['selectedExpenseType'];
                    if ($filterType && $currentExpenseType != $filterType) {
                        continue;
                    }
                    $date = $currentRecord['date'];
                    $name = $currentRecord['name'];
                    $sum = $currentRecord['sum'];
                    $expense = $expenses[$currentExpenseType];
                    $totalSum += $sum;
                    ?>
                    <tr>
                        <td><?php echo $date; ?></td>
                        <td><?php echo $name; ?></td>
                        <td><?php echo $sum; ?></td>
                        <td><?php echo trim($expense); ?></td>
                    </tr>
                    <?php
                }
            endif;
            ?>
        </tbody>
        <tfoot>
            <tr>
                <td>----</td>
                <td>----</td>
                <td><?php echo $totalSum; ?></td>
                <td>----</td>
            </tr>
        </tfoot>
    </table>
</section>
<?php
include 'footer.php';
?>