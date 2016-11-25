var libManagement = {


    init: function () {
        var windowHeight = $(window).height();
        var wrapperHeight = $('.wrapper').height();
        if (windowHeight > wrapperHeight)
            $('.wrapper').height(windowHeight);
    }
}

$(document).ready(function () {
    libManagement.init();
});
