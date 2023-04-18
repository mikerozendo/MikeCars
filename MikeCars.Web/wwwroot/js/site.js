function showInvisibleElements() {
    let elements = document.querySelectorAll("not-visible");

    for (i = 0; i < elements.length; i++) {
        elements[i].classList.remove("not-visible");
    }
}

//function showInvisleElementsByStep(inputId) {
//    let elements = document.getElementById(inputId);

//    let elements = document.querySelectorAll("not-visible");

//    for (i = 0; i < elements.length; i++) {
//        elements[i].classList.remove("not-visible");
//    }
//}