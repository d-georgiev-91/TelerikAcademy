<?php get_header(); ?>
    <!-- <div id="site_content"> -->
  <div id="site_content">
 <?php  get_sidebar(); ?> 
  <div class="content">
    <?php 
    if ( have_posts() ) :
      while ( have_posts() ) : the_post(); ?>
      
        <h1><a href="<?php the_permalink(); ?>" title="<?php the_title_attribute(); ?>"><?php the_title(); ?></a></h1>
        <div><?php the_content(); ?> </div>
     
    <?php   endwhile;
      endif;
    ?>
  </div>
</div>
<?php get_footer(); ?>
