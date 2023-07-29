const delButtons = document.querySelectorAll('.delete-button');
delButtons.forEach(b => b.addEventListener('click', handleDelete));

function handleDelete(e) {
    e.currentTarget.parentElement.remove();
}