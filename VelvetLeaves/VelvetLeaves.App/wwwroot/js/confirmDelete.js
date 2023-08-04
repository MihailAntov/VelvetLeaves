const deleteButtons = document.querySelectorAll('#delete-button');


deleteButtons.forEach(b => b.setAttribute("onclick", "return confirm('Are you sure?'"));


