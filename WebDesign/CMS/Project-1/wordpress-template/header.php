<!doctype html>
<html <?php language_attributes(); ?>> 
<head>
	<meta charset="<?php bloginfo( 'charset' ) ?>" />
	<title><?php wp_title('|', true, 'right'); ?> <?php bloginfo( 'name' ) ?></title>
	<link rel="stylesheet" href="<?php 	bloginfo( 'stylesheet_url' ); ?>" type="text/css" media="screen" />
	<!--[if IE]><script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
	<?php wp_head(); ?>
</head>
<body>
<div id="wrapper"><!-- #wrapper -->
	<header><!-- header -->
		<h1><a href="<?php echo home_url(); ?>"><?php bloginfo( 'name' ) ?></a></h1>
		<h2><?php echo bloginfo( 'description' ); ?></h2>
		<?php if (is_home()): ?>
			<img src="<?php header_image(); ?>" width="<?php echo get_custom_header()->width; ?> height="<?php echo get_custom_header()->height; ?>" alt=""><!-- header image -->
		<?php endif ?>
	</header><!-- end of header -->
	
	<!-- By deafault it isn't placed here, but I think it's better to be here. -->
	<nav>
		<?php wp_nav_menu(array(
			'container' => 'div',
			'container_class' => 'menu',
			'theme_location'  => 'top-menu',
			));
		?>
	</nav>