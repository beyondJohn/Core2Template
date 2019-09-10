var deleteModule = function (ev) {
    if (window.confirm("Please confirm delete.")) {

        // function to find the the array index location containing the JSON Module object .position property of the deleted module
        var findIndex = function () {
            var position = ev.id.split('_')[1];
            var index = 0;
            var countIndex = 0;
            modulesDB.modulesList.forEach(function (module) {
                if (module.position === position) {
                    index = countIndex;
                }
                countIndex++
            });

            return index;
        }
        var removeIndex = findIndex();
        var adjustedIndex = ev.id.split('_')[1];
        // create myModulesDB to store new array from modulesDB with deleted module removed
        var myModulesDB = modulesDB.modulesList.filter(module => module.position != adjustedIndex);

        // used to rename position of modules remaining after deletion
        var positionArray = [];
        myModulesDB.forEach(function (module) {
            positionArray.push(module.position);
        });
        positionArray = positionArray.sort();

        // newPosition seeds and updates ordering for .position properties
        var newPosition = 1;

        // rename the .position property in numeric consecutive asc
        for (var i = 0; i < positionArray.length; i++) {

            var updatePosition = function (modulePosition) {
                myModulesDB.forEach(function (module) {
                    // find lowest unhandled .position value and replace value consecutively 
                    if (module.position == positionArray[i]) {
                        module.position = newPosition;
                    }
                })
            }

            updatePosition(i);
            // increment the .position value for next iteration
            newPosition++;
        }

        // create JSON object containing the temp myModulesDB array, then Post the HTTP request using JSON object as body
        var jsonModulesList = JSON.parse("{\"modulesList\":" + JSON.stringify(myModulesDB) + "}");
        httpRequest("Post", "https://oncologyconsults.com/api/HemaModule", "application/json", jsonModulesList, refreshAfterSave);
    }
};