const batchUpload = document.querySelector('#imageBatch');
batchUpload.addEventListener('change', handleBatch);


function handleBatch(e) {
    const batchUpload = document.querySelector('#imageBatch');
    const allImages = document.querySelector('#allImages');
    const gallery = document.querySelector('.image-preview-gallery');

    const thisBatchFiles = new DataTransfer();

    for (var image of allImages.files) {
        thisBatchFiles.items.add(image);
    }

    for (var image of batchUpload.files) {
        thisBatchFiles.items.add(image);
        let newImage = document.createElement('img');
        newImage.classList.add('img-fluid');
        newImage.classList.add('img-preview');
        newImage.classList.add('col-2');
        
        
        newImage.src = URL.createObjectURL(batchUpload.files[0]);
        gallery.appendChild(newImage);
    }

    allImages.files = thisBatchFiles.files;

    console.log(allImages.files);

}



