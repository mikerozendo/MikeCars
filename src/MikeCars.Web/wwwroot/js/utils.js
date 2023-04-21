function buildSuccessToast(message) {
    notifier.show('Success!', message, 'success', '/Images/default-notifier-success.png', 0);
}

function buildWarningToast(message) {
    notifier.show("Warning!", message, 'warning', '/Images/default-notifier-warning.png', 0);
}

function buildErrorToast(message) {
    notifier.show('Error!', message, 'danger', '/Images/default-notifier-error.png', 0);
}

function buildModalCancelNotification(urlToRedirect, message) {
    buildModalText(message);
    buildModalUrlToRedirect(urlToRedirect);
}

function buildModalUrlToRedirect(url) {
    document.getElementById("modal-redirect-url").setAttribute("href", url);
}

function buildModalText(message) {
    clearModalText();
    document.getElementById("modal-body-cancel-notification").innerHTML = `<strong id="modal-message">${message}</strong>`;
}

function clearModalText() {
    document.getElementById("modal-body-cancel-notification").innerHTML = "";
}

function filterOnTable(filterElement) {

    let textContentToSearch = filterElement.value.toLowerCase().trim();
    var tableRows = document.getElementById("table-body").rows;

    for (let row of tableRows) {

        if (textContentToSearch.length > 0) {

            let filteredRowNodes = Array.from(row.cells)
                .filter(dataTable => dataTable.classList.contains("searchable"))

            let arrayData = [];

            for (let tableData of filteredRowNodes) {
                let rowText = tableData.outerText.toLowerCase();

                if (rowText.includes(textContentToSearch)) {
                    arrayData.push(true);
                } else {
                    arrayData.push(false);
                }

            }

            let shouldFilter = arrayData.find(x => x);

            if (shouldFilter != undefined && shouldFilter) {
                row.classList.remove("not-visible")
            } else {
                row.classList.add("not-visible")
            }

        } else {
            row.classList.remove("not-visible")
        }    
    }
}

//function setTwoNumberDecimal(event) {
//    this.value = parseFloat(this.value).toFixed(2);
//}