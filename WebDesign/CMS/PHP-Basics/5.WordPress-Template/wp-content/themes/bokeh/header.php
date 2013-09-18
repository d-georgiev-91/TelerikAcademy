<!DOCTYPE HTML>
<html>
<head>
  <title><?php bloginfo('name'); ?> <?php wp_title(); ?></title>
  <meta name="description" content="<?php bloginfo( 'description' ); ?>">
  <meta name="keywords" content="website keywords, website keywords" />
  <meta charset="<?php bloginfo( 'charset' ); ?>" />
  <!-- modernizr enables HTML5 elements and feature detects -->
  <?php wp_head(); ?>
</head>

<body>
  <div id="main">
    <header>
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_colour", allows you to change the colour of the text -->
          <h1><a href="<?php echo get_option('home'); ?>">CCS3<span class="logo_colour">_bokeh</span></a></h1>
          <h2>Simple. Contemporary. Website Template.</h2>
        </div>
      </div>
      <nav>
      <div id="menu_container">
      <?php
       wp_nav_menu( array( 
        'container' => '', 
        'menu_class' => 'sf-menu',
        'menu_id' => 'nav'
         ) );
        ?>
      </div>
      </nav>
    </header>