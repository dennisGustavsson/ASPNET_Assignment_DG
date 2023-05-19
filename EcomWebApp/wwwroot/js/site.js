// HAMBURGER MENU
const toggleMenu = (attribute) => {
    try {
        const toggleBtn = document.querySelector(attribute)
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
                toggleBtn.classList.add('btn-outline-dark')
                toggleBtn.classList.add('btn-toggle-white')
            }

            else {
                element.classList.remove('open-menu')
                toggleBtn.classList.remove('btn-outline-dark')
                toggleBtn.classList.remove('btn-toggle-white')
            }
        })
    } catch { }
}
toggleMenu('[data-option="toggle"]');

// FOOTER TO BOTTOM

const footerPosition = (element, scrollHeight, innerHeight) => {
    try {
        const _element = document.querySelector(element);
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight);

        _element.classList.toggle('position-fixed', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)

    } catch { }
}

footerPosition('footer', document.body.scrollHeight, window.innerHeight);




// FORM VALIDATIONS


const form = document.querySelector('form');
const inputs = document.querySelectorAll('input, textarea'); //selects all inputs or textareas
 
// Validation rules for each input field
const validationRules = {
    name: { regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/, message: 'Name should only contain letters and spaces, and be at least 2 characters long.' },
    firstName: { regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/, message: 'First name should only contain letters and spaces, and be at least 2 characters long.' },
    lastName: { regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/, message: 'Last name should only contain letters and spaces, and be at least 2 characters long.' },
    email: { regex: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,}(?:[^\W_]|-)*$/, message: 'Please enter a valid email address.' },
    password: { regex: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[{\]}\\|;:'",<.>/?]).{8,}$/, message: 'Password needs to have at least 1 capitalized character, a number and a special character, 8 characters long.' },
    confirmPassword: { regex: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[{\]}\\|;:'",<.>/?]).{8,}$/, message: 'Password needs to have at least 1 capitalized character, a number and a special character, 8 characters long.' },
    message: { regex: /^.{10,}$/, message: 'Message should be at least 10 characters long.' },
    streetName: { regex: /^\S.*\s\d+[a-zA-Z]?$/, message: 'Streetname must be at least 2 characters long.' },
    city: { regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/, message: 'City should only contain letters and spaces, and be at least 2 characters long.' },
    postalcode: { regex: /^\d{5}(?:[-\s]\d{4})?$|^[A-Z]{1,2}\d{1,2}\s?\d{1,2}[A-Z]{0,2}$/, message: 'Postalcode with numbers only' }
};

// Array to store validation results for each field
const validations = [];

//input event listener to each field
inputs.forEach(input => {
    input.addEventListener('input', () => {
        validateInput(input);
        const validationIndex = validations.findIndex(v => v.input.id === input.id);
        if (validationIndex >= 0) {
            validations[validationIndex].isValid = validationRules[input.id].regex.test(input.value);
        } else {
            validations.push({ input: input, isValid: validationRules[input.id].regex.test(input.value) });
        }
    });
});

// when submitting form
form.addEventListener('submit', (event) => {
    event.preventDefault();
    let isFormValid = true;
    inputs.forEach(input => {
        if (!input.checkValidity()) {
            isFormValid = false;
        }
    });
    if (isFormValid) {
        form.submit();
    } else {
        alert('Please fill out all required fields.');

    }
});

function validateInput(input) {
    const validationRule = validationRules[input.id];
    if (!validationRule) {
        return;
    }
    if (input.value.trim().length === 0) {
        const validationDiv = document.getElementById(input.id);
        const validationSpan = document.getElementById(`spanError${input.id.charAt(0).toUpperCase() + input.id.slice(1)}`);
        validationSpan.textContent = "This field is required.";
        validationDiv.className = 'error';
        return;
    }
    const isValid = validationRule.regex.test(input.value);
    const validationDiv = document.getElementById(input.id);
    const validationSpan = document.getElementById(`spanError${input.id.charAt(0).toUpperCase() + input.id.slice(1)}`);
    if (isValid) {
        validationSpan.textContent = "";
        validationDiv.className = 'success';
    } else {
        validationSpan.textContent = validationRule.message;
        validationDiv.className = 'error';
    }
}





















