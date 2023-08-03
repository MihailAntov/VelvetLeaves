
const plusButton = document.querySelectorAll('.plus-button');
plusButton.forEach(b => b.addEventListener('click', increaseNumberInCart));


const minusButton = document.querySelectorAll('.minus-button');
minusButton.forEach(b => b.addEventListener('click', decreaseNumberInCart));

const deleteButton = document.querySelectorAll('.delete-button');
deleteButton.forEach(b => b.addEventListener('click', deleteItemFromCart));



function increaseNumberInCart(e) {
    e.stopPropagation();
    const productId = e.currentTarget.getAttribute('productId');
    const minusButton = document.querySelector(`.minus-button[productId='${productId}'`);
    const quantity = document.querySelector(`.product-quantity[productId='${productId}'`);
    const hiddenQuantity = document.querySelector(`.product-quantity-hidden[productId='${productId}'`);

    const totalForThisItem = document.querySelector(`.product-total[productId='${productId}'`);

    $.ajax({
        type: 'GET',
        dataType: 'JSON',
        url: '/Orders/AddToCart/',
        data: { "productId": productId }
        ,
        success: function (response) {
            document.getElementById('total').textContent = response.total.toFixed(2);
            document.getElementById('total-items').textContent = response.totalItems;

            const newValues = Array.from(response.items).filter(i => i.id === Number(productId))[0];

            minusButton.disabled = false;
            quantity.textContent = newValues.quantity;
            hiddenQuantity.value = newValues.quantity;

            totalForThisItem.textContent = (newValues.quantity * newValues.price).toFixed(2);
                
                
                


        },
        error: function (response) {
            console.log(response);
        }

    });
}

function decreaseNumberInCart(e) {
    e.stopPropagation();
    const productId = e.currentTarget.getAttribute('productId');
    const minusButton = e.currentTarget;
    const quantity = document.querySelector(`.product-quantity[productId='${productId}'`);
    const hiddenQuantity = document.querySelector(`.product-quantity-hidden[productId='${productId}'`);
    const totalForThisItem = document.querySelector(`.product-total[productId='${productId}'`);

    if (quantity.value < 2) {
        return;
    }

    $.ajax({
        type: 'GET',
        dataType: 'JSON',
        url: '/Orders/RemoveFromCart/',
        data: { "productId": e.currentTarget.getAttribute('productId') }
        ,
        success: function (response) {
            document.getElementById('total').textContent = response.total.toFixed(2);
            document.getElementById('total-items').textContent = response.totalItems;

            const newValues = Array.from(response.items).filter(i => i.id === Number(productId))[0];

            
            quantity.textContent = newValues.quantity;
            hiddenQuantity.value = newValues.quantity;
            
            if (newValues.textContent === 1) {
                minusButton.disabled = true;
            }

            totalForThisItem.textContent = (newValues.quantity * newValues.price).toFixed(2);


        },
        error: function (response) {
            console.log(response);
        }

    });
}

function deleteItemFromCart(e) {
    e.stopPropagation();
    
    const productId = e.currentTarget.getAttribute('productId');
    //const productRow = e.currentTarget.parentElement.parentElement;
    const productRow = document.querySelector(`#product${productId}`);
    $.ajax({
        type: 'GET',
        dataType: 'JSON',
        url: '/Orders/DeleteFromCart/',
        data: { "productId": productId }
        ,
        success: function (response) {
            document.getElementById('total').textContent = response.total.toFixed(2);
            document.getElementById('total-items').textContent = response.totalItems;
            productRow.remove();

            if (response.items.length === 0) {
                console.log(response.items.length);
                const full = document.querySelector('.full-cart');
                const empty = document.querySelector('.empty-cart');
                const checkout = document.querySelector('.checkout-panel');
                full.classList.remove('d-block');
                full.classList.add('d-none');
                empty.classList.remove('d-none');
                empty.classList.add('d-block');
                checkout.classList.remove('d-block');
                checkout.classList.add('d-none');
                
                
            }
        },
        error: function (response) {
            console.log(response);
        }

    });
}

//items
//total
//totalItems