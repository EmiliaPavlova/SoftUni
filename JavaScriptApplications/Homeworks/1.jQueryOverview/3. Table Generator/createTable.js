//var data = $.parseJSON($('textarea').val());
var data = [{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},
{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},
{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]

function drow(json) {
    $('#table').append('<tr><th>Manufacturer</th><th>Model</th><th>Year</th><th>Price</th><th>Class</th></tr>');
    json.forEach(function (a) {
        var row = $('<tr>');
        for (var key in a) {
            row.append($('<td>').text(a[key]));
        }
        $('#table').append(row);
    })
}
drow(data);

