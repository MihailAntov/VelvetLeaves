const addressPicker = document.querySelector('.address-picker');
addressPicker.addEventListener('change', fetchAddress);
const initial = new Event('change');
addressPicker.dispatchEvent(initial);

function fetchAddress(e) {
    const addressId = e.currentTarget.value;
    

    $.ajax({
        type: 'GET',
        url: '/Addresses/FetchAddress/',
        data: { "addressId": addressId }
        ,
        success: function (response) {
            const resultBox = document.querySelector('.result-box');
            
            resultBox.innerHTML = response;
        },
        error: function (response) {
            console.log(response);
        }

    });
}