const subcategorySelect = document.querySelector(".form-select.subcategory-select");

subcategorySelect.addEventListener("change", handleSelect);

function handleSelect(e) {
    
    $.ajax({
        type: 'GET',
        dataType: 'JSON',
        url: '/Admin/ProductSeries/FetchProductSeries/',
        data: { "subcategoryId": e.currentTarget.value }
        ,
        success: function (response) {

            const productSeriesSelect = document.querySelector(".form-select.productseries-select");
            Array.from(productSeriesSelect.children).forEach(e => e.remove());
            for (var series of response) {
                
                let option = document.createElement('option');
                option.value = series.id;
                option.textContent = series.name;

                productSeriesSelect.appendChild(option);
            }



        },
        error: function (response) {
            console.log(response);
        }

    });
}