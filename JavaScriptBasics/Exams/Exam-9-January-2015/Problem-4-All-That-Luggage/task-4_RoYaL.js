/**
 * Created by emily on 4/3/15.
 */
function solve(args) {

    /*
     In order sorting criteria to be one word,
     which lately we will use as a property of an object,
     e.g. the object will have properties "weight" and "luggagename",
     so we can directly sort the object by the user input e.g.
     object1[luggagename] > object2[luggagename]
     */
    var criteria = args.pop().replace(" ", "");

    /*
     We need an array with objects, for normal sorting.
     It's schema is something like
     [
     {
     name: "Kiko",
     possessions: [
     {
     luggagename: "banana", // key used for sorting
     weight: 3.2, // key used for sorting
     isFragile: false,
     type: "food",
     transferredWith: "backpack"
     },
     {
     luggagename: "glasses", // key used for sorting
     weight: 3, // key used for sorting
     isFragile: true,
     type: "other",
     transferredWith: "ATV"
     }
     ]
     },
     {
     name: "Yana",
     possessions: [
     {
     luggagename: ...,
     ...,
     ...
     }
     ]
     }
     ]
     */
    var collection = [];

    for (var row in args) {
        var data = args[row].split(/\.*\*\.*/g);
        var name = data[0];
        var posessionName = data[1];
        var isFood = data[2];
        var isDrink = data[3];
        var isFragile = data[4];
        var weight = Number(data[5]);
        var transferedWith = data[6];

        /*
         Determine the type if it's food, drink or other
         */
        var type = "other";
        if (isFood == "true") type = "food";
        else if (isDrink == "true") type = "drink";

        /*
         Each tourist has luggages/possessions,
         on single iteration we can get only one possession,
         so we will make an object with its info which lately
         we will push into the collection of tourist possessions
         */
        var possesion = {
            luggagename: posessionName, // this key name will be used for sorting later
            weight: weight, // this key name will be used for sorting later too
            isFragile: isFragile == "true",
            type: type,
            transferredWith: transferedWith
        };

        var found = false;
        for (var k in collection) {

            /**
             * Determine if we have that tourist in the collection
             * of tourists
             */
            if (collection[k]["name"] == name) {
                for (var p in collection[k]["possessions"]) {

                    /**
                     * Determine if a tourist already has a luggage with that name
                     */
                    if (collection[k]["possessions"][p]["name"] == posessionName) {
                        delete collection[k]["possessions"][p]
                        break;
                    }
                }

                /**
                 * Push the current iteration's luggage into the collection
                 * of possessions (possession == luggage in our terminology)
                 */
                collection[k]["possessions"].push(possesion);
                found = true;
            }
        }

        if (!found) {
            /*
             If we don't have a tourist with that name, create one
             */
            var tourist = {
                name: name,
                possessions: []
            };

            /**
             * Add to the collection of luggages the first luggage
             * this tourist has
             */
            tourist.possessions.push(possesion);

            /**
             * Add this tourist to the collection of tourists
             */
            collection.push(tourist);
        }
    }

    /**
     * Custom sorting function.
     * It uses the criteria we have pop-ed from the array of args
     * and use it as a key in the "possession" object.
     * The "possession" object has "weight" and "luggagename" keys
     *
     * @param a Luggage/Possession object
     * @param b Luggage/Possession object
     * @returns int (-1, 0, 1)
     */
    function mySort(a, b)
    {
        /*
         Don't do anything if it's "strict"
         */
        if (criteria == 'strict') {
            return 0;
        }

        return a[criteria] > b[criteria];
    }

    collection.forEach(function(tourist) {
        /**
         * Sort with the custom function each tourist's luggage
         */
        tourist.possessions.sort(mySort);
    });

    var result = {};

    /**
     * Make from the collection of tourists the desired object
     * for the output, with key name - the tourist name,
     * and inner keys of each tourist - the luggage name.
     */
    collection.forEach(function(tourist) {
        /**
         * {"Yana" : {}};
         */
        result[tourist.name] = {};
        tourist.possessions.forEach(function(possesion) {
            /**
             * {"Yana" : {"clothes" : { kg: *, fragile: *, type: *, transferredWith: * }};
                 */
            result[tourist.name][possesion.luggagename] = {
                kg: possesion.weight,
                fragile: possesion.isFragile,
                type: possesion.type,
                transferredWith: possesion.transferredWith
            }
        })
    });

    console.log(JSON.stringify(result));
}

solve ([
    'Yana Slavcheva...*..clothes..*false*false......*...false..*..2.2..*.backpack',
    'Kiko..*...socks..*false*false......*...false..*..0.2..*.backpack',
    'Kiko....*...banana..*true*false......*...false..*..3.2..*.backpack',
    'Kiko......*...sticks..*false.....*false......*...false..*..1.6..*.ATV',
    'Kiko*...glasses..*false*...false......*...true..*..3..*.ATV',
    'Manov..*...socks..*false*false....*...false..*0.3..*.ATV',

    'luggage name']);
