$(document).ready(function(){
// Select the input or the textarea element(s) to run the KioskBoard
    KioskBoard.run('.use-keyboard', {

        /*!
        * Required
        * An Array of Objects has to be defined for the custom keys. Hint: Each object creates a row element (HTML) on the keyboard.
        * e.g. [{"key":"value"}, {"key":"value"}] => [{"0":"A","1":"B","2":"C"}, {"0":"D","1":"E","2":"F"}]
        */
        keysArrayOfObjects: null,

        /*!
        * Required only if "keysArrayOfObjects" is "null".
        * The path of the "kioskboard-keys-${langugage}.json" file must be set to the "keysJsonUrl" option. (XMLHttpRequest to get the keys from JSON file.)
        * e.g. '/Content/Plugins/KioskBoard/dist/kioskboard-keys-english.json'
        */
        keysJsonUrl: '/modules/KioskBoard-2.3.0/dist/kioskboard-keys-english.json',

        /*
        * Optional: An Array of Strings can be set to override the built-in special characters.
        * e.g. ["#", "€", "%", "+", "-", "*"]
        */
        keysSpecialCharsArrayOfStrings: null,

        /*
        * Optional: An Array of Numbers can be set to override the built-in numpad keys. (From 0 to 9, in any order.)
        * e.g. [1, 2, 3, 4, 5, 6, 7, 8, 9, 0]
        */
        keysNumpadArrayOfNumbers: null,
    });
});