<a href="?p=authors">Автори</a>
<a href="?p=add_book">Нова книга</a>
<?php if (count($data['books']) > 0) {
    ?>
    <table>
        <thead>
            <tr>
                <th>Книга</th>
                <th>Автори</th>
            </tr>
        </thead>
        <tbody>
            <?php
            foreach ($data['books'] as $book) {
                ?>
                <tr>
                    <td><?php echo $book['bookTitle']; ?></td>
                    <td>
                        <?php
                        $authors = [];
                        foreach ($book['authors'] as $authorId => $authorName) {
                            $authors[] = '<a href="index.php?author_id=' . $authorId . '">' . $authorName . '</a>';
                        }

                        echo implode(' , ', $authors);
                        ?>
                    </td>
                </tr>
                <?php
            }
            ?>
        </tbody>
    </table>
    <?php
} else {
    echo '<p>Няма книги</p>';
}
?>