// ==================================================
// * Project Name   :  Getyootech - Gadgets Ecommerce Site Template
// * File           :  JS Base
// * Version        :  1.0.0
// * Last change    :  1 September 2023, Friday
// * Author         :  WebThunder (https://themeforest.net/user/web-thunder)
// ==================================================

(function($) {
  "use strict";

  // Sticky Header - Start
  // --------------------------------------------------
  $(window).on('scroll', function () {
    if ($(this).scrollTop() > 140) {
      $('.header_section').addClass("sticky")
    } else {
      $('.header_section').removeClass("sticky")
    }
  });
  // Sticky Header - End
  // --------------------------------------------------

  // back to top - start
  // --------------------------------------------------
  $(window).scroll(function() {
    if ($(this).scrollTop() > 200) {
      $('.backtotop:hidden').stop(true, true).fadeIn();
    } else {
      $('.backtotop').stop(true, true).fadeOut();
    }
  });
  $(function() {
    $(".scroll").on('click', function() {
      $("html,body").animate({scrollTop: 0}, "slow");
      return false
    });
  });
  // back to top - end
  // --------------------------------------------------

  // preloader - start
  // --------------------------------------------------
  $(window).on('load', function(){
    $('#preloader').fadeOut('slow',function(){$(this).remove();});
  });
  // preloader - end
  // --------------------------------------------------

  // Dropdown - Start
  // --------------------------------------------------
  $(document).ready(function () {
    $(".dropdown").on('mouseover', function () {
      $(this).find('> .dropdown-menu').addClass('show');
    });
    $(".dropdown").on('mouseout', function () {
      $(this).find('> .dropdown-menu').removeClass('show');
    });
  });
  // Dropdown - End
  // --------------------------------------------------

  // tooltip - start
  // --------------------------------------------------
  var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
  var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
  });
  // tooltip - end
  // --------------------------------------------------

  // offcanvas - start
  // --------------------------------------------------
  $(document).ready(function () {
    $('.close_btn, .cart_overlay').on('click', function () {
      $('.cart_sidebar').removeClass('active');
      $('.cart_overlay').removeClass('active');
    });

    $('.cart_btn').on('click', function () {
      $('.cart_sidebar').addClass('active');
      $('.cart_overlay').addClass('active');
    });
  });
  // offcanvas - end
  // --------------------------------------------------

  // select option - start
  // --------------------------------------------------
  $('select').niceSelect();
  // select option - end
  // --------------------------------------------------

  // counter up - start
  // --------------------------------------------------
  $('.counter').counterUp({
    delay: 10,
    time: 1000
  });
  // counter up - end
  // --------------------------------------------------

  // popup images & videos - start
  // --------------------------------------------------
  $('.popup_video').magnificPopup({
    type: 'iframe',
    preloader: false,
    removalDelay: 160,
    mainClass: 'mfp-fade',
    fixedContentPos: false
  });

  $('.zoom-gallery').magnificPopup({
    delegate: '.popup_image',
    type: 'image',
    closeOnContentClick: false,
    closeBtnInside: false,
    mainClass: 'mfp-with-zoom mfp-img-mobile',
    gallery: {
      enabled: true
    },
    zoom: {
      enabled: true,
      duration: 300,
      opener: function(element) {
        return element.find('img');
      }
    }
  });
  // popup images & videos - end
  // --------------------------------------------------

  // multy count down - start
  // --------------------------------------------------
  $('.countdown_timer').each(function(){
    $('[data-countdown]').each(function() {
      var $this = $(this), finalDate = $(this).data('countdown');
      $this.countdown(finalDate, function(event) {
        var $this = $(this).html(event.strftime(''
          + '<li class="days_count"><strong>%D</strong><span>Days</span></li>'
          + '<li class="hours_count"><strong>%H</strong><span>Hours</span></li>'
          + '<li class="minutes_count"><strong>%M</strong><span>Mins</span></li>'
          + '<li class="seconds_count"><strong>%S</strong><span>Secs</span></li>'));
      });
    });
  });
  // multy count down - end
  // --------------------------------------------------

  // main slider - start
  // --------------------------------------------------
  $('.main_slider').slick({
    dots: true,
    fade: true,
    arrows: true,
    infinite: true,
    autoplay: true,
    slidesToShow: 1,
    autoplaySpeed: 6000,
  });
  $('.ms_nav_thumbnails').slick({
    dots: false,
    arrows: false,
    infinite: true,
    vertical: true,
    slidesToShow: 3,
    slidesToScroll: 1,
    focusOnSelect: true,
    verticalSwiping: true,
    asNavFor: '.main_slider'
  });

  $('.main_slider').on('init', function (e, slick) {
    var $firstAnimatingElements = $('div.slider_item:first-child').find('[data-animation]');
    doAnimations($firstAnimatingElements);
  });
  $('.main_slider').on('beforeChange', function (e, slick, currentSlide, nextSlide) {
    var $animatingElements = $('div.slider_item[data-slick-index="' + nextSlide + '"]').find('[data-animation]');
    doAnimations($animatingElements);
  });
  var slideCount = null;

  $('.main_slider').on('init', function (event, slick) {
    slideCount = slick.slideCount;
    setSlideCount();
    setCurrentSlideNumber(slick.currentSlide);
  });
  $('.main_slider').on('beforeChange', function (event, slick, currentSlide, nextSlide) {
    setCurrentSlideNumber(nextSlide);
  });

  function setSlideCount() {
    var $el = $('.slide_count_wrap').find('.total');
    if (slideCount < 10) {
      $el.text('0' + slideCount);
    } else {
      $el.text(slideCount);
    }
  }

  function setCurrentSlideNumber(currentSlide) {
    var $el = $('.slide_count_wrap').find('.current');
    $el.text(currentSlide + 1);
  }

  function doAnimations(elements) {
    var animationEndEvents = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
    elements.each(function () {
      var $this = $(this);
      var $animationDelay = $this.data('delay');
      var $animationType = 'animated ' + $this.data('animation');
      $this.css({
        'animation-delay': $animationDelay,
        '-webkit-animation-delay': $animationDelay
      });
      $this.addClass($animationType).one(animationEndEvents, function () {
        $this.removeClass($animationType);
      });
    });
  }
  // main slider - end
  // --------------------------------------------------

  // common carousel 1 - start
  // --------------------------------------------------
  $('.common_carousel_1').slick({
    dots: true,
    arrows: true,
    infinite: true,
    autoplay: true,
    slidesToShow: 1,
    pauseOnHover: true,
    autoplaySpeed: 6000,
    prevArrow: ".cc1_left_arrow",
    nextArrow: ".cc1_right_arrow"
  });
  // common carousel 1 - end
  // --------------------------------------------------

  // common carousel 2 - start
  // --------------------------------------------------
  $('.common_carousel_2').slick({
    dots: true,
    speed: 1000,
    arrows: true,
    infinite: true,
    slidesToShow: 3,
    slidesToScroll: 3,
    prevArrow: ".cc2_left_arrow",
    nextArrow: ".cc2_right_arrow",
    responsive: [
    {
      breakpoint: 426,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 1200,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2
      }
    }
    ]
  });
  // common carousel 2 - end
  // --------------------------------------------------

  // common carousel 3 - start
  // --------------------------------------------------
  $('.common_carousel_3').slick({
    dots: true,
    speed: 1000,
    arrows: true,
    infinite: true,
    slidesToShow: 5,
    slidesToScroll: 5,
    prevArrow: ".cc3_left_arrow",
    nextArrow: ".cc3_right_arrow",
    responsive: [
    {
      breakpoint: 426,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2
      }
    },
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 3
      }
    },
    {
      breakpoint: 1025,
      settings: {
        slidesToShow: 4,
        slidesToScroll: 4
      }
    }
    ]
  });
  // common carousel 3 - end
  // --------------------------------------------------

  // tab product carousel - start
  // --------------------------------------------------
  $('.best_seller_carousel').slick({
    dots: true,
    speed: 1000,
    arrows: true,
    infinite: true,
    slidesToShow: 5,
    slidesToScroll: 5,
    prevArrow: ".bsc_left_arrow",
    nextArrow: ".bsc_right_arrow",
    responsive: [
    {
      breakpoint: 426,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2
      }
    },
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 3
      }
    },
    {
      breakpoint: 1025,
      settings: {
        slidesToShow: 4,
        slidesToScroll: 4
      }
    }
    ]
  });

  $('.new_product_carousel').slick({
    dots: true,
    speed: 1000,
    arrows: true,
    infinite: true,
    slidesToShow: 5,
    slidesToScroll: 5,
    prevArrow: ".npc_left_arrow",
    nextArrow: ".npc_right_arrow",
    responsive: [
    {
      breakpoint: 426,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2
      }
    },
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 3
      }
    },
    {
      breakpoint: 1025,
      settings: {
        slidesToShow: 4,
        slidesToScroll: 4
      }
    }
    ]
  });

  $('.hot_deal_carousel').slick({
    dots: true,
    speed: 1000,
    arrows: true,
    infinite: true,
    slidesToShow: 5,
    slidesToScroll: 5,
    prevArrow: ".hdc_left_arrow",
    nextArrow: ".hdc_right_arrow",
    responsive: [
    {
      breakpoint: 426,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2
      }
    },
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 3
      }
    },
    {
      breakpoint: 1025,
      settings: {
        slidesToShow: 4,
        slidesToScroll: 4
      }
    }
    ]
  });
  // tab product carousel - end
  // --------------------------------------------------

  // brand carousel - start
  // --------------------------------------------------
  $('.brand_carousel').slick({
    dots: false,
    speed: 5000,
    arrows: false,
    autoplay: true,
    infinite: true,
    slidesToShow: 4,
    autoplaySpeed: 0,
    centerMode: true,
    cssEase: 'linear',
    pauseOnHover: true,
    responsive: [
    {
      breakpoint: 426,
      settings: {
        speed: 800,
        autoplay: false,
        slidesToShow: 1,
        centerPadding: '15px',
      }
    },
    {
      breakpoint: 768,
      settings: {
        speed: 800,
        autoplay: false,
        slidesToShow: 2
      }
    },
    {
      breakpoint: 1025,
      settings: {
        slidesToShow: 2
      }
    },
    {
      breakpoint: 1200,
      settings: {
        slidesToShow: 4
      }
    }
    ]
  });
  // brand carousel - end
  // --------------------------------------------------

  // viewed products carousel - start
  // --------------------------------------------------
  $('.viewed_products_carousel').slick({
    dots: true,
    speed: 1000,
    arrows: true,
    infinite: true,
    slidesToShow: 3,
    slidesToScroll: 3,
    prevArrow: ".vpc_left_arrow",
    nextArrow: ".vpc_right_arrow",
    responsive: [
    {
      breakpoint: 576,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 1025,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2
      }
    }
    ]
  });
  // viewed products carousel - end
  // --------------------------------------------------

  // top category carousel - end
  // --------------------------------------------------
  $('.top_category_carousel').slick({
    speed: 1000,
    infinite: true,
    slidesToShow: 5,
    slidesToScroll: 5,
    prevArrow: ".tc_left_arrow",
    nextArrow: ".tc_right_arrow",
    responsive: [
    {
      breakpoint: 426,
      settings: {
        slidesToShow: 1,
        slidesToScroll: 1
      }
    },
    {
      breakpoint: 768,
      settings: {
        slidesToShow: 2,
        slidesToScroll: 2
      }
    },
    {
      breakpoint: 992,
      settings: {
        slidesToShow: 3,
        slidesToScroll: 3
      }
    },
    {
      breakpoint: 1025,
      settings: {
        slidesToShow: 4,
        slidesToScroll: 4
      }
    }
    ]
  });
  // top category carousel - end
  // --------------------------------------------------

  // latest product carousel - start
  // --------------------------------------------------
  $('.vertical_slider_4item').slick({
    dots: true,
    speed: 1000,
    arrows: true,
    autoplay: true,
    infinite: true,
    vertical: true,
    slidesToShow: 4,
    slidesToScroll: 4,
    pauseOnHover: true,
    autoplaySpeed: 6000,
    verticalSwiping: true,
    prevArrow: ".vs4i_left_arrow",
    nextArrow: ".vs4i_right_arrow"
  });
  // latest product carousel - end
  // --------------------------------------------------

  // product details image carousel - start
  // --------------------------------------------------
  $('.details_image_carousel').slick({
    dots: false,
    arrows: false,
    slidesToShow: 1,
    slidesToScroll: 1,
    asNavFor: '.details_image_carousel_nav'
  });
  $('.details_image_carousel_nav').slick({
    dots: false,
    arrows: false,
    vertical: true,
    slidesToShow: 4,
    slidesToScroll: 1,
    focusOnSelect: true,
    verticalSwiping: true,
    asNavFor: '.details_image_carousel',
    responsive: [
    {
      breakpoint: 376,
      settings: {
        slidesToShow: 2
      }
    },
    {
      breakpoint: 426,
      settings: {
        slidesToShow: 3
      }
    },
    {
      breakpoint: 576,
      settings: {
        slidesToShow: 4
      }
    }
    ]
  });
  // product details image carousel - end
  // --------------------------------------------------

  // price range - start
  // --------------------------------------------------
  if($("#slider-range").length){
    $( "#slider-range" ).slider({
      range: true,
      min: 0,
      max: 10000,
      values: [ 0, 4000.00 ],
      slide: function( event, ui ) {
        $( "#amount" ).val( "$" + ui.values[ 0 ] + " - $" + ui.values[ 1 ] );
      }
    });
    $( "#amount" ).val( "$" + $( "#slider-range" ).slider( "values", 0 ) +
      " - $" + $( "#slider-range" ).slider( "values", 1 ) );
  }

  $('.ar_top').on('click', function () {
    var getID = $(this).next().attr('id');
    var result = document.getElementById(getID);
    var qty = result.value;
    $('.proceed_to_checkout .update-cart').removeAttr('disabled');
    if( !isNaN( qty ) ) {
      result.value++;
    }else{
      return false;
    }
  });
  // price range - end
  // --------------------------------------------------

  // quantity - start
  // --------------------------------------------------
  (function() {
    window.inputNumber = function(el) {
      var min = el.attr("min") || false;
      var max = el.attr("max") || false;

      var els = {};

      els.dec = el.prev();
      els.inc = el.next();

      el.each(function() {
        init($(this));
      });

      function init(el) {
        els.dec.on("click", decrement);
        els.inc.on("click", increment);

        function decrement() {
          var value = el[0].value;
          value--;
          if (!min || value >= min) {
            el[0].value = value;
          }
        }

        function increment() {
          var value = el[0].value;
          value++;
          if (!max || value <= max) {
            el[0].value = value++;
          }
        }
      }
    };
  })();
  inputNumber($(".input_number"));
  inputNumber($(".input_number_2"));
  // quantity - end
  // --------------------------------------------------

})(jQuery);