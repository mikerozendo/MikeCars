//export function uploadImage() {
//    let buttonUpload = document.getElementById("btn-upload-img");
//}
function triggerBtnUpload() {
    document
        .getElementById("btn-upload-img")
        .addEventListener("click", function (e) {
            debugger;
            e.preventDefault();
            let inputFileBtn = document.getElementById("btn-img-file");
            inputFileBtn.click();      
        });
}