loadDataAsync = function (action, controller, data) {
    $.ajax({
        type: "POST",
        url: '/' + controller + '/' + action,
        data: data,
        success: function (result, status) {
            $(".body-content").html(result);
        }
    });
};