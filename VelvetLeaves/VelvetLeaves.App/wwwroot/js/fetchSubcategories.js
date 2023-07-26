const categorySelect = document.querySelector(".form-select.category-select");

categorySelect.addEventListener("change", handleSelect);

function handleSelect(e) {
    
    $.ajax({
        type: 'GET',
        dataType: 'JSON',
        url: '/Admin/Subcategories/FetchSubcategories/',
        data: { "categoryId": e.currentTarget.value }
,
        success: function (response) {
            
            const subcategorySelect = document.querySelector(".form-select.subcategory-select");
            Array.from(subcategorySelect.children).forEach(e => e.remove());
            for (var subcategory of response) {
                
                    let option = document.createElement('option');
                    option.value = subcategory.id;
                    option.textContent = subcategory.name;

                    subcategorySelect.appendChild(option);
                }

                
                
        },
        error: function (response) {
            console.log(response);
        }
            
        });
    }