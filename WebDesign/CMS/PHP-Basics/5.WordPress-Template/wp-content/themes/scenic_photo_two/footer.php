 </div>
    </div>
    <footer>
      <?php
        if ( ! is_404() )
          get_sidebar( 'footer' );
      ?>
      <p>Copyright &copy; scenic_photo_two | <a href="http://www.css3templates.co.uk">design from css3templates.co.uk</a></p>
    </footer>
  </div>
  <p>&nbsp;</p>
  <!-- javascript at the bottom for fast page loading -->
  <script type="text/javascript">
    jQuery(document).ready(function($) {
      $('ul.sf-menu').sooperfish();
    });
  </script>
  <?php wp_footer(); ?>
</body>
</html>