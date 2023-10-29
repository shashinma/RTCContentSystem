if (localStorage.getItem("sidebarState") === null) {
    localStorage.setItem("sidebarState", "open");
} else if (localStorage.getItem("sidebarState") === "open") {
    var className = "sidebar open";
    var element = document.getElementById("sidebar_statement");
    element.setAttribute("class", className);
} else if (localStorage.getItem("sidebarState") === "closed") {
    var className = "sidebar close";
    var element = document.getElementById("sidebar_statement");
    element.setAttribute("class", className);
}

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