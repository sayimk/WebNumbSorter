var saveBtn;
var textInput;
var sortDESC;
var sortASCE;
//onload event
document.addEventListener("DOMContentLoaded", function () {
    //assigning vars
    saveBtn = document.getElementById('saveBtn');
    textInput = document.getElementById('numbInput');
    sortDESC = document.getElementById('sortDESC');
    sortASCE = document.getElementById('sortACSE');
    console.log(successAlertDiv);
    //Event Handlers
    saveBtn.onclick = function () {
        if (textInput.value != "") {
            if (sortDESC.checked) {
                ajaxSortRequest(sortDESC.value);
            }
            else {
                ajaxSortRequest(sortASCE.value);
            }
        }
        else {
            errorAlert("Invalid Input, Please check input");
        }
    };
});
var ajaxSortRequest = function (sortOrder) {
    $.ajax({
        type: "post",
        url: "/NumberManipulator/Sort",
        dataType: "json",
        data: {
            numbersString: textInput.value,
            sortDirection: sortOrder
        },
        success: function (Response) {
            if (Response[0] == 0) {
                successAlert(Response[1]);
                textInput.value = "";
                AjaxRefreshSortTable();
            }
            else if (Response[0]) {
                errorAlert(Response[1]);
            }
        }
    });
};
//# sourceMappingURL=AjaxSortRequest.js.map