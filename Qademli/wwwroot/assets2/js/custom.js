$(document).ready(function () {
    $('.top_bar_wrape #sidebar_toggler').click(function () {
        $('#sidebar_panel').addClass('sidebar_show');
    });
    $('.close_menu').click(function () {
        $('#sidebar_panel').removeClass('sidebar_show');
    });
});