$(function () {
    $("li.submenu").mouseenter(function () {
        $(this).find("ul").first().slideDown(400);
        // $(this).find('[data-fa-i2svg]').first().toggleClass('fa-caret-right').toggleCLass('fa-caret-down')
    })
    $("li.submenu").mouseleave(function () {
        $(this).find("ul").slideUp(400);
        // $(this).find('[data-fa-i2svg]').first().toggleClass('fa-caret-right').toggleCLass('fa-caret-down')
    })

    $("li.ourcategories").click(function () {
        $(".ourcategoriesdrop").slideToggle(400)
    })

    $("li.submenuHover").mouseenter(function () {
        $(this).find("div").first().slideDown(400)
    })
    $("li.submenuHover").mouseleave(function () {
        $(this).find("div").first().slideUp(400)
    })

    // CAROUSELS START HERE

    $("#featured").slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 5000,
        infinite: true
    })

    $("#recentlyproducts").slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        infinite: true
    })

    $("#tv").slick({
        slidesToShow: 5,
        slidesToScroll: 2,
        arrows: false,
        dots: true,
        autoplay: true,
        autoplaySpeed: 5000,
        infinite: true
    })

    $(".postwrapper").slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true
    })

    $(".relatedcarousel").slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        infinite: true
    })

    $('.slider-for').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
        asNavFor: '.slider-nav'
      });
      $('.slider-nav').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.slider-for',
        infinite: true,
        centerMode: true,
        focusOnSelect: true
      });

      // CAROUSELS END HERE

    // GO TO TOP
    $(window).scroll(function () {
        if ($(this).scrollTop() > 400) {
            $('.gotop').fadeIn();
        } else {
            $('.gotop').fadeOut();
        }
    });

    //Click event to scroll to top
    $('.gotop').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 800);
        return false;
    });

    // PROGRESS BAR SECTION
    $('#photoshop').LineProgressbar({
        percentage: 90,
        duration: 1500,
        fillBackgroundColor: '#08c',
        backgroundColor: '#e6e6e6',
        radius: '20px',
        height: '15px',
    })

    $('#uidesign').LineProgressbar({
        percentage: 70,
        duration: 1500,
        fillBackgroundColor: '#08c',
        backgroundColor: '#e6e6e6',
        radius: '20px',
        height: '15px',
    })

    $('#layoutframe').LineProgressbar({
        percentage: 80,
        duration: 1500,
        fillBackgroundColor: '#08c',
        backgroundColor: '#e6e6e6',
        radius: '20px',
        height: '15px',
    })

    $('#typography').LineProgressbar({
        percentage: 80,
        duration: 1500,
        fillBackgroundColor: '#08c',
        backgroundColor: '#e6e6e6',
        radius: '20px',
        height: '15px',
    })

    $("#range").ionRangeSlider({
        type: "double",
        grid: true,
        min: 0,
        max: 1000,
        from: 300,
        to: 700,
        prefix: "$"
    });

    
})