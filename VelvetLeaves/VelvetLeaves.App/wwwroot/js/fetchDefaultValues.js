const productSeriesSelect = document.querySelector(".form-select.productseries-select");
console.log(productSeriesSelect);
productSeriesSelect.addEventListener("change", handleSelect);

function handleSelect(e) {

    $.ajax({
        type: 'GET',
        dataType: 'JSON',
        url: '/Admin/Products/FetchDefaultValues/',
        data: { "productSeriesId": e.currentTarget.value }
        ,
        success: function (response) {
           
            const colorSelect = document.querySelectorAll(".form-check.color-select > input");
            for (const option of colorSelect) {
                if (Array.from(response["colorIds"]).includes(option.value)) {
                    option.setAttribute("selected", "selected");
                } else {
                    option.removeAttribute("selected")
                }
            }

            const materialSelect = document.querySelectorAll(".form-check.material-select > input");
            for (const option of materialSelect) {
                if (Array.from(response["materialIds"]).includes(option.value)) {
                    option.setAttribute("selected", "selected");
                } else {
                    option.removeAttribute("selected")
                }
            }

            const tagSelect = document.querySelectorAll(".form-check.tag-select > input");
            for (const option of tagSelect) {
                if (Array.from(response["TagIds"]).includes(option.value)) {
                    option.setAttribute("selected", "selected");
                } else {
                    option.removeAttribute("selected")
                }
            }
            

            const nameInput = document.querySelector(".form-control.name-input");
            nameInput.value = response.name;
            

            const descriptionInput = document.querySelector(".form-control.description-input");
            descriptionInput.value = response.description;

            const priceInput = document.querySelector(".form-control.price-input");
            priceInput.value = response.price;



        },
        error: function (response) {
            console.log(response);
        }

    });
}

//ColorIds = ps.DefaultColors.Select(c => c.Id),
//    MaterialIds = ps.DefaultMaterials.Select(c => c.Id),
//    TagIds = ps.DefaultTags.Select(c => c.Id),
//    Name = ps.DefaultName,
//    Description = ps.DefaultDescription,
//    Price = ps.DefaultPrice