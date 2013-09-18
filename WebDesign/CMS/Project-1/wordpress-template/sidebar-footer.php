<?php
	if (!is_active_sidebar('footer-sidebar-1') && 
		!is_active_sidebar('footer-sidebar-2') && 
		!is_active_sidebar('footer-sidebar-3')) :
?>
	<aside class="footer-segment">
		<h4>Friends</h4>
		<ul>
			<li><a href="#">one linkylink</a></li>
			<li><a href="#">two linkylinks</a></li>
			<li><a href="#">three linkylinks</a></li>
		</ul>
	</aside><!-- end of #first footer segment -->

	<aside class="footer-segment">
		<h4>Awesome Stuff</h4>
		<ul>
			<li><a href="#">one linkylink</a></li>
			<li><a href="#">two linkylinks</a></li>
			<li><a href="#">three linkylinks</a></li>
		</ul>
	</aside><!-- end of #second footer segment -->

	<aside class="footer-segment">
		<h4>Coolness</h4>
		<ul>
			<li><a href="#">one linkylink</a></li>
			<li><a href="#">two linkylinks</a></li>
			<li><a href="#">three linkylinks</a></li>
		</ul>
	</aside><!-- end of #third footer segment -->
<?php 
	else: 
		if ( is_active_sidebar( 'footer-sidebar-1' ) ) {
			dynamic_sidebar( 'footer-sidebar-1' );
		}

		if ( is_active_sidebar( 'footer-sidebar-2' ) ) {
			dynamic_sidebar( 'footer-sidebar-2' );
		} 

		if ( is_active_sidebar( 'footer-sidebar-3' ) ) {
			dynamic_sidebar( 'footer-sidebar-3' );
		} 
	endif;
?>