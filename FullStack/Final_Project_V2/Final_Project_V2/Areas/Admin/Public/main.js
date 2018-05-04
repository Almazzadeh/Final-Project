//ADMIN PANEL SCRIPT

$(document).ready(function () {
    $('.sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });

    $('[data-toggle="tooltip"]').tooltip();

    $(".iconholder i").on("click", function () {
        var iconclass = $(this).attr("class");
        console.log(iconclass);
        $(".iconholder").find(".activeicon").removeClass("activeicon");
        $(this).addClass("activeicon");
        $("#fromscript").val(iconclass);
    })

    $(".alert-danger").delay(5000).slideUp(500);


    $('.checkbox').each(function () {
        if ($(this).val() == "True") {
            $(this).prop('checked', true);
        } else {
            $(this).prop('checked', false);
        }

        var span = $(this).parent().next().children();

        $(this).on('change', function () {
            if ($(this).is(':checked')) {
                span.val('True')
            } else {
                span.val('False')
            }
        })
    })

    //DOESN'T WORK
    //$('.commentId').each(function () {
    //    var commentId = parseInt($(this).text());
    //    var frameComment = $(this).parent().nextAll().eq(3).children().contents().find(".framecomment");
    //    console.log(frameComment)
    //})

});