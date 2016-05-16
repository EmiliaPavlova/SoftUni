$.get('template.html', function (template) {
    var json = {
        "header": "Table",
        "items": [
            { "name": 'Garry Finch', "job title" :'Front End Technical Lead',  "website": 'http://website.com'},
            { "name": 'Bob McFray', "job title": 'Photographer', "website": 'http://google.com'},
            { "name": 'Jenny O\'Sullivan', "job title": 'LEGO Geek', "website": 'http://stackoverflow.com'}
        ],
        "empty": false
    };

    var outp = Mustache.render(template, json);
    $('#wrapper').html(outp);
});