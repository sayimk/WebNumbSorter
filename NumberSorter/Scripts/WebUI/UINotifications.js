var dangerAlertDiv;
var successAlertDiv;
var errorAlert = function (message) {
    dangerAlertDiv = document.getElementById('dangerAlert');
    dangerAlertDiv.innerHTML = "<div class=\"alert alert-danger show alert-dismissible\">" +
        "<strong>Error:</strong> " + message + "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
        "<span aria-hidden=\"true\">&times;</span>"
        + "</button></div>";
    window.scrollTo(0, 0);
};
var successAlert = function (message) {
    successAlertDiv = document.getElementById('successAlert');
    console.log(successAlertDiv);
    successAlertDiv.innerHTML = "<div class=\"alert alert-success show alert-dismissible\">" +
        "<strong>Success:</strong> " + message + "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
        "<span aria-hidden=\"true\">&times;</span>"
        + "</button></div>";
    window.scrollTo(0, 0);
};
//# sourceMappingURL=UINotifications.js.map