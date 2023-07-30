const productLinks = document.querySelectorAll('.product-link');
productLinks.forEach(p => p.addEventListener('mouseover', showThumbnail));

function showThumbnail(e) {
    console.log(e.currentTarget);
}