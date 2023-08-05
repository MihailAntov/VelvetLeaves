const deleteButtons = document.querySelectorAll('.delete-button');


deleteButtons.forEach(b => b.addEventListener('click', confirmDelete));

function confirmDelete(e) {
    return confirm(`Are you sure? ${e}`)
}


