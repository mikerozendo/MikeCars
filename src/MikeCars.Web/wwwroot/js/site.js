function showInvisibleElements() {
    let elements = document.querySelectorAll("not-visible");

    for (i = 0; i < elements.length; i++) {
        elements[i].classList.remove("not-visible");
    }
}

function getAdressByZipCode(zipCode) {
    if (zipCode.length == 8) {
        let viaCepResponse = await fetch("https://viacep.com.br/ws/" + zipCode + "/json/");
        let jsonData = await viaCepResponse.json();
        console.log(jsonData);
        return await jsonData;
    }
    else {
        document
            .getElementById("spn-zip-code-error")
            .classList
            .remove("not-visible");
    }
}

function setTwoNumberDecimal(event) {
    this.value = parseFloat(this.value).toFixed(2);
}