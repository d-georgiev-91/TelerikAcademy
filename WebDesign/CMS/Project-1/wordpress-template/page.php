<?php get_header() ?>		
	<section id="main"><!-- #main content and sidebar area -->
			<section id="content"><!-- #content -->
				<?php 
					if (have_posts()) : 
						while(have_posts()) : 
							the_post(); 
				?>
        		<article id="post-<?php the_ID(); ?>">
					<h2>
						<a href="<?php the_permalink(); ?>"><?php the_title(); ?></a>
					</h2>
					<?php 
						if(has_post_thumbnail()) {
							the_post_thumbnail('thumbnail', array('class' => 'alignleft'));
						}
						
						the_content();
					?>
				</article>
				<?php 
						endwhile;
					else:
				?>
			 	<h1><?php echo "No post were found"; ?></h1>
				
				<?php endif; ?>						
			</section><!-- end of #content -->

		<?php get_sidebar(); ?>
	</section><!-- end of #main content and sidebar-->

<?php get_footer() ?>