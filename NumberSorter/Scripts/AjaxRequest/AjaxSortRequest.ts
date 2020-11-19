
let saveBtn: HTMLButtonElement;
let textInput: HTMLInputElement;
let sortDESC: HTMLInputElement;
let sortASCE: HTMLInputElement;

//onload event
document.addEventListener("DOMContentLoaded", () => {

    //assigning vars
    saveBtn = document.getElementById('saveBtn') as HTMLButtonElement;
    textInput = document.getElementById('numbInput') as HTMLInputElement;
    sortDESC = document.getElementById('sortDESC') as HTMLInputElement;
    sortASCE = document.getElementById('sortACSE') as HTMLInputElement;

    console.log(successAlertDiv);
    //Event Handlers
    saveBtn.onclick = () => {


        if (textInput.value != "") {
            if (sortDESC.checked) {

                ajaxSortRequest(sortDESC.value);
            } else {

                ajaxSortRequest(sortASCE.value);
            }
        } else {
            errorAlert("Invalid Input, Please check input");
        }
    }
})


let ajaxSortRequest = (sortOrder: string) => {

    $.ajax({
        type: "post",
        url: "/NumberManipulator/Sort",
        dataType: "json",
        data: {
            numbersString: textInput.value,
            sortDirection: sortOrder
        },
        success: (Response) => {

            if (Response[0] == 0) {
                successAlert(Response[1]);
                textInput.value = "";
                AjaxRefreshSortTable();

            } else if (Response[0]) {
                errorAlert(Response[1]);
            }
            
        }
    })
}
