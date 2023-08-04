const favoriteIcon = document.querySelector('.favorite-item');
if (favoriteIcon) {

favoriteIcon.addEventListener('click', addOrRemove);
}


function addOrRemove(e) {
    const icon = e.currentTarget.firstChild;
    const productId = e.currentTarget.getAttribute('productId');
    if (icon.classList.contains('fa-regular')) {
        icon.classList.remove('fa-regular');
        icon.classList.add('fa-solid');
        $.ajax({
            type: 'GET',
            url: '/User/AddToFavorites/',
            data: { "productId": productId }
            ,
            success: function (response) {
                
            },
            error: function (response) {
                console.log(response);
            }

        });
    } else {
        icon.classList.remove('fa-solid');
        icon.classList.add('fa-regular');
        $.ajax({
            type: 'GET',
            url: '/User/RemoveFromFavorites/',
            data: { "productId": productId }
            ,
            success: function (response) {
                
            },
            error: function (response) {
                console.log(response);
            }

        });
    }
}