var collapseButton = document.getElementById("collapse-button");

collapseButton.addEventListener("click", (event) => {
    event.preventDefault();
    var targetId = collapseButton.getAttribute("data-target");
    var target = document.getElementById(targetId);

    target.classList.toggle("active");
});