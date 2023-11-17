// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Get the modal

var popupContainer = document.getElementsByClassName('pop-cont')[0],
    popupBox = document.getElementsByClassName('pop-up')[0];


popupContainer.onclick = function () {
    if (popupBox.style.display === 'block') {
        popupBox.style.display = 'none';
    } else {
        popupBox.style.display = 'block';
    }
};



/*popupContainer.onclick = function () {
    popupBox.classList.toggle("display-js");
   
};*/
/*
window.onclick = function (event) {
    if ((event.target !== popupBox || event.target !== popupContainer) && popupBox.classList.toggle("display-js") === true) {
        popupBox.style.display = 'none'
    }
}*/
