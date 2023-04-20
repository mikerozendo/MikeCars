function showToast() {
    var toastElList = [].slice.call(document.querySelectorAll('.toast'))
    var toastList = toastElList.map(function (toastEl) {
        return new bootstrap.Toast(toastEl)
    });
    toastList.forEach(toast => toast.show());
}

function buildToastMessase(message) {
    clearToastMessage();
    document.getElementById("toast-body").innerHTML = `<strong class="text-white" id="toast-message">${message}</strong>`;
}

function clearToastMessage() {
    document.getElementById("toast-body").innerHTML = "";
}

function clearToastStyleClasses() {
    document.getElementById("toast-notification").classList.remove('bg-warning');
}

function buildToastStyle(classToBeAdded) {
    clearToastStyleClasses();
    document.getElementById("toast-notification").classList.add(classToBeAdded);
}

function buildToast(classToBeAdded, message) {
    buildToastMessase(message);
    buildToastStyle(classToBeAdded);
    showToast();
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

//function showInvisibleElements() {
//    document.querySelectorAll("not-visible").forEach(
//        function (element, i) {
//            debugger;
//            element[i].classList.remove("not-visible");
//            console.log('[forEach]', nome, i);
//        });

//    for (i = 0; i < elements.length; i++) {
//        elements[i].classList.remove("not-visible");
//    }
//}

//function setTwoNumberDecimal(event) {
//    this.value = parseFloat(this.value).toFixed(2);
//}