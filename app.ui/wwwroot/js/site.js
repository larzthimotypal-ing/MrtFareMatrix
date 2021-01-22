// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Navbar
const dropdown = document.querySelector(".right ul.user-profile li")

console.log(dropdown);

dropdown.addEventListener("click", function(){
    dropdown.classList.toggle("active");
});
