let sortsTable: HTMLTableElement;

document.addEventListener("DOMContentLoaded", () => {

    sortsTable = document.getElementById('sortsTable') as HTMLTableElement;

    AjaxRefreshSortTable();
})

let AjaxRefreshSortTable = () => {
    $.ajax({
        type: "get",
        url: "/Data/AllSortedData",
        dataType: "json",
        success: (Response) => {
            updateTable(Response);

        }
    })
}


let updateTable = (response) => {

    sortsTable.innerHTML = "";

    let tableHead = sortsTable.createTHead();
    let tableRow = tableHead.insertRow(0);
    let TRTitle1 = tableRow.insertCell(0);
    let TRTitle2 = tableRow.insertCell(1);
    let TRTitle3 = tableRow.insertCell(2);

    TRTitle1.innerHTML = "<strong>Numbers:</strong";
    TRTitle2.innerHTML = "<strong>Sort Time (milliseconds):</strong";
    TRTitle3.innerHTML = "<strong>Sort Direction:</strong";

    //iterate through response and output

    let rowCount: number = 1;
    response.forEach(i => {

        let row = sortsTable.insertRow(rowCount);
        let rCell1 = row.insertCell(0);
        let rCell2 = row.insertCell(1);
        let rCell3 = row.insertCell(2);

        rCell1.innerHTML = i[0];
        rCell2.innerHTML = i[1];
        rCell3.innerHTML = i[2];

        rowCount++;
    })
}
