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


/*const contactForm = document.getElementById("contactForm");*/
let formElement;
const nameInput = document.getElementById("name");
const emailInput = document.getElementById("email");
const messageInput = document.getElementById("message");
const contactBtn = document.getElementById("contactBtn");

const validations = [
    {
        input: nameInput, regex: /^[A-Za-zÀ-ÖØ-öø-ÿ]+([- ][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/,
        message: "Name should only contain letters and spaces, and be at least 2 characters long.",
        validationDiv: document.getElementById("name"),
        validationSpan: document.getElementById("spanErrorName")
    },
    {
        input: emailInput, regex: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+[a-zA-Z]{2,}(?:[^\W_]|-)*$/,
        message: "Please enter a valid email address.",
        validationDiv: document.getElementById("email"),
        validationSpan: document.getElementById("spanErrorEmail")
    },
    {
        input: messageInput, regex: /^.{10,}$/,
        message: "Message should be at least 10 characters long.",
        validationDiv: document.getElementById("message"),
        validationSpan: document.getElementById("spanErrorMessage")
    }
];

validations.forEach(validation => {
    try {
        validation.input.addEventListener("input", () => {
            if (validation.regex.test(validation.input.value)) {
                validation.validationSpan.textContent = "";
                validation.validationDiv.className = "success";
            } else {
                validation.validationSpan.textContent = validation.message;
                validation.validationDiv.className = "invalid";
            }
        });
    } catch { }

});

try {
    if (document.getElementById("contactForm")) {
        formElement = document.getElementById("contactForm");
        console.log(formElement)
    }
    else if (document.getElementById("loginForm")) {
        formElement = getElementById("loginForm")
        console.log(formElement);
    }

} catch { }

try {
    formElement.addEventListener("submit", (event) => {

            let isFormValid = true;
            validations.forEach(validation => {
                if (!validation.regex.test(validation.input.value)) {
                    validation.validationSpan.textContent = validation.message;
                    validation.validationDiv.className = "invalid";
                    isFormValid = false;

                }
            });
            if (!isFormValid) {
                event.preventDefault();
            }


    });
} catch { }


