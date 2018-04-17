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
});