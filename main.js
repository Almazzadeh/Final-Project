$(function () {
    $("li.submenu").mouseenter(function () {
        $(this).find("ul").first().slideDown(300);
        // $(this).find('[data-fa-i2svg]').first().toggleClass('fa-caret-right').toggleCLass('fa-caret-down')
    })
    $("li.submenu").mouseleave(function () {
        $(this).find("ul").slideUp(300);
        // $(this).find('[data-fa-i2svg]').first().toggleClass('fa-caret-right').toggleCLass('fa-caret-down')
    })

    $("li.ourcategories").click(function () {
        $(".ourcategoriesdrop").slideToggle(300)
    })

    $("li.submenuHover").mouseenter(function () {
        $(this).find("div").first().slideDown(300)
    })
    $("li.submenuHover").mouseleave(function () {
        $(this).find("div").first().slideUp(300)
    })

    $("#featured").slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        autoplay: true,
        autoplaySpeed: 5000,
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
})