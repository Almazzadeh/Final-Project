$(function () {
    //$(".skillvalue").each(function () {
    //    console.log(this)
    //})


    $("li.submenu").mouseenter(function () {
        $(this).find("ul").first().slideDown(600);
        // $(this).find('[data-fa-i2svg]').first().toggleClass('fa-caret-right').toggleCLass('fa-caret-down')
    })
    $("li.submenu").mouseleave(function () {
        $(this).find("ul").slideUp(600);
        // $(this).find('[data-fa-i2svg]').first().toggleClass('fa-caret-right').toggleCLass('fa-caret-down')
    })

    $("li.ourcategories").click(function () {
        $(".ourcategoriesdrop").slideToggle(600)
    })

    $("li.submenuHover").mouseenter(function () {
        $(this).find("div").first().slideDown(600)
    })
    $("li.submenuHover").mouseleave(function () {
        $(this).find("div").first().slideUp(600)
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

    $('.skillvalue').each(function () {
        var id = $(this).next().text();
        var per = parseInt($(this).text());

        $("#" + id).LineProgressbar({
            percentage: per,
            duration: 1000,
            fillBackgroundColor: '#08c',
            backgroundColor: '#e6e6e6',
            radius: '20px',
            height: '15px',
        })
    })


    $('.discount').each(function () {
        var discount = parseInt($(this).text().slice(1, 3));
        var oldprice = parseInt(parseFloat($(this).parent().next().next().next().next().text().slice(1, -1)).toFixed());
        var newprice = ((oldprice * (100 - discount)) / 100).toFixed(2);

        var oldpriceparagraph = $(this).parent().next().next().next().next();
        var p = document.createElement('p');
        p.innerHTML = "$" + newprice;
        p.className = "productprice";
        oldpriceparagraph.before(p);
        //console.log(newprice);
    })

    $('.discountlist').each(function () {
        var discount = parseInt($(this).text().slice(1, 3));
        var oldprice = parseInt(parseFloat($(this).next().children().first().text().slice(1, -1)).toFixed());
        var newprice = ((oldprice * (100 - discount)) / 100).toFixed(2);
        //console.log(oldprice);

        var oldpriceh4 = $(this).next().children().first();
        var h4 = document.createElement('h4');
        h4.innerHTML = "$" + newprice;
        h4.className = "productprice";
        oldpriceh4.before(h4);
    })

    $('.discountsingle').each(function () {
        var discount = parseInt($(this).text().slice(1, 3));
        var oldprice = parseInt(parseFloat($(this).next().next().children().first().text().slice(1, -1)).toFixed());
        var newprice = ((oldprice * (100 - discount)) / 100).toFixed(2);
        //console.log(oldprice);

        var oldpriceh4 = $(this).next().next().children().first();
        var h4 = document.createElement('h4');
        h4.innerHTML = "$" + newprice;
        h4.className = "productprice";
        oldpriceh4.before(h4);
    })
        

    //RANGE SECTION
    $("#range").ionRangeSlider({
        type: "double",
        grid: true,
        min: 0,
        max: 1000,
        from: 300,
        to: 700,
        prefix: "$"
    });


    //ZOOM PRODUCT IMAGE
    $(".zoom").blowup({
        scale: 2
    });
    
})