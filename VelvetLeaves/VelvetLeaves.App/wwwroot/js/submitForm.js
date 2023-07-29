const itemsPerPage = document.querySelector('#itemsPerPage');
itemsPerPage.addEventListener('change', submitForm);

function submitForm(e) {
    e.currentTarget.form.submit();
}