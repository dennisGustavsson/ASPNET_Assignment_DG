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


let formElement;
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
        validationSpan: document.getElementById("spanErrorName")
    },
    {
        input: firstNameInput, regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/,
        message: "Firstname should only contain letters and spaces, and be at least 2 characters long.",
        validationDiv: document.getElementById("firstname"),
        validationSpan: document.getElementById("spanErrorFirstName")
    },
    {
        input: lastNameInput, regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/,
        message: "Lastname should only contain letters and spaces, and be at least 2 characters long.",
        validationDiv: document.getElementById("lastname"),
        validationSpan: document.getElementById("spanErrorLastName")
    },
    {
        input: emailInput, regex: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,}(?:[^\W_]|-)*$/,
        message: "Please enter a valid email address.",
        validationDiv: document.getElementById("email"),
        validationSpan: document.getElementById("spanErrorEmail")
    },
    {
        input: passwordInput, regex: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[{\]}\\|;:'",<.>/?]).{8,}$/,
        message: "Password needs to have at least 1 capitalized character, a number and a special character, 8 characters long. ",
        validationDiv: document.getElementById("password"),
        validationSpan: document.getElementById("spanErrorPassword")
    },
    {
        input: passwordConfirmInput, regex: /^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=[{\]}\\|;:'",<.>/?]).{8,}$/,
        message: "Password needs to have at least 1 capitalized character, a number and a special character, 8 characters long. ",
        validationDiv: document.getElementById("confirmPassword"),
        validationSpan: document.getElementById("spanErrorConfirmPassword")
    },
    {
        input: messageInput, regex: /^.{10,}$/,
        message: "Message should be at least 10 characters long.",
        validationDiv: document.getElementById("message"),
        validationSpan: document.getElementById("spanErrorMessage")
    },
    {
        input: streetNameInput, regex: /^\S.*\s\d+[a-zA-Z]?$/,
        message: "Streetname must be at least 2 characters long.",
        validationDiv: document.getElementById("street"),
        validationSpan: document.getElementById("spanErrorStreetName")
    },
    {
        input: cityInput, regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/,
        message: "City should only contain letters and spaces, and be at least 2 characters long.",
        validationDiv: document.getElementById("city"),
        validationSpan: document.getElementById("spanErrorCity")
    },
    {
        input: postalcodeInput, regex: /^\d{5}(?:[-\s]\d{4})?$|^[A-Z]{1,2}\d{1,2}\s?\d{1,2}[A-Z]{0,2}$/,
        message: "Postalcode with numbers only",
        validationDiv: document.getElementById("postalcode"),
        validationSpan: document.getElementById("spanErrorPostalcode")
    },
];

validations.forEach(validation => {
    try {
        validation.input.addEventListener("input", () => {
            if (validation.regex.test(validation.input.value)) {
                validation.validationSpan.textContent = "";
                validation.validationDiv.className = "success";
                submitBtn.disabled = false;
            } else {
                submitBtn.disabled = true;
                validation.validationSpan.textContent = validation.message;
                validation.validationDiv.className = "invalid";
            }
        });
    } catch { }

});

try {
    formElement.addEventListener("submit", (event) => {
        let isFormValid = true;
        validations.forEach(validation => {
            if (!validation.regex.test(validation.input.value)) {
                validation.validationSpan.textContent = validation.message;
                validation.validationDiv.class = "invalid";
                isFormValid = false;
                
            }
        });
        if (!isFormValid) {
            event.preventDefault();
        }
    });
} catch { }




















