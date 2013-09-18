<?php
	if (is_home()) :
?>
	<aside id="sidebar1"><!-- sidebar1 -->
	<?php
		if (is_active_sidebar('sidebar-1')):
				dynamic_sidebar( 'sidebar-1' );
		else:
	?>
		<h3>Things To Do</h3>
		<ul>
			<li><a href="#">Play Games</a></li>
			<li><a href="#">Chat With Friends</a></li>
			<li><a href="#">Swap Stories</a></li>
			<li><a href="#">Sell Stuff</a></li>
			<li><a href="#">Buy Stuff</a></li>
			<li><a href="#">Trade Stuff</a></li>
		</ul>
		
		<h3>Sponsors</h3>
		<img src="images/ad125.jpg" alt="" /><br /><img src="images/ad125.jpg" alt="" /><br /><br />

		<h3>Related Articles</h3>
		<ul>
			<li><a href="#">Curabitur sodales</a></li>
			<li><a href="#">Sed dignissim</a></li>
			<li><a href="#">Fusce nec</a></li>
			<li><a href="#">Curabitur sodales</a></li>
			<li><a href="#">Sed dignissim</a></li>
			<li><a href="#">Fusce nec</a></li>
		</ul>

		<h3>Connect With Us</h3>
		<ul>
			<li><a href="#">Twitter</a></li>
			<li><a href="#">Facebook</a></li>
		</ul>

	<?php endif; ?>
	</aside><!-- end of sidebar1 -->
<?php endif; ?>

<aside id="sidebar2"><!-- sidebar2 -->
<?php
	if (is_active_sidebar('sidebar-2')):
			dynamic_sidebar( 'sidebar-2' );
	else:
?>
	<h3>Stuff</h3>
	<ul>
		<li><a href="#">Curabitur sodales</a></li>
		<li><a href="#">Sed dignissim</a></li>
		<li><a href="#">Fusce nec</a></li>
		<li><a href="#">Nulla quis</a></li>
	</ul>

	<h3>More Stuff</h3>
	<ul>
		<li><a href="#">Blah, blah and all blah</a></li>
		<li><a href="#">More blah</a></li>
	</ul>

	<h3>S'more Goodies</h3>
	<ul>
		<li><a href="#">Curabitur sodales</a></li>
		<li><a href="#">Sed dignissim</a></li>
		<li><a href="#">Fusce nec</a></li>
		<li><a href="#">Nulla quis</a></li>
		<li><a href="#">Curabitur sodales</a></li>
		<li><a href="#">Sed dignissim</a></li>
		<li><a href="#">Fusce nec</a></li>
		<li><a href="#">Nulla quis</a></li>
	</ul>

	<h3>Did You Know?</h3>
	<ul>
		<li><a href="#">Curabitur sodales</a></li>
		<li><a href="#">Sed dignissim</a></li>
		<li><a href="#">Fusce nec</a></li>
		<li><a href="#">Nulla quis</a></li>
		<li><a href="#">Curabitur sodales</a></li>
		<li><a href="#">Sed dignissim</a></li>
		<li><a href="#">Fusce nec</a></li>
		<li><a href="#">Nulla quis</a></li>
	</ul>

	<h3>FAQ</h3>
	<ul>
		<li><a href="#">Curabitur sodales</a></li>
		<li><a href="#">Sed dignissim</a></li>
		<li><a href="#">Fusce nec</a></li>
		<li><a href="#">Nulla quis</a></li>
		<li><a href="#">Curabitur sodales</a></li>
		<li><a href="#">Sed dignissim</a></li>
		<li><a href="#">Fusce nec</a></li>
		<li><a href="#">Nulla quis</a></li>
	</ul>
<?php endif; ?>
</aside><!-- end of sidebar -->