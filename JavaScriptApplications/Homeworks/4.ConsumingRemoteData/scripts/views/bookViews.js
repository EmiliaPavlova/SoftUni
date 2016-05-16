var app = app || {};

app.bookViews = (function () {
    function showBooks(selector, data) {
        $.get('templates/books.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#list-books').on('load', function() {
                var parent = $(this).parent();
                var parentId = parent.attr('data-id');

            });

        })
            //.then(function () {
            //    $('#addBook').click(function () {
            //        var title = $('#title').val();
            //        var author = $('#author').val();
            //        controller.addBook('#books', title, author);
            //    })
            //})
    }

    return {
        load: function () {
            return {
                showBooks: showBooks
            }
        }
    }
}());