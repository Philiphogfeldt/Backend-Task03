

document.getElementById("@(item.Name)Checkbox").addEventListener("change", function () {
    var label = document.querySelector(".beerFavoriteLabel");
    if (this.checked) {
        label.classList.add("checked");
    } else {
        label.classList.remove("checked");
    }
});