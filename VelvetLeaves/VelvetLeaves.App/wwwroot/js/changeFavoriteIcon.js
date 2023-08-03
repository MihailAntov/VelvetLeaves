const icons = document.querySelectorAll('.preview-icon');
const newColorSelect = document.getElementById('favorite-color-select');
const newIconSelect = document.getElementById('favorite-icon-select');


newColorSelect.addEventListener('change', changeIcon);
newIconSelect.addEventListener('change', changeIcon);

function changeIcon(e) {
    const newColor = document.getElementById('favorite-color-select').value;
    const newIcon = document.getElementById('favorite-icon-select').value;
    const previewIcons = document.getElementById('preview-icons');


    while (previewIcons.firstChild) {
        previewIcons.removeChild(previewIcons.firstChild);
    }

    let solid = document.createElement('e');
    solid.style.color = newColor;
    solid.classList.add('fa-2x');
    solid.classList.add(`fa-${newIcon}`);
    solid.classList.add('fa-solid');
    previewIcons.appendChild(solid);

    let regular = document.createElement('e');
    regular.style.color = newColor;
    regular.classList.add('fa-2x');
    regular.classList.add(`fa-${newIcon}`);
    regular.classList.add('fa-regular');
    previewIcons.appendChild(regular);

    
    
}