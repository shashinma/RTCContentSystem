let arrow = document.querySelectorAll(".arrow");
for (var i = 0; i < arrow.length; i++) {
    arrow[i].addEventListener("click", (e) => {
        let arrowParent = e.target.parentElement.parentElement;//selecting main parent of arrow
        arrowParent.classList.toggle("showMenu");
    });
}

let sidebar = document.querySelector(".sidebar");
let sidebarBtn = document.querySelector(".bx-menu");
console.log(sidebarBtn);

// Проверяем, есть ли сохраненное состояние в localStorage или sessionStorage
if (localStorage.getItem("sidebarState") === "closed") {
    sidebar.classList.add("close");
}

sidebarBtn.addEventListener("click", () => {
    sidebar.classList.toggle("close");

    // Сохраняем состояние в localStorage или sessionStorage
    if (sidebar.classList.contains("close")) {
        localStorage.setItem("sidebarState", "closed");
    } else {
        localStorage.setItem("sidebarState", "open");
    }
});

var sidebarState = localStorage.getItem('sidebarState');
console.log(sidebarState);


// let value = localStorage.getItem("sidebarState");
// let sidebarClass = value === null || value === "" ? "sidebar open" : value === "open" ? "sidebar open" : "sidebar";