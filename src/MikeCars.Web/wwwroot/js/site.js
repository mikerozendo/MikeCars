function showToast() {
    var toastElList = [].slice.call(document.querySelectorAll('.toast'))
    var toastList = toastElList.map(function (toastEl) {
        // Creates an array of toasts (it only initializes them)
        return new bootstrap.Toast(toastEl) // No need for options; use the default options
    });
    toastList.forEach(toast => toast.show()); // This show them
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



function showInvisibleElements() {
    document.querySelectorAll("not-visible").forEach(
        function (element, i) {
            debugger;
            element[i].classList.remove("not-visible");
            console.log('[forEach]', nome, i);
        });

    for (i = 0; i < elements.length; i++) {
        elements[i].classList.remove("not-visible");
    }
}

//function getAdressByZipCode(zipCode) {
//    if (zipCode.length == 8) {
//        let viaCepResponse = await fetch("https://viacep.com.br/ws/" + zipCode + "/json/");
//        let jsonData = await viaCepResponse.json();
//        console.log(jsonData);
//        return await jsonData;
//    }
//    else {
//        document
//            .getElementById("spn-zip-code-error")
//            .classList
//            .remove("not-visible");
//    }
//}

function setTwoNumberDecimal(event) {
    this.value = parseFloat(this.value).toFixed(2);
}

//function editForm() {

//}