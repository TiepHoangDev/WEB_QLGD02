﻿function myAjax(url, data, done, error, complete) {
    if (url) {
        if (!data) data = '';
        $.ajax({
            url: url,
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
        }).done(function (result, xhr, status) {
            if (done) done(result, xhr, status);
        }).fail(function (result, xhr, status) {
            if (error) error(result, xhr, status);
        }).always(function (result, xhr, status) {
            if (complete) complete(result, xhr, status);
        });
    }
}

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    //var dt = new Date(value);
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}