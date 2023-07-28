const batchUpload = document.querySelector('#formFile');
batchUpload.addEventListener('change', visualizeFile);


function visualizeFile(e) {
    const input = e.currentTarget;
    const gallery = document.querySelector('.image-preview-gallery');


        let newImage = document.createElement('img');
        newImage.classList.add('img-fluid');
        newImage.classList.add('img-preview');
        newImage.classList.add('col-2');


    newImage.src = URL.createObjectURL(input.files[0]);
    gallery.replaceChildren();
    gallery.appendChild(newImage);
 }

   




