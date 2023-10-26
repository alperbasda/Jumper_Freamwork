$('#filter_project_text').on('keyup', function () {
    var text = $(this).val().toLowerCase();
    if (text == '') {
        $('[data-project-filter]').closest('.item_wrapper').removeClass('d-none');
        return;
    }
    
    $('[data-project-filter]').closest('.item_wrapper').addClass('d-none');
    $('[data-project-filter*=' + text + ']').closest('.item_wrapper').removeClass('d-none');
});