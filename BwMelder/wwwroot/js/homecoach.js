// Save data entered into the HomeCoach form into local storage.
function saveHomeCoach() {
    // Find the form and its elements on the page.
    let inputs = document.getElementById("homecoach-form").elements;
    // Dictionary to hold values.
    let homeCoach = new Object();

    for (input of inputs) {
        // Skip hidden inputs and buttons.
        if (input.type == "hidden"
            || input.type == "submit"
            || input.tagName == "BUTTON") {
            continue;
        }

        // Store input values with the input ID as the key.
        homeCoach[input.id] = input.value;
    }

    // Quit if all values are empty.
    if (Object.values(homeCoach).every(v => v === "")) {
        return;
    }

    // Save the data into local storage.
    // Users will probably open a second crew in another tab, so session storage may not work.
    localStorage.setItem("homeCoach", JSON.stringify(homeCoach));

    console.log("Stored!");
}

// Pre-populate the HomeCoach form with data from local storage.
function loadHomeCoach() {
    // Retrieve data from local storage.
    let homeCoach = JSON.parse(localStorage.getItem("homeCoach"));

    // Quit if there was no data.
    if (homeCoach === null) {
        return false;
    }

    // Write data from the stored object into the corresponding input fields.
    // Keys match the ID of the form inputs.
    for ([key, value] of Object.entries(homeCoach)) {
        let input = document.getElementById(key);

        if (input !== null) {
            input.value = value;
        }  
    }

    return true;
}