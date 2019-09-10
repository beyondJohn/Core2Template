var editModules = function () {
    httpRequest("Post", "https://oncologyconsults.com/api/HemaModule", "application/json", data, makeModules);
};
