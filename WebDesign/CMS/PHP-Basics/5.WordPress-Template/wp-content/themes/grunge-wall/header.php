<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" <?php language_attributes(); ?>>

<head profile="http://gmpg.org/xfn/11">
<meta http-equiv="Content-Type" content="<?php bloginfo('html_type'); ?>; charset=<?php bloginfo('charset'); ?>" />

<title><?php bloginfo('name'); ?> <?php if ( is_single() ) { ?> &raquo; Blog Archive <?php } ?> <?php wp_title(); ?></title>
<script type="text/javascript">
    var theme_dir = '<?php bloginfo('template_directory'); ?>/';
    var img_dir = '<?php bloginfo('template_directory'); ?>/images/';
</script>
<link rel="stylesheet" href="<?php bloginfo('stylesheet_url'); ?>" type="text/css" media="screen" />
<link rel="alternate" type="application/rss+xml" title="<?php bloginfo('name'); ?> RSS Feed" href="<?php bloginfo('rss2_url'); ?>" />
<link rel="pingback" href="<?php bloginfo('pingback_url'); ?>" />
<script type="text/javascript" src="<?php bloginfo('template_directory'); ?>/js/jquery-1.2.6.pack.js"></script>
<script type="text/javascript" src="<?php bloginfo('template_directory'); ?>/js/functions.js"></script>
<style type="text/css" media="screen">
 * html #feed-top .rss{
   background: none;
   filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='<?php bloginfo('template_directory'); ?>/images/rss_top.png');
 }

</style>


<?php wp_head(); ?>
</head>
<body>
<div id="page">
<div id="colours">
    <a href="#" id="red">red</a>
    <a href="#" id="orange">orange</a>
    <a href="#" id="yellow">yellow</a>
    <a href="#" id="green">green</a>
    <a href="#" id="blue">blue</a>
    <a href="#" id="pink">pink</a>
</div>

<div id="header">
	<div id="headerimg">

		<h1><a href="<?php echo get_option('home'); ?>/"><?php bloginfo('name'); ?></a><br class="clear" /><span class="description"><?php bloginfo('description'); ?></span></h1>
         <div id="feed-top" onclick="window.location='<?php bloginfo('rss2_url'); ?>' ">
           <a href="<?php bloginfo('rss2_url'); ?>" class="rss">RSS SUBSCRIBE</a>
          <p>Subscribe via a Feed Reader</p>
        </div>


	</div>
    <div id="nav">
        <ul>
            <li<?php if (is_home()) echo ' class="current_page_item"'; ?>><a href="<?php echo get_settings('home'); ?>/">Home</a></li>
             <?php wp_list_pages('title_li=' ); ?>
        </ul>
    </div>
</div>
<div id="content-wrap">
