var timeout;
var popup = document.getElementById('screen-saver');
var minutes = 3;

function resetTimer() {
    clearTimeout(timeout);
    timeout = setTimeout(showPopup, minutes * 60 * 1000); // 5 minutes
}

function showPopup() {
    popup.style.display = 'block';
}

function hidePopup() {
    popup.style.display = 'none';
    resetTimer(); // Start the timer again after hiding the popup
}

popup.addEventListener('click', hidePopup);
document.addEventListener('mousemove', resetTimer);

resetTimer(); // Start the timer initially