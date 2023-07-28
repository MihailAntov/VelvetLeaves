const leftArrows = document.querySelectorAll('.left-arrow');
const rightArrows = document.querySelectorAll('.right-arrow');
const deleteButtons = document.querySelectorAll('.delete-button');

leftArrows.forEach(a => a.addEventListener('click', moveLeft));
rightArrows.forEach(a => a.addEventListener('click', moveRight));
deleteButtons.forEach(a => a.addEventListener('click', deleteProduct));

function moveLeft(e) {
    console.log('left');
    
    console.log(e.currentTarget.getAttribute('product'));
    console.log(e.currentTarget.getAttribute('gallery'));
}

function moveRight(e) {
    console.log('right');
    console.log(e.currentTarget.getAttribute('product'));
    console.log(e.currentTarget.getAttribute('gallery'));
}

function deleteProduct(e) {
    console.log('delete');
    console.log(e.currentTarget.getAttribute('product'));
    console.log(e.currentTarget.getAttribute('gallery'));
}