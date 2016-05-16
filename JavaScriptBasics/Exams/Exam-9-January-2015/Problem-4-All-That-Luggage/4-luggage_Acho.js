function evaluate(array) {
    var name,luggageName,isFood,isDrink,isFragile,weight,transferredWith;
    var type;

    var sorting = array.pop(array.length-1);

    var tourists = {};

    for(var line in array) {
        var lineArray = array[line].split(/\.*\*\.*/g);
        name = lineArray[0];
        luggageName = lineArray[1];
        isFood = lineArray[2];
        isDrink = lineArray[3];
        isFragile = lineArray[4];
        weight = parseFloat(lineArray[5]);
        transferredWith = lineArray[6];

        type = "other";
        if (isFood == "true") {
            type = "food";
        } else if (isDrink == "true") {
            type = "drink";
        }

        if (!tourists[name]) {
            tourists[name] = {};
        }

        tourists[name][luggageName] = {
            kg: weight,
            fragile: isFragile == "true",
            type: type,
            transferredWith: transferredWith
        };
    }
    var touristsNames = Object.keys(tourists);
    var currentName, currentTourist, luggageNames, sortedTourist, l, w;
    switch (sorting) {
        case "luggage name":
            for (currentName in touristsNames) {
                currentTourist = tourists[touristsNames[currentName]];
                luggageNames = Object.keys(currentTourist);
                luggageNames.sort();

                sortedTourist = {};
                for (l in luggageNames) {
                    sortedTourist[luggageNames[l]] = currentTourist[luggageNames[l]];
                }
                tourists[touristsNames[currentName]] = sortedTourist;
            }
            break;
        case "weight":
            for (currentName in touristsNames) {
                currentTourist = tourists[touristsNames[currentName]];
                luggageNames = Object.keys(currentTourist);
                //console.log(luggageNames);
                var luggages = [];

                for (l in luggageNames) {
                    //console.log(currentTourist[luggageNames[l]]);
                    var currentLuggage = currentTourist[luggageNames[l]];
                    currentLuggage["name"] = luggageNames[l];
                    luggages.push(currentLuggage)
                }
                luggages.sort(function (a, b) {
                    return a["kg"] - b["kg"];
                });
                //console.log(luggages);

                sortedTourist = {};
                for (l in luggages) {
                    sortedTourist[luggages[l]["name"]] = {
                        kg: luggages[l]["kg"],
                        fragile: luggages[l]["fragile"],
                        type: luggages[l]["type"],
                        transferredWith: luggages[l]["transferredWith"]
                    };
                }
                //console.log(sortedTourist);
                tourists[touristsNames[currentName]] = sortedTourist;
            }
            break;
        default:
            break;
    }


    console.log(JSON.stringify(tourists));
}

var input =[
    "Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack",
    "Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack",
    "Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack",
    "Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV",
    "Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV",
    "Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV",
    "weight"
];
evaluate(input);