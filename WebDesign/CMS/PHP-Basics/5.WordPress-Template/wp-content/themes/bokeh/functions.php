<?php
register_nav_menu('main_bokeh', 'Bokeh main menu');

register_sidebar(array(
  'name' => __('Right sidebar'),
  'id' => 'right_sidebar',
  'description' => __('Bokeh Widgets'),
  'before_widget' => '<div class="sidebar">',
  'after_widget' => '</div>',
  'before_title'  => '<h3>',
  'after_title'   => '</h3>' 
    ));
	function enqueue_theme_styles()  
	{ 
	  wp_enqueue_style( 'style', get_template_directory_uri() . '/style.css');
	}

	add_action('wp_enqueue_scripts', 'enqueue_theme_styles');
	
	function enqeue_theme_scripts()
	{	
		
		/*wp_enqueue_script( $handle, $src = false, $deps = array, $ver = false, $in_footer = false )*/
		wp_enqueue_script( 'modernizr', get_template_directory_uri() . '/js/modernizr-1.5.min.js');
		wp_enqueue_script( 'jquery', false , array(), false, true);
		wp_enqueue_script( 'easing-sooper', get_template_directory_uri() . '/js/jquery.easing-sooper.js', array('jquery'), false, true );
		wp_enqueue_script( 'sooperfish', get_template_directory_uri() . '/js/jquery.sooperfish.js', array('jquery'), false, true );
	}	

	add_action( 'wp_enqueue_scripts', 'enqeue_theme_scripts' );
?>