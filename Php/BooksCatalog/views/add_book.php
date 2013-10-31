<a href="index.php">Списък</a>

<form method="post" action="index.php?p=add_book">
    <label for="book-name">Име: </label>
    <input id="book-name" type="text" name="bookName" />
    <div>
        <label for="authors">Автори: </label>
        <select id="authors" name="authors[]" multiple style="width: 200px">
            <?php
            foreach ($data['authors'] as $authorId => $authorName) {
                ?>
                <option value ="<?php echo $authorId; ?>"> 
                    <?php echo $authorName; ?>
                </option>
                <?php
            }
            ?>
        </select>
    </div>
    <input type="submit" value="Добави" />    

</form>