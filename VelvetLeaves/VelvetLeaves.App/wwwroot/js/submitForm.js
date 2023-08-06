const itemsPerPage = document.querySelector('#itemsPerPage');
const prevpage = document.querySelector('.prev-page');
const nextpage = document.querySelector('.next-page');
itemsPerPage.addEventListener('change', submitForm);
const currentPage = document.getElementById('current-page');
prevpage.addEventListener('click', prevPage);
nextpage.addEventListener('click', nextPage);


function submitForm(e) {
    e.currentTarget.form.submit();
}

function prevPage(e) {
    if (currentPage.value === 1) {
        return;
    }
    currentPage.value--;
    currentPage.form.submit();
}

function nextPage(e) {
    
    currentPage.value++;
    console.log(currentPage.value)
    currentPage.form.submit();
}