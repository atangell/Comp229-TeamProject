var libManagement = {
    closePopup:function(){
        $(".overlay-div").hide("slow");
    },
    openPopup: function () {

        $(".overlay-div").show("slow");
    },

    init: function () {
        var isUserExists= $('.isUserExists').text();
        var windowHeight = $(window).height();
        var wrapperHeight = $('.wrapper').height();
        if (windowHeight > wrapperHeight)
            $('.wrapper').height(windowHeight);
    }
}

$(document).ready(function () {
    libManagement.init();
    $('#imgPopupClose, .btnCancel').on('click', function () {
        libManagement.closePopup();

    });
});
