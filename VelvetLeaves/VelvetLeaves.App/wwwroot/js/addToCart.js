const buyButton = document.querySelector('.buy-button');
buyButton.addEventListener('click', addTocart);


function addTocart(e) {
    $.ajax({
        type: 'GET',
        //dataType: 'JSON',
        url: '/Order/AddToCart/',
        data: { "productId": e.currentTarget.getAttribute('productId') }
        ,
        success: function (response) {

            toastr.success(response.text);



        },
        error: function (response) {
            console.log(response);
        }

    });
}