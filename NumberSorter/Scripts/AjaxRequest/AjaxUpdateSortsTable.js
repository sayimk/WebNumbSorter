var sortsTable;
document.addEventListener("DOMContentLoaded", function () {
    sortsTable = document.getElementById('sortsTable');
    AjaxRefreshSortTable();
});
var AjaxRefreshSortTable = function () {
    $.ajax({
        type: "get",
        url: "/Data/AllSortedData",
        dataType: "json",
        success: function (Response) {
            updateTable(Response);
        }
    });
};
var updateTable = function (response) {
    sortsTable.innerHTML = "";
    var tableHead = sortsTable.createTHead();
    var tableRow = tableHead.insertRow(0);
    var TRTitle1 = tableRow.insertCell(0);
    var TRTitle2 = tableRow.insertCell(1);
    var TRTitle3 = tableRow.insertCell(2);
    TRTitle1.innerHTML = "<strong>Numbers:</strong";
    TRTitle2.innerHTML = "<strong>Sort Time (milliseconds):</strong";
    TRTitle3.innerHTML = "<strong>Sort Direction:</strong";
    //iterate through response and output
    var rowCount = 1;
    response.forEach(function (i) {
        var row = sortsTable.insertRow(rowCount);
        var rCell1 = row.insertCell(0);
        var rCell2 = row.insertCell(1);
        var rCell3 = row.insertCell(2);
        rCell1.innerHTML = i[0];
        rCell2.innerHTML = i[1];
        rCell3.innerHTML = i[2];
        rowCount++;
    });
};
//# sourceMappingURL=AjaxUpdateSortsTable.js.map