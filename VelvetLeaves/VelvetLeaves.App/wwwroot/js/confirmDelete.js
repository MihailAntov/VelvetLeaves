const deleteButtons = document.querySelectorAll('.delete-button');


deleteButtons.forEach(b => b.addEventListener('click', confirmDelete));

function confirmDelete(e) {
    if (!confirm(`Are you sure?`)) {
        e.preventDefault();
    }
}


