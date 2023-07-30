

const secondaryImages = document.querySelectorAll('.all-images');
secondaryImages.forEach(i=> i.addEventListener('click',swapImages))

function swapImages(e) {
    const mainImage = document.querySelector('.main-image');
    const newImage = e.currentTarget.querySelector('.alt-img-src');

    mainImage.setAttribute('src', newImage.getAttribute('src'));
}