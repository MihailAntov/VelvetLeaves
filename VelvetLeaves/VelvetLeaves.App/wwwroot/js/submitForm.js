const itemsPerPage = document.querySelector('#itemsPerPage');
const prevpage = document.querySelector('.prev-page');
const nextpage = document.querySelector('.next-page');
itemsPerPage.addEventListener('change', submitForm);
const currentPage = document.getElementById('current-page');
if (prevpage) {
prevpage.addEventListener('click', prevPage);
}

if (nextpage) {
nextpage.addEventListener('click', nextPage);
}


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
    currentPage.form.submit();
}