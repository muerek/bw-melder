function toggleForm(show, hide) {
    // Switch visibility if the form to hide is actually visible.
    // Check like this and not the other way to make sure visibility is initialized properly on first run.
    if (!hide.classList.contains("d-none")) {
        show.classList.remove("d-none");
        hide.classList.add("d-none");
        // Copy club selection into visible form.
        show.getElementsByTagName("select")[0].value = hide.getElementsByTagName("select")[0].value;
    }
}

function showExistingClubForm() {
    var show = document.getElementById("existingclub-form");
    var hide = document.getElementById("newclub-form");
    toggleForm(show, hide);
}

function showNewClubForm() {
    var hide = document.getElementById("existingclub-form");
    var show = document.getElementById("newclub-form");
    toggleForm(show, hide);
}

// Register event listeners.
document.getElementById("existingclub-radio").onclick = showExistingClubForm;
document.getElementById("newclub-radio").onclick = showNewClubForm;
document.getElementById("existingclub-radio").click();
