const dropdownButton = document.querySelector("#dropdown");
const dropdownItems = document.querySelectorAll(".dropdown-item");

console.log(dropdownItems);

dropdownItems.forEach((dropdownItem) => {
  dropdownItem.addEventListener("click", () => {
    dropdownButton.innerHTML = dropdownItem.innerHTML;
  });
});
