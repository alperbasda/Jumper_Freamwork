
var formEvents = {
    sendFormAsync: function (form,callback) {
        var formData = pageEvents.formToJSON($(form));
        
        post($(form).attr('action'), formData, function (data) { if (callback) { callback(data); } } );
    },

}
