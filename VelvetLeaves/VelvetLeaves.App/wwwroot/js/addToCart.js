const buyButton = document.querySelector('.buy-button');
buyButton.addEventListener('click', addTocart);




function addTocart(e) {
   

    $.ajax({
        type: 'GET',
        //dataType: 'JSON',
        url: '/Orders/AddToCart/',
        data: { "productId": e.currentTarget.getAttribute('productId') }
        ,
        success: function (response) {

            toastr.success('Successfully added item to cart!');
            const badge = document.querySelector('.cart-badge');
            const items = Array.from(response.items.map(item=>item.quantity));
            let count = items.reduce((sum, current) => sum + current, 0);
            console.log(count);
            badge.textContent = count;


        },
        error: function (response) {
            console.log(response);
        }

    });
}



