
    const tagButtons = document.querySelectorAll(".filterButton");
    
    tagButtons.forEach(b => b.addEventListener("click", handleClick));


    function handleClick(e) {
        const div = e.target.parentElement;
        const options = div.children[1];
        if (options.style.display === "none") {
            options.style.display = "block"
        } else {
            options.style.display = "none";
        }
    }


//TODO replace this with collapse