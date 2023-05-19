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
    const inputs = document.querySelectorAll('input, textarea');
    try {
        // Validation rules for each input field
        const validationRules = {
            name: { regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/, message: 'Name should only contain letters and spaces, and be at least 2 characters long.' },
            firstName: { regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/, message: 'Firstname should only contain letters and spaces, and be at least 2 characters long.' },
            lastName: { regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/, message: 'Lastname should only contain letters and spaces, and be at least 2 characters long.' },
            email: { regex: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,}(?:[^\W_]|-)*$/, message: 'Please enter a valid email address.' },
            password: { regex: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[{\]}\\|;:'",<.>/?]).{8,}$/, message: 'Password needs to have at least 1 capitalized character, a number and a special character, 8 characters long.' },
            confirmPassword: { regex: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[{\]}\\|;:'",<.>/?]).{8,}$/, message: 'Password needs to have at least 1 capitalized character, a number and a special character, 8 characters long.' },
            message: { regex: /^.{10,}$/, message: 'Message should be at least 10 characters long.' },
            streetName: { regex: /^\S.*\s\d+[a-zA-Z]?$/, message: 'Streetname must be at least 2 characters long.' },
            city: { regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/, message: 'City should only contain letters and spaces, and be at least 2 characters long.' },
            postalcode: { regex: /^\d{5}(?:[-\s]\d{4})?$|^[A-Z]{1,2}\d{1,2}\s?\d{1,2}[A-Z]{0,2}$/, message: 'Postalcode with numbers only' }
        };

        // Array to store validation results for each input field
        const validations = [];

        // Add input event listener to each input field
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

        // Add submit event listener to the form
        form.addEventListener('submit', (event) => {
            event.preventDefault();
            inputs.forEach(input => {
                validateInput(input);
            });
            const isFormValid = validations.every(validation => validation.isValid);
            if (isFormValid) {
                form.submit();
            }
        });

        // Function to validate an input field
        function validateInput(input) {
            const validationRule = validationRules[input.id];
            if (!validationRule) {
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
    } catch { }






/*let formElement;
let nameInput = document.getElementById("name");
let firstNameInput = document.getElementById("firstname");
let lastNameInput = document.getElementById("lastname");
let emailInput = document.getElementById("email");
let streetNameInput = document.getElementById("street");
let postalcodeInput = document.getElementById("postalcode");
let cityInput = document.getElementById("city");
let passwordInput = document.getElementById("password")
let passwordConfirmInput = document.getElementById("confirmPassword")
let messageInput = document.getElementById("message");
let submitBtn = document.getElementById("submitBtn");
try {
    if (document.getElementById("contactForm")) {
        formElement = document.getElementById("contactForm");
        console.log(formElement)
    }
    else if (document.getElementById("loginForm")) {
        formElement = document.getElementById("loginForm")
        console.log(formElement);
    }
    else if (document.getElementById("registerForm")) {
        formElement = document.getElementById("registerForm")
        console.log(formElement);
    }
} catch { }


//validation data for each field
const validations = [
    {
        input: nameInput, regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/,
        message: "Name should only contain letters and spaces, and be at least 2 characters long.",
        validationDiv: document.getElementById("name"),
        validationSpan: document.getElementById("spanErrorName"),
        isValid: false
    },
    {
        input: firstNameInput, regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/,
        message: "Firstname should only contain letters and spaces, and be at least 2 characters long.",
        validationDiv: document.getElementById("firstname"),
        validationSpan: document.getElementById("spanErrorFirstName"),
        isValid: false
    },
    {
        input: lastNameInput, regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/,
        message: "Lastname should only contain letters and spaces, and be at least 2 characters long.",
        validationDiv: document.getElementById("lastname"),
        validationSpan: document.getElementById("spanErrorLastName"),
        isValid: false
    },
    {
        input: emailInput, regex: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,}(?:[^\W_]|-)*$/,
        message: "Please enter a valid email address.",
        validationDiv: document.getElementById("email"),
        validationSpan: document.getElementById("spanErrorEmail"),
        isValid: false
    },
    {
        input: passwordInput, regex: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[{\]}\\|;:'",<.>/?]).{8,}$/,
        message: "Password needs to have at least 1 capitalized character, a number and a special character, 8 characters long. ",
        validationDiv: document.getElementById("password"),
        validationSpan: document.getElementById("spanErrorPassword"),
        isValid: false
    },
    {
        input: passwordConfirmInput, regex: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[{\]}\\|;:'",<.>/?]).{8,}$/,
        message: "Password needs to have at least 1 capitalized character, a number and a special character, 8 characters long. ",
        validationDiv: document.getElementById("confirmPassword"),
        validationSpan: document.getElementById("spanErrorConfirmPassword"),
        isValid: false
    },
    {
        input: messageInput, regex: /^.{10,}$/,
        message: "Message should be at least 10 characters long.",
        validationDiv: document.getElementById("message"),
        validationSpan: document.getElementById("spanErrorMessage"),
        isValid: false
    },
    {
        input: streetNameInput, regex: /^\S.*\s\d+[a-zA-Z]?$/,
        message: "Streetname must be at least 2 characters long.",
        validationDiv: document.getElementById("street"),
        validationSpan: document.getElementById("spanErrorStreetName"),
        isValid: false
    },
    {
        input: cityInput, regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/,
        message: "City should only contain letters and spaces, and be at least 2 characters long.",
        validationDiv: document.getElementById("city"),
        validationSpan: document.getElementById("spanErrorCity"),
        isValid: false
    },
    {
        input: postalcodeInput, regex: /^\d{5}(?:[-\s]\d{4})?$|^[A-Z]{1,2}\d{1,2}\s?\d{1,2}[A-Z]{0,2}$/,
        message: "Postalcode with numbers only",
        validationDiv: document.getElementById("postalcode"),
        validationSpan: document.getElementById("spanErrorPostalcode"),
        isValid: false
    },
];

const forms = document.querySelectorAll('form');

forms.forEach(form => {
    const inputs = form.querySelectorAll('input, textarea');
    const submitButton = form.querySelector('button[type="submit"]');

    // Disable submit button initially
    submitButton.disabled = true;

    // Add input event listener to each input field
    inputs.forEach(input => {
        input.addEventListener('input', () => {
            let isFormValid = true;
            inputs.forEach(input => {
                if (input.required && input.value === '') {
                    isFormValid = false;
                }
            });
            submitButton.disabled = !isFormValid;
        });
    });

    // Add input event listener to each validation
    validations.forEach(validation => {
        try {
            if (validation.input.form === form) {
                validation.input.addEventListener("input", () => {
                    if (validation.regex.test(validation.input.value)) {
                        validation.validationSpan.textContent = "";
                        validation.validationDiv.className = "success";
                        validation.isValid = true;
                    } else {
                        validation.validationSpan.textContent = validation.message;
                        validation.validationDiv.className = "invalid";
                        submitButton.disabled = true;
                    }

*//*                    // check if all fields are valid
                    let allFieldsValid = validations
                        .filter(validation => validation.input.value.trim() !== "" || validation.input === emailInput || validation.input === passwordInput)
                        .every(validation => validation.isValid);
                    submitButton.disabled = !allFieldsValid;*//*
                });
            }
        } catch { }
    });

    // Add submit event listener to the form
    try {
        form.addEventListener("submit", (event) => {
            let isFormValid = true;
            validations.forEach(validation => {
                if (!validation.regex.test(validation.input.value)) {
                    validation.validationSpan.textContent = validation.message;
                    validation.validationDiv.className = "invalid";
                    isFormValid = false;
                } else {
                    validation.validationSpan.textContent = "";
                    validation.validationDiv.className = "success";
                    validation.isValid = true;
                }
            });
            if (!isFormValid) {
                event.preventDefault();
                submitButton.disabled = true;
            } else {
                submitButton.disabled = false;
            }
        });
    } catch { }
});*/




















