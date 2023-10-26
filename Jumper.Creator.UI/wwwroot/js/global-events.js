var pageEvents = {
    formToJSON: function ($form) {
        var unindexed_array = $form.serializeArray();
        var indexed_array = {};

        $.map(unindexed_array, function (n, i) {
            indexed_array[n['name']] = n['value'];
        });

        return indexed_array;
    },
    JSONToform: function (form, obj) {
        for (var prop in obj) {
            $(form).find('[name="' + prop + '"]').val(obj[prop]);
        }
    },
    loadPartials: function (callback) {
        
        var partialLength = $('[data-partial]').length;
        $('[data-partial]').each(function (index, item) {
            var url = $(item).data('partial');
            if (url && url.length > 0) {

                var qsParam = $(item).attr('data-qs-param');
                if (qsParam == undefined) {
                    qsParam = "";
                }
                
                pageEvents.setPartialQueryString(url, qsParam.split(','), function (urlWithQs) {
                    
                    get(urlWithQs,
                        null,
                        function (response) {
                            $(item).replaceWith(response);
                            if (callback && partialLength == index + 1) {
                                callback();
                            }
                        });

                });


            }
        });
    },
    setDynamicDropdowns: function () {

        $('[data-dynamic-for]').each(function (index, item) {
            
            var url = $(item).attr('data-dynamic-for');
            if (url && url.length > 0) {

                var qsParam = $(item).attr('data-qs-param');
                if (qsParam == undefined) {
                    qsParam = "";
                }

                pageEvents.setPartialQueryString(url, qsParam.split(','), function (urlWithQs) {
                    $(item).select2({
                        placeholder: "Veri Seçin",
                        //if item has parent
                        dropdownParent: $(item).attr('data-parent'),
                        ajax: {
                            url: urlWithQs,
                            dataType: 'json',
                            data: function (params) {
                                debugger;
                                var query = {
                                    search: params.term,
                                }
                                // Query parameters will be ?search=[term]
                                return query;
                            },
                            // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
                            processResults: function (data) {
                                // Transforms the top-level key of the response object from 'items' to 'results'
                                return {
                                    
                                    results: data.map(function (value, label) {
                                        return {
                                            "id": value.id,
                                            "text": value.name
                                        };
                                    })
                                };
                            },
                        },
                        delay: 250,
                        minimumInputLength: 2,
                        selectOnClose: true
                    });
                    $(item).removeAttr('data-dynamic-for');
                    $(item).removeAttr('data-qs-param');
                    $(item).removeAttr('data-parent');
                });


                

                


            }
        });

    },
    setPartialQueryString: function (url, qsParams, callback) {
        var newQs = qsParams.map(w => w + "=" + gridEvents.qsGetParams(w));
        
        var data = newQs.filter(function (element) {
            return element !== undefined && element !== '=null';
        });
        if (data.length == 0) {
            callback(url);
        }
        else {
            if (url.indexOf('?') != -1) {
                callback(url + '&' + newQs.join('&'));
            }
            else {
                callback(url + '?' + newQs.join('&'));
            }

        }

    },
    setTooltips: function () {
        $('[data-bs-toggle="tooltip"]').tooltip();
    }

}