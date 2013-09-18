		<footer>
		<section id="footer-area">
			<section id="footer-outer-block">
					<?php 
						if (! is_404()) {
							get_sidebar( 'footer' );
						}
					?>					
					<aside class="footer-segment">
							<h4>Blahdyblah</h4>
							<p>
								&copy; <?php echo date('Y'); ?> 
								<a href="<?php echo home_url(); ?>"><?php bloginfo( 'url' ); ?></a> 
								All Rights Reserved.
							</p>
					</aside><!-- end of #fourth footer segment -->

			</section><!-- end of footer-outer-block -->

		</section><!-- end of footer-area -->
	</footer>
	<?php wp_footer(); ?>
</div><!-- #wrapper -->
</body>
</html>
