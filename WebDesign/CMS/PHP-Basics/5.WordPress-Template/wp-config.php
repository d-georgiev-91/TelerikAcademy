<?php
/**
 * The base configurations of the WordPress.
 *
 * This file has the following configurations: MySQL settings, Table Prefix,
 * Secret Keys, WordPress Language, and ABSPATH. You can find more information
 * by visiting {@link http://codex.wordpress.org/Editing_wp-config.php Editing
 * wp-config.php} Codex page. You can get the MySQL settings from your web host.
 *
 * This file is used by the wp-config.php creation script during the
 * installation. You don't have to use the web site, you can just copy this file
 * to "wp-config.php" and fill in the values.
 *
 * @package WordPress
 */

// ** MySQL settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
define('DB_NAME', 'wordpress-template');

/** MySQL database username */
define('DB_USER', 'root');

/** MySQL database password */
define('DB_PASSWORD', '');

/** MySQL hostname */
define('DB_HOST', 'localhost');

/** Database Charset to use in creating database tables. */
define('DB_CHARSET', 'utf8');

/** The Database Collate type. Don't change this if in doubt. */
define('DB_COLLATE', '');

/**#@+
 * Authentication Unique Keys and Salts.
 *
 * Change these to different unique phrases!
 * You can generate these using the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}
 * You can change these at any point in time to invalidate all existing cookies. This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define('AUTH_KEY',         'Xi&Kr`10vA6)N~b6Rc[RS/a?=N69<#}]q+Y=K*[XW4=|r7yUwFcL2C /GM3C+4((');
define('SECURE_AUTH_KEY',  '6JVjb<2]sWlIh9VLG`Da@E[Z8p?~8a5c3K@8Tr` 5-bZ$t^tPu>O~F3S(zbdgr8C');
define('LOGGED_IN_KEY',    '@H^xO%gd|7Od$v5TrkN|_Z%?F$]-M5`+:2M5#5UGwVAQ`ZhP:,C~=iC^{2Z,x*37');
define('NONCE_KEY',        'W%:W<5+m;:[;8,>g9Z;qnW+_]WPsk+O29F%SJ:R+[_%;a-5S?k6b)]Tm?R(GKyLe');
define('AUTH_SALT',        '%aeBBPhi~goL;d(qw8IfN!bAo:CaZ~/OHQ@oiR*X0R^cn71x:LnPq6IulPu57glI');
define('SECURE_AUTH_SALT', 'nW$H!D5EFOSqpJ?fXz&oruWn;5U&EF:(~Jlx#tvtZ6_/ZQsc.1iLL+L9}< =}qXP');
define('LOGGED_IN_SALT',   '<=?p4d S6L2L:<.;S8T~?%}1cv%]TfQ+ue3bpuiGli;$ruEl=B]kadB#TU/Dit U');
define('NONCE_SALT',       'sJN.!LR4RMfHPfSHu|%l>;gRk}RJA9_M?,Rib<3#^6sN7=HDOucuH;P$k$ww6OtS');

/**#@-*/

/**
 * WordPress Database Table prefix.
 *
 * You can have multiple installations in one database if you give each a unique
 * prefix. Only numbers, letters, and underscores please!
 */
$table_prefix  = 'wp_';

/**
 * WordPress Localized Language, defaults to English.
 *
 * Change this to localize WordPress. A corresponding MO file for the chosen
 * language must be installed to wp-content/languages. For example, install
 * de_DE.mo to wp-content/languages and set WPLANG to 'de_DE' to enable German
 * language support.
 */
define('WPLANG', '');

/**
 * For developers: WordPress debugging mode.
 *
 * Change this to true to enable the display of notices during development.
 * It is strongly recommended that plugin and theme developers use WP_DEBUG
 * in their development environments.
 */
define('WP_DEBUG', true);

/* That's all, stop editing! Happy blogging. */

/** Absolute path to the WordPress directory. */
if ( !defined('ABSPATH') )
	define('ABSPATH', dirname(__FILE__) . '/');

/** Sets up WordPress vars and included files. */
require_once(ABSPATH . 'wp-settings.php');