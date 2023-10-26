$(function () {
    pageEvents.loadPartials(function () {
        setProjectName(); 
    });
    pageEvents.setTooltips();
    var stickyElement = document.querySelector("#right_side_sticky");
    new KTSticky(stickyElement);
    
});
$('.update_modal_btn').on('click', function () {
    pageEvents.JSONToform($('#entity_edit_modal'), JSON.parse($(this).attr('data-item')));
});
$('.update_dependencies_modal_btn').on('click', function () {
    pageEvents.JSONToform($('#entity_dependencies_update_modal'), JSON.parse($(this).attr('data-item')));
    
    get($(this).attr('data-link'),null, function (data) {
        
        $('#dependencies_section').children().remove();
        $('#dependencies_section').append(data);
    });

});

$('#from_pool').on('click', function () {
    $('#entity_pool_modal').show();
});

$(document).on('change', '[name="ProjectDeclarationDropdown"]', function () {
    window.location.href = getBaseUrl() + "/projectentity?projectId=" + $(this).val();
});

function setProjectName() {
    
    $('#project_name').html($('[name="ProjectDeclarationDropdown"] option:selected').text());
    
}