
const plusButton = document.querySelectorAll('.plus-button');
plusButton.forEach(b => b.addEventListener('click', increaseNumberInCart));


const minusButton = document.querySelectorAll('.minus-button');
minusButton.forEach(b => b.addEventListener('click', decreaseNumberInCart));



function increaseNumberInCart(e) {
    const productId = e.currentTarget.getAttribute('productId');
    const minusButton = e.currentTarget.previousElementSibling.previousElementSibling;
    const quantity = e.currentTarget.previousElementSibling;
    const totalForThisItem = e.currentTarget.parentElement.parentElement.nextElementSibling;

    $.ajax({
        type: 'PATCH',
        dataType: 'JSON',
        url: '/Order/AddToCart/',
        data: { "productId": productId }
        ,
        success: function (response) {
            document.getElementById('total').textContent = `Total: ${response.total.toFixed(2)} BGN`;
            document.getElementById('total-items').textContent = `Total items: ${response.totalItems}`;

            const newValues = Array.from(response.items).filter(i => i.id === Number(productId))[0];

            minusButton.classList.remove('invisible');
            quantity.textContent = newValues.quantity;

            totalForThisItem.textContent = (newValues.quantity * newValues.price).toFixed(2);
                
                
                


        },
        error: function (response) {
            console.log(response);
        }

    });
}

function decreaseNumberInCart(e) {
    const productId = e.currentTarget.getAttribute('productId');
    const minusButton = e.currentTarget;
    const quantity = e.currentTarget.nextElementSibling;
    const totalForThisItem = e.currentTarget.parentElement.parentElement.nextElementSibling;

    if (quantity.textContent === 1) {
        return;
    }

    $.ajax({
        type: 'PATCH',
        dataType: 'JSON',
        url: '/Order/RemoveFromCart/',
        data: { "productId": e.currentTarget.getAttribute('productId') }
        ,
        success: function (response) {
            document.getElementById('total').textContent = `Total: ${response.total.toFixed(2)} BGN`;
            document.getElementById('total-items').textContent = `Total items: ${response.totalItems}`;

            const newValues = Array.from(response.items).filter(i => i.id === Number(productId))[0];

            
            quantity.textContent = newValues.quantity;
            
            if (newValues.quantity === 1) {
                minusButton.classList.add('invisible');
            }

            totalForThisItem.textContent = (newValues.quantity * newValues.price).toFixed(2);


        },
        error: function (response) {
            console.log(response);
        }

    });
}

//items
//total
//totalItems