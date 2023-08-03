const orderButtons = document.querySelectorAll('.order-type-button');
orderButtons.forEach(b => b.addEventListener('click', updateList));


function updateList(e) {
    const orderButtons = document.querySelectorAll('.order-type-button');
    orderButtons.forEach(b => b.classList.remove('btn-lg'));
    const newStatus = e.currentTarget.getAttribute('orderStatus');
    e.currentTarget.classList.add('btn-lg');
    $.ajax({
        type: 'GET',
        url: 'FetchOrders/',
        data: { "status": newStatus }
        ,
        success: function (response) {
            const orderDiv = document.querySelector('.orders-list');
            orderDiv.innerHTML = response;
            


        },
        error: function (response) {
            console.log(response);
        }

    });

}












