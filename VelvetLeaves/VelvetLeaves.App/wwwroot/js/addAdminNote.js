const button = document.getElementById('add-note');
button.addEventListener('click', updateNote);

function updateNote(e) {
    const note = document.getElementById('admin-note');
    const id = document.getElementById('order-id');

    $.ajax({
        type: 'POST',
        dataType: 'JSON',
        url: '/Admin/Orders/AddAdminNote/',
        data: { "note": note.value, "orderId":id.value }
        ,
        success: function (response) {

            note.value = response;
            toastr.success('Note saved.');



        },
        error: function (response) {
            console.log(response);
        }

    });
}