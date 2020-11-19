let dangerAlertDiv: HTMLDivElement;
let successAlertDiv: HTMLDivElement;


let errorAlert = (message: string) => {

    dangerAlertDiv = document.getElementById('dangerAlert') as HTMLDivElement;

    dangerAlertDiv.innerHTML = "<div class=\"alert alert-danger show alert-dismissible\">" +
            "<strong>Error:</strong> " + message + "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
            "<span aria-hidden=\"true\">&times;</span>"
            + "</button></div>";
        window.scrollTo(0, 0);
    }

let successAlert = (message: string) => {

    successAlertDiv = document.getElementById('successAlert') as HTMLDivElement;

    console.log(successAlertDiv);
    successAlertDiv.innerHTML = "<div class=\"alert alert-success show alert-dismissible\">" +
            "<strong>Success:</strong> " + message + "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
            "<span aria-hidden=\"true\">&times;</span>"
            + "</button></div>";
        window.scrollTo(0, 0);
    }



