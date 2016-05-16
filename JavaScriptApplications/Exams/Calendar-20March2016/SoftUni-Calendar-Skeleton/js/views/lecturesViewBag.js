var app = app || {};

app.lecturesViewBag = (function() {
    function showLectures(selector, data) {
        $.get('templates/calendar.html', function(templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: '2016-01-12',
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            //TODO: redirect to add event page

                            Sammy(function() {
                                this.trigger('addLecture', {title: title, start: start, end: end});
                            })
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        $('#modal-body').html(rendered);
                        $('#editLecture').on('click', function() {
                            //TODO: redirect to edit event page
                            //var title = data.title,
                            //    start = data.start,
                            //    end = data.end;
                            //Sammy(function () {
                            //    this.trigger('editLecture', {title: title, start: start, end: end, _id:id});
                            //})
                        });
                        $('#deleteLecture').on('click', function() {
                            //TODO: redirect to delete event page
                            //Sammy(function () {
                            //    this.trigger('deleteLecture', {_id:id});
                            //})
                        })
                    });
                    $('#events-modal').modal();
                }
            });
        })
    }

    function showMyLectures(selector, data) {
        $.get('templates/calendar.html', function(templ) {
            //var rendered = Mustache.render(templ, data);
            //$(selector).html(rendered);

            $('#calendar').fullCalendar({
                theme: false,
                header: {
                    left: 'prev,next today addEvent',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                defaultDate: '2016-01-12',
                selectable: false,
                editable: false,
                eventLimit: true,
                events: data,
                customButtons: {
                    addEvent: {
                        text: 'Add Event',
                        click: function () {
                            //TODO: redirect to add event page

                            Sammy(function() {
                                this.trigger('addLecture', {title: title, start: start, end: end});
                            })
                        }
                    }
                },
                eventClick: function (calEvent, jsEvent, view) {
                    $.get('templates/modal.html', function (templ) {
                        var rendered = Mustache.render(templ, calEvent);
                        $('#modal-body').html(rendered);
                        $('#editLecture').on('click', function() {
                            //TODO: redirect to edit event page
                            var title = calEvent.title,
                                start = calEvent.start,
                                end = calEvent.end;
                            Sammy(function () {
                                this.trigger('editLecture', {title: title, start: start, end: end, _id:id});
                            })
                        });
                        $('#deleteLecture').on('click', function() {
                            //TODO: redirect to delete event page
                            Sammy(function () {
                                this.trigger('deleteLecture', {_id:id});
                            })
                        })
                    });
                    $('#events-modal').modal();
                }
            });
        })
    }

    function showAddLecture(selector) {
        $.get('templates/add-lecture.html', function(templ) {
            $(selector).html(templ);
            $('#addLecture').on('click', function() {
                var title = $('#title').val(),
                    start = $('#start').val(),
                    end = $('#end').val();

                Sammy(function () {
                    this.trigger('addLecture', {title: title, start: start, end: end});
                })
            })
        })
    }

    function showEditLecture(selector, data) {
        $.get('templates/edit-lecture.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#editLecture').on('click', function() {
                var title = $('#title').val(),
                    start = $('#start').val(),
                    end = $('#end').val();
                    id = $('.data').attr('data-id');

                Sammy(function () {
                    this.trigger('editLecture', {title: title, start: start, end: end, _id:id});
                })
            })
        })
    }

    function showDeleteLecture(selector, data) {
        $.get('templates/delete-lecture.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#deleteLecture').on('click', function() {
                var id = $('#deleteLecture').attr('data-id');

                Sammy(function () {
                    this.trigger('deleteNote', {_id:id});
                })
            })
        })
    }

    return {
        load: function() {
            return {
                showLectures: showLectures,
                showMyLectures: showMyLectures,
                showAddLecture: showAddLecture,
                showEditLecture: showEditLecture,
                showDeleteLecture: showDeleteLecture
            }
        }
    }
}());