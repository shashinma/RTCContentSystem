// Dark & Light toggle

document.querySelector(".day-night input").addEventListener("change", () => {
    document.querySelector("body").classList.add("toggle");
    setTimeout(() => {
        document.querySelector("body").classList.toggle("light");

        setTimeout(
            () => document.querySelector("body").classList.remove("toggle"),
            10
        );
    }, 5);
});
