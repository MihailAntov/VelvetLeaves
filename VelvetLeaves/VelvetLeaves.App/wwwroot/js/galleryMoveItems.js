const leftArrows = document.querySelectorAll('.left-arrow');
const rightArrows = document.querySelectorAll('.right-arrow');
const deleteButtons = document.querySelectorAll('.delete-button');

leftArrows.forEach(a => a.addEventListener('click', moveLeft));
rightArrows.forEach(a => a.addEventListener('click', moveRight));
deleteButtons.forEach(a => a.addEventListener('click', deleteProduct));

function moveLeft(e) {
    let productId = e.currentTarget.getAttribute('product');
    let galleryId = e.currentTarget.getAttribute('gallery');
    const currentElement = e.currentTarget.parentElement.parentElement;
    const previousElement = currentElement.previousElementSibling;
    if (!previousElement) {
        return;
    } 
    currentElement.parentElement.insertBefore(currentElement, previousElement);

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Admin/Galleries/MoveLeft/',
        data: { "productId": productId, "galleryId": galleryId }
        ,
        success: function (response) {

        },
        error: function (response) {
            console.log(response);
        }

    });
    


}

function moveRight(e) {
    let productId = e.currentTarget.getAttribute('product');
    let galleryId = e.currentTarget.getAttribute('gallery');
    const currentElement = e.currentTarget.parentElement.parentElement;
    const previousElement = currentElement.nextElementSibling;
    if (!previousElement) {
        return;
    }
    currentElement.parentElement.insertBefore(previousElement, currentElement);

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Admin/Galleries/MoveRight/',
        data: { "productId": productId, "galleryId": galleryId }
        ,
        success: function (response) {

        },
        error: function (response) {
            console.log(response);
        }

    });
}

function deleteProduct(e) {
    let productId = e.currentTarget.getAttribute('product');
    let galleryId = e.currentTarget.getAttribute('gallery');
    const currentElement = e.currentTarget.parentElement.parentElement;
    currentElement.remove();
    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Admin/Galleries/Delete/',
        data: { "productId": productId, "galleryId": galleryId }
        ,
        success: function (response) {

        },
        error: function (response) {
            console.log(response);
        }

    });
}