const notify = document.getElementById("notify");
const notifyCloseButton = document.getElementById("notify-close");

if (notify !== null && notifyCloseButton !== null) {
    notifyCloseButton.addEventListener("click", (event) => {
        notify.remove();
    });

    setTimeout(() => {
        notify.remove();
    }, notify.getAttribute("data-time"));
}