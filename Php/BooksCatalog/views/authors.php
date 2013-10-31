<a href="index.php">Списък</a>
<a href="?add_book">Нова книга</a>
<form method="POST" action="index.php?p=authors">
    <label for="author-name">Име: </label>
    <input type="text" id="author-name" name="authorName" />
    <input type="submit" value="Добави" />    
</form>

<?php
if (count($data['authors']) > 0) {
    ?>
    <table>
        <thead>
            <tr><th>Автори</th></tr>
        </thead>
        <tbody>
            <?php
            foreach ($data['authors'] as $authorId => $authorName) {
                ?> 
                <tr>
                    <td>
                        <?php echo '<a href="index.php?author_id=' . $authorId . '">' . $authorName . '</a>' ?>
                    </td>
                </tr>
                <?php
            }
            ?>
        </tbody>
    </table>
    <?php
}
?>