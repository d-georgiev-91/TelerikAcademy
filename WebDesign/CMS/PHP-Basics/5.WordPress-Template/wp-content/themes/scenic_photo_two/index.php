<?php get_header(); ?>
    <?php 
    if ( have_posts() ) :
      while ( have_posts() ) : the_post(); ?>
      
        <h1><a href="<?php the_permalink(); ?>" title="<?php the_title_attribute(); ?>"> <?php the_title(); ?> </a></h1>
        <div><?php the_content(); ?> </div>
     
    <?php   endwhile;
      endif;
    ?>
<?php get_footer(); ?>
