function solve(input) {

    var arr = input.map(function (element) {
        return {
            'name' : element['name'],
            'score' : element['score'] = Number((element['score'] * 1.1).toFixed(1)),
            'hasPassed' : element['score'] >= 100
        }
    });

    arr = arr.filter(function(element) {
        return element['score'] >= 100;
    });

    arr.sort(function(x, y) {
        return x.name > y.name;
    });

    console.log(arr);
}

solve([
        {
            'name' : 'Пешо',
            'score' : 91
        },
        {
            'name' : 'Лилия',
            'score' : 290
        },
        {
            'name' : 'Алекс',
            'score' : 343
        },
        {
            'name' : 'Габриела',
            'score' : 400
        },
        {
            'name' : 'Жичка',
            'score' : 70
        }
    ]
);
