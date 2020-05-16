$(function() {
  $(".expand").on( "click", function() {
    // $(this).next().slideToggle(200);
    $expand = $(this).find(">:first-child");
    
    if($expand.text() == "+") {
      $expand.text("-");
    } else {
      $expand.text("+");
    }
  });
});



$(document).ready(function () {
    $('.view_more_uni').click(function () {
        $('.view_all_uni').toggleClass('d-none');
        $('.main_row').toggleClass('d-none');
        $(".view_more_uni .more").toggle();
        $(".view_more_uni .less").toggle();
    });
    $('.view_more_lang_centers').click(function () {
        $('.view_all_centers').toggleClass('d-none');
        $(".view_more_lang_centers .more").toggle();
        $(".view_more_lang_centers .less").toggle();
    });
    $('#view_detial1').click(function () {
        $('#detail_item1').removeClass('d-none');
        $('.main_row').addClass('d-none');
        $('.uni_heading_area ').addClass('d-none');
    });
    $('.single_uni_data .logo_section .back_btn').click(function () {
        $('#detail_item1').addClass('d-none');
        $('.main_row').removeClass('d-none');
        $('.uni_heading_area ').removeClass('d-none');
    });
    $('.single_item_details a').click(function () {
        $('#detail_item1').removeClass('d-none');
        $('.main_row').addClass('d-none');
        $('.uni_heading_area ').addClass('d-none');
        $('.view_all_uni').addClass('d-none');
         $(".view_more_uni .more").toggle();
        $(".view_more_uni .less").toggle()
    });
});


