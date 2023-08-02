const buyButton = document.querySelector('.buy-button');
buyButton.addEventListener('click', addTocart);




function addTocart(e) {
    console.log("THIS IS IT?")

    $.ajax({
        type: 'GET',
        //dataType: 'JSON',
        url: '/Orders/AddToCart/',
        data: { "productId": e.currentTarget.getAttribute('productId') }
        ,
        success: function (response) {

            toastr.success('Successfully added item to cart!');



        },
        error: function (response) {
            console.log(response);
        }

    });
}



