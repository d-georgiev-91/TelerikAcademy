<?php
	/**
	 * [$i loops from 1 to 1000]
	 * @var integer
	 */
	for ($i= 1; $i <= 1000; $i++) { 
		if ($i % 21 === 0) {
			echo $i . " is divisable by 3 and 7<br/>";
		}
	}
?>