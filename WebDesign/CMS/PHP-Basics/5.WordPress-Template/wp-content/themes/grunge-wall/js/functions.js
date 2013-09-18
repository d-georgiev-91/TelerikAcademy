jQuery.cookie = function(name, value, options) {
    if (typeof value != 'undefined') { // name and value given, set cookie
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
        }
        // CAUTION: Needed to parenthesize options.path and options.domain
        // in the following expressions, otherwise they evaluate to undefined
        // in the packed version for some reason...
        var path = options.path ? '; path=' + (options.path) : '';
        var domain = options.domain ? '; domain=' + (options.domain) : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else { // only name given, get cookie
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};

$(document).ready(function() {

    $('#menu a').prepend("<span><!-- --></span>");

    // Add Rounded Corners For .box-es

    $('.post').prepend("<span class='btl'><!-- --></span><span class='btr'><!-- --></span><span class='bbl'><!-- --></span><span class='bbr'><!-- --></span>");

    /* Fixing Equal Height For Footer Boxes */

    var dna_height = $('#footer-feed').height();
    var footer_title_height = $('.footer-title').height();
    $('#most-popular-posts').height(dna_height-footer_title_height);
    $('#my-blog-log').height(dna_height-footer_title_height);

    //styleswitch
    isbody = document.body;
    var the_body = $("body");

    $("#red").click( function() {
       isbody.className = 'red';
       $.cookie('themecolor', 'red');
    });
    $("#orange").click( function() {
        isbody.className = 'orange';
        $.cookie('themecolor', 'orange');
    });
    $("#yellow").click( function() {
       isbody.className = 'yellow';
       $.cookie('themecolor', 'yellow');
    });
    $("#green").click( function() {
        isbody.className = 'green';
        $.cookie('themecolor', 'green');
    });
    $("#blue").click( function() {
       isbody.className = 'blue';
       $.cookie('themecolor', 'blue');
    });
    $("#pink").click( function() {
        isbody.className = 'pink';
        $.cookie('themecolor', 'pink');
    });

   var the_color = $.cookie('themecolor');
   isbody.className = the_color;


      i1 = new Image;
      i1.src= img_dir + "navbtnhover.jpg";
      i2 = new Image;
      i2.src= img_dir + "navbtnhover_orange.jpg";
      i3 = new Image;
      i3.src= img_dir + "navbtnhover_red.jpg";
      i4 = new Image;
      i4.src= img_dir + "navbtnhover_blue.jpg";
      i5 = new Image;
      i5.src= img_dir + "navbtnhover_green.jpg";



});

