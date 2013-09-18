<?php
	/**
	 * Defining constants
	 */
	define('THEMEROOT', get_stylesheet_directory_uri());
	define('IMAGES', THEMEROOT . '/images');

	/**
	 * Menus
	 */
	function register_my_menus()
	{
	    register_nav_menus(array(
	        'top-menu' => 'Top Menu'
	    ));
	}

	add_action('init', 'register_my_menus');

	/**
	 * Adding Home button if no nav menu is selected
	 */
	function theme_page_menu_args( $args ) {
		if ( ! isset( $args['show_home'] ) ) {
			$args['show_home'] = true;
		}

		return $args;
	}
	
	add_filter( 'wp_page_menu_args', 'theme_page_menu_args' );

	/**
	 * Custom header image
	 */
	$args = array(
	    'flex-width' => true,
	    'width' => 940,
	    'flex-height' => true,
	    'height' => 200,
	    'default-image' => IMAGES . '/header.jpg'
	);
	add_theme_support('custom-header', $args);

	/**
	 * Post Thumbnail support
	 */
	if (function_exists('add_theme_support')) {
	    add_theme_support('post-thumbnails');
	    set_post_thumbnail_size(150, 150, true);
	}

	/**
	 * Register Sidebars
	 */
	if (function_exists('register_sidebar')) {
	    register_sidebar(array(
	        'name' => 'First Sidebar',
	        'id' => 'sidebar-1',
	        'desciprtion' => 'First sidebar area',
	        'before_widget' => '<div id="%1$s" class="widget %2$s">',
			'after_widget'  => '</div>',
	        'before_title' => '<h3>',
	        'after_title' => '</h3>'
	    ));
	    
	    register_sidebar(array(
	        'name' => 'Second sidebar',
	        'id' => 'sidebar-2',
	        'desciprtion' => 'Second sidebar area',
	        'before_widget' => '<div id="%1$s" class="widget %2$s">',
			'after_widget'  => '</div>',
	        'before_title' => '<h3>',
	        'after_title' => '</h3>'
	    ));
	    
	    register_sidebar(array(
	        'name' => 'Footer sidebar 1',
	        'id' => 'footer-sidebar-1',
	        'description' => 'An optional widget area for your site footer',
	        'before_widget' => '<aside class="footer-segment">',
	        'after_widget' => "</aside>&nbsp;",
	        'before_title' => '<h4>',
	        'after_title' => '</h4>'
	    ));

	    register_sidebar(array(
	        'name' => 'Footer sidebar 2',
	        'id' => 'footer-sidebar-2',
	        'description' => 'An optional widget area for your site footer',
	        'before_widget' => '<aside class="footer-segment">',
	        'after_widget' => "</aside>&nbsp;",
	        'before_title' => '<h4>',
	        'after_title' => '</h4>'
	    ));

	    register_sidebar(array(
	        'name' => 'Footer sidebar 3',
	        'id' => 'footer-sidebar-3',
	        'description' => 'An optional widget area for your site footer',
	        'before_widget' => '<aside class="footer-segment">',
	        'after_widget' => "</aside>&nbsp;",
	        'before_title' => '<h4>',
	        'after_title' => '</h4>'
	    ));
	}

	/**
	 * Stylesheets
	 */
	function theme_styles()	{
	    if (is_page()) {
	        $styleSheetName = 'page';
	    } else {
	        $styleSheetName = 'index';
	    }
	    
	    wp_register_style($styleSheetName . '-style', get_template_directory_uri() . '/styles/' . $styleSheetName . '.css', array());
	    wp_enqueue_style($styleSheetName . '-style');
	}

	add_action('wp_enqueue_scripts', 'theme_styles');
?>