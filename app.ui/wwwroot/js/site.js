// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Navbar
const dropdown = document.querySelector(".right ul.user-profile li")

dropdown.addEventListener("click", function(){
    dropdown.classList.toggle("active");
});

//FAQ
const faqTitleList = document.querySelectorAll('.faq-dropdown--title');

faqTitleList.forEach( dropdown => {
    dropdown.addEventListener("click", _ => {
        let faqArrow = dropdown.childNodes[1];
        let nextSibling = dropdown.nextElementSibling;
        let faqItems = [];

        faqArrow.classList.toggle("show");

        while(nextSibling){
            faqItems.push(nextSibling);
            nextSibling = nextSibling.nextElementSibling;
        }

        faqItems.forEach(items => {
            items.classList.toggle("hidden");
        });

    });
});




//Email Verification
 const confettiContainer = document.getElementById('confetti');
 const animItem = bodymovin.loadAnimation(
     {
        wrapper: confettiContainer,
        animType: 'svg',
        loop: false,
         autoplay: true,
       path: 'https://assets6.lottiefiles.com/packages/lf20_u4yrau.json'
  });

