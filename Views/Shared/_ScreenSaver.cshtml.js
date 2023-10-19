var timeout;
var popup = document.getElementById('screen-saver');
var minutes = 0.1;

function resetTimer() {
    clearTimeout(timeout);
    timeout = setTimeout(showPopup, minutes * 60 * 1000); // 5 minutes
}

function showPopup() {
    popup.style.display = 'block';
}

function hidePopup() {
    redirectToPage(/News/);
    popup.style.display = 'none';
    redirectToPage(/Home/);
    resetTimer(); // Start the timer again after hiding the popup
}

popup.addEventListener('click', hidePopup);
document.addEventListener('mousemove', resetTimer);

resetTimer(); // Start the timer initially