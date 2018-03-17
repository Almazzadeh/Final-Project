$(function(){
    $("li.submenu").mouseenter(function(){
        $(this).find("ul").first().slideDown(300);
        // $(this).find('[data-fa-i2svg]').first().toggleClass('fa-caret-right').toggleCLass('fa-caret-down')
    })
    $("li.submenu").mouseleave(function(){
        $(this).find("ul").slideUp(300);
        // $(this).find('[data-fa-i2svg]').first().toggleClass('fa-caret-right').toggleCLass('fa-caret-down')
    })

    $("li.ourcategories").click(function(){
        $(".ourcategoriesdrop").slideToggle(300)
    })

    $("li.submenuHover").mouseenter(function(){
        $(this).find("div").first().slideDown(300)
    })
    $("li.submenuHover").mouseleave(function(){
        $(this).find("div").first().slideUp(300)
    })

    $("#featured").slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        autoplay: true,
        infinite: true
    })

    $("#tv").slick({
        slidesToShow: 5,
        slidesToScroll: 5,
        dots: true,
        // autoplay: true,
        infinite: true
    })
})