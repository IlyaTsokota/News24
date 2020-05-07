; (function () {

    'use strict';

    var owlCarousel = function () {

        $('#slider1').owlCarousel({
            loop: false,
            margin: 10,
            dots: false,
            nav: true,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            responsive: {
                0: {
                    items: 1
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 4
                }
            }
        });

            $('#slider2').owlCarousel({
                loop: false,
                margin: 10,
                dots: false,
                nav: true,
                navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 2
                    },
                    1000: {
                        items: 3
                    }
                }
            });

            $('#slider3').owlCarousel({
                loop: false,
                margin: 10,
                dots: false,
                nav: true,
                navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
                responsive: {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 2
                    },
                    1000: {
                        items: 3
                    }
                }
            });

    };


    //var videos = function() {


    //    $(document).ready(function () {
    //        $('#play-video').on('click', function (ev) {
    //            $(".fh5co_hide").fadeOut();
    //            $("#video")[0].src += "&autoplay=1";
    //            ev.preventDefault();

    //        });
    //    });


    //    $(document).ready(function () {
    //        $('#play-video_2').on('click', function (ev) {
    //            $(".fh5co_hide_2").fadeOut();
    //            $("#video_2")[0].src += "&autoplay=1";
    //            ev.preventDefault();

    //        });
    //    });

    //    $(document).ready(function () {
    //        $('#play-video_3').on('click', function (ev) {
    //            $(".fh5co_hide_3").fadeOut();
    //            $("#video_3")[0].src += "&autoplay=1";
    //            ev.preventDefault();

    //        });
    //    });


    //    $(document).ready(function () {
    //        $('#play-video_4').on('click', function (ev) {
    //            $(".fh5co_hide_4").fadeOut();
    //            $("#video_4")[0].src += "&autoplay=1";
    //            ev.preventDefault();

    //        });
    //    });
    //};

    //var googleTranslateFormStyling = function() {
    //    $(window).on('load', function () {
    //        $('.goog-te-combo').addClass('form-control');
    //    });
    //};


    //var contentWayPoint = function() {
    //    var i = 0;

    //    $('.animate-box').waypoint( function( direction ) {

    //        if( direction === 'down' && !$(this.element).hasClass('animated-fast') ) {

    //            i++;

    //            $(this.element).addClass('item-animate');
    //            setTimeout(function(){

    //                $('body .animate-box.item-animate').each(function(k){
    //                    var el = $(this);
    //                    setTimeout( function () {
    //                        var effect = el.data('animate-effect');
    //                        if ( effect === 'fadeIn') {
    //                            el.addClass('fadeIn animated-fast');
    //                        } else if ( effect === 'fadeInLeft') {
    //                            el.addClass('fadeInLeft animated-fast');
    //                        } else if ( effect === 'fadeInRight') {
    //                            el.addClass('fadeInRight animated-fast');
    //                        } else {
    //                            el.addClass('fadeInUp animated-fast');
    //                        }

    //                        el.removeClass('item-animate');
    //                    },  k * 50, 'easeInOutExpo' );
    //                });

    //            }, 100);

    //        }

    //    } , { offset: '85%' } );
    //    // }, { offset: '90%'} );
    //};


    var goToTop = function () {

        $('.js-gotop').on('click', function (event) {

            event.preventDefault();

            $('html, body').animate({
                scrollTop: $('html').offset().top
            }, 500, 'swing');

            return false;
        });

        $(window).scroll(function () {

            var $win = $(window);
            if ($win.scrollTop() > 200) {
                $('.js-top').addClass('active');
            } else {
                $('.js-top').removeClass('active');
            }

        });

    };


    $(function () {
        owlCarousel();
        //videos();
        //contentWayPoint();
        goToTop();
        //googleTranslateFormStyling();
    });

}());
function googleTranslateElementInit() {
    new google.translate.TranslateElement({ pageLanguage: 'en' }, 'google_translate_element');
}
//Для модальных окон на Ajax
$(function () {

    //Optional: turn the chache off
    $.ajaxSetup({ cache: false });

    $('#btnCreate').click(function () {
        $('#dialogContent').load(this.href, function () {
            $('#dialogDiv').modal({
                backdrop: 'static',
                keyboard: true
            }, 'show');
            bindForm(this);
        });
        return false;
    });
});
function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#dialogDiv').modal('hide');
                    // Refresh:
                    // location.reload();
                } else {
                    $('#dialogContent').html(result);
                    bindForm();
                }
            }
        });
        return false;
    });
}

// end
$(document).ready(function () {
    $('.block').on('click', '.extremum-click', function () {
        $(this).siblings('.extremum-slide').slideToggle(0);
    });
});

(function ($) {
    $(function () {

        $('ul.tabs__caption').each(function (i) {
            var storage = localStorage.getItem('tab' + i);
            if (storage) {
                $(this).find('li').removeClass('active').eq(storage).addClass('active')
                    .closest('div.tabs').find('div.tabs__content').removeClass('active').eq(storage).addClass('active');
            }
        });

        $('ul.tabs__caption').on('click', 'li:not(.active)', function () {
            $(this)
                .addClass('active').siblings().removeClass('active')
                .closest('div.tabs').find('div.tabs__content').removeClass('active').eq($(this).index()).addClass('active');
            var ulIndex = $('ul.tabs__caption').index($(this).parents('ul.tabs__caption'));
            localStorage.removeItem('tab' + ulIndex);
            localStorage.setItem('tab' + ulIndex, $(this).index());
        });

    });
})(jQuery);

$('.upload__image').change(function () {
    const oInput = this;
    const validFileExtensions = [".jpg", ".jpeg", ".bmp", ".gif", ".png", ".jfif"];
    for (let i = 0; i < oInput.files.length; i++) {
        if (oInput.type === "file") {
            const sFileName = oInput.files[i].name;
            if (sFileName.length > 0) {
                let blnValid = false;
                for (let j = 0; j < validFileExtensions.length; j++) {
                    const sCurExtension = validFileExtensions[j];
                    if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() ==
                        sCurExtension.toLowerCase()) {
                        blnValid = true;
                        break;
                    }
                }

                if (!blnValid) {
                    alert(sFileName +
                        " имеет недоступный формат. Доступные форматы: " +
                        validFileExtensions.join(", "));
                    oInput.value = "";
                    return false;
                }
            }
        }
    }
    return true;
});

$('#supplyProductAdd').click(function () {
    var res = "";
    var count = $('.supply__product').length;
    var first = $('.supply__product')[0].innerHTML;
    first = first.replace(/\[0\]/g, '[' + count + ']');
    res += '<div class="form-group row mx-0 supply__product">' +
        first +
        '</div>';
    $('#supplyProducts').append(res);
});

var submitAutocompleteForm = function (event, ui) {
    var $input = $(this); // the HTML element (Textbox)

    // selected value
    $input.val(ui.item.label); // ui.item.label = the label value (product)

    window.location.href = "/Start/Details?id=" + ui.item.label;
};
var createAutocomplete = function () {
    var $input = $(this); // the HTML element (Textbox)

    var options = {
        // selecting the source by finding elements with the 'data-' attribute
        source: $input.attr("data-autocomplete"), // Required
        select: submitAutocompleteForm // Optional
    };

    // apply options
    $input.autocomplete(options);
};

// targets input elements with the 'data-' attributes and each time the input changes
// it calls the 'createAutocomplete' function
$("input[data-autocomplete]").each(createAutocomplete);