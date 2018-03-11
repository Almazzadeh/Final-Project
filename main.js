$(function(){
    $("li.submenu").mouseenter(function(){
        $(this).find("ul").first().slideDown(300)
    })
    $("li.submenu").mouseleave(function(){
        $(this).find("ul").slideUp(300)
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
})