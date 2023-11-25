const rootEl = document.getElementById("root");

gotoHome();

function gotoLogin(){
    rootEl.innerHTML = `
    <div class="d-flex justify-content-center align-items-center" style="height: 60vh;">
            <div class=" col-lg-5 col-12">                
                <div class="card">
                    <div class="card-header text-center">
                        <h1>Login Page</h1>
                        <p>Giriş yapmak için bilgilerinizi giriniz.</p>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="userNameOrEmail">
                                Kullanıcı adı yada Email
                            </label>
                            <input type="text" class="form-control" placeholder="johndoe" id="userNameOrEmail" onkeyup="checkValidation(event)" required minlength="3">
                            <div class="invalid-feedback"></div>
                        </div>
                        <div class="form-group">
                            <label for="password">
                                Parola
                            </label>
                            <input type="password" class="form-control" placeholder="******" id="password" onkeyup="checkValidationForPassword(event)" required minlength="6">
                            <ul style="display: none;">
                                <li class="text-danger" id="minSixLength">
                                    6 karakter uzunluğunda olmalıdır.
                                </li>
                                <li class="text-danger" id="upperCase">
                                    Büyük harf içermelidir.
                                </li>
                                <li class="text-danger" id="lowerCase">
                                    Küçük harf içermelidir.
                                </li>
                                <li class="text-danger" id="number">
                                   Rakam içermelidir.
                                </li>
                                <li class="text-danger" id="customCharacter">
                                    Özel karakter içermelidir.
                                </li>
                            </ul>
                        </div>
                        <div class="form-group mt-2">
                            <button class="btn btn-dark w-100 mb-1" onclick="login()">
                                Login
                            </button>
                            <p class="fw-bold">
                                Henüz Kayıtlı degil misin?
                            </p>
                            <a href="" class="fw-bold" onclick="gotoRegister()" style="float: right; margin-top: -40px;">
                                Kayıt Ol
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>    
    `;
}

function gotoRegister(){
    rootEl.innerHTML = `
    <div class="d-flex justify-content-center align-items-center" style="height: 60vh;">
            <div class=" col-lg-5 col-12">                
                <div class="card">
                    <div class="card-header text-center">
                        <h1>Register Page</h1>
                        <p>Kayıt olmak için bilgilerinizi giriniz.</p>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="name">
                                İsim
                            </label>
                            <input type="text" class="form-control" placeholder="john" id="name" onkeyup="checkValidation(event)" required minlength="3">
                            <div class="invalid-feedback"></div>
                        </div>
                        <div class="form-group">
                            <label for="lastName">
                                Soyisim
                            </label>
                            <input type="text" class="form-control" placeholder="doe" id="lastName" onkeyup="checkValidation(event)" required minlength="3">
                            <div class="invalid-feedback"></div>
                        </div>
                        <div class="form-group">
                            <label for="userName">
                                UserName
                            </label>
                            <input type="text" class="form-control" placeholder="johndoe" id="userName" onkeyup="checkValidation(event)" required minlength="4">
                            <div class="invalid-feedback"></div>
                        </div>
                        <div class="form-group">
                            <label for="email">
                                Email
                            </label>
                            <input type="email" class="form-control" placeholder="john@doe.com" id="email" onkeyup="checkValidation(event)" required minlength="3">
                            <div class="invalid-feedback"></div>
                        </div>
                        <div class="form-group">
                            <label for="password">
                                Parola
                            </label>
                            <input type="password" class="form-control" placeholder="******" id="password" onkeyup="checkValidationForPassword(event)" required minlength="6">
                            <ul style="display: none;">
                                <li class="text-danger" id="minSixLength">
                                    6 karakter uzunluğunda olmalıdır.
                                </li>
                                <li class="text-danger" id="upperCase">
                                    Büyük harf içermelidir.
                                </li>
                                <li class="text-danger" id="lowerCase">
                                    Küçük harf içermelidir.
                                </li>
                                <li class="text-danger" id="number">
                                   Rakam içermelidir.
                                </li>
                                <li class="text-danger" id="customCharacter">
                                    Özel karakter içermelidir.
                                </li>
                            </ul>
                        </div>
                        <div class="form-group mt-2">
                            <button class="btn btn-dark w-100 mb-1" onclick="register()">
                                Register
                            </button>
                            <p class="fw-bold">
                                Kayıtlı mısın?
                            </p>
                            <a href="" class="fw-bold" onclick="gotoLogin()" style="float: right; margin-top: -40px;">
                                Giriş Yap
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>  
    `;
}

function gotoTicketDetail(){
    rootEl.innerHTML = "<h1>Ticket Detail Page</h1>";
}

function gotoHome(){
    rootEl.innerHTML = "<h1>Home Page</h1>";
}

function checkValidation(e){
    const isValid = e.target.validity.valid;
    if(!isValid){
        e.target.className = "form-control is-invalid";
        const errorMessage = e.target.validationMessage;

        const divEl = document.querySelector("#" + e.target.id + " + div");
        divEl.innerHTML = errorMessage;
    }
    else{
        e.target.className = "form-control is-valid";
    }
}

function checkValidationForPassword(e) {
    e.target.className = "form-control is-invalid";
    checkPasswordControl(e.target.value);
}

function checkPasswordControl(value){
    const ulEl = document.querySelector("#password + ul");
    ulEl.style.display = "block";

    const validation = {
        minSixLenght: false,
        upperCase: false,
        lowerCase: false,
        number: false,
        customCharacter: false
    }

    const minSixLenghtLiEl = document.getElementById("minSixLength");
    const upperCaseLiEl = document.getElementById("upperCase");
    const lowerCaseLiEl = document.getElementById("lowerCase");
    const numberLiEl = document.getElementById("number");
    const customCharacterLiEl = document.getElementById("customCharacter");
    
    minSixLenghtLiEl.className = isTrueReturnSuccesOrDanger(value.length >= 6);
    upperCaseLiEl.className = isTrueReturnSuccesOrDanger(/[A-Z]/.test(value));
    lowerCaseLiEl.className = isTrueReturnSuccesOrDanger(/[a-z]/.test(value));
    numberLiEl.className = isTrueReturnSuccesOrDanger(/[0-9]/.test(value));
    customCharacterLiEl.className = isTrueReturnSuccesOrDanger(/[^\w\s]/.test(value));

    validation.minSixLenght = value.length >= 6;
    validation.upperCase = /[A-Z]/.test(value);
    validation.lowerCase = /[a-z]/.test(value);
    validation.number = /[0-9]/.test(value);
    validation.customCharacter = /[^\w\s]/.test(value);

    for(let i in validation){
        if(!validation[i])return;
    }

    ulEl.style.display = "none";
    document.getElementById("password").className = "form-control is-valid";
}

function isTrueReturnSuccesOrDanger(expression){
    if (expression) return "text-success";

    return "text-danger";
}

function home(){
    if(!login){
        gotoLogin();
    }
    else{
        gotoHome();
    }
}

function login(){
    const userNameOrEmailEl = document.getElementById("userNameOrEmail");
    const userNameOrEmailIsValid = userNameOrEmail.validity.valid;

    const passwordEl = document.getElementById("password");
    const passwordIsValid = passwordEl.validity.valid;

    if (!userNameOrEmailIsValid) {
        userNameOrEmailEl.className = "form-control is-invalid";
        document.querySelector(`#userNameOrEmail + div`).innerHTML = userNameOrEmailEl.validationMessage;
    }

    if (!passwordIsValid) {
        passwordEl.className = "form-control is-invalid";
        checkPasswordControl(passwordEl.value);
    }

    if (userNameOrEmailIsValid && passwordIsValid) {
        //
    }
}

function register(){
    const nameEl = document.getElementById("name");
    const nameIsValid = nameEl.validity.valid;

    const lastNameEl = document.getElementById("lastName");
    const lastNameIsValid = lastNameEl.validity.valid;

    const userNameEl = document.getElementById("userName");
    const userNameIsValid = userNameEl.validity.valid;

    const emailEl = document.getElementById("email");
    const emailIsValid = emailEl.validity.valid;

    const passwordEl = document.getElementById("password");
    const passwordIsValid = passwordEl.validity.valid;

    if (!nameIsValid) {
        nameEl.className = "form-control is-invalid";
        document.querySelector(`#name + div`).innerHTML = nameEl.validationMessage;
    }

    if (!lastNameIsValid) {
        lastNameEl.className = "form-control is-invalid";
        document.querySelector(`#lastName + div`).innerHTML = lastNameEl.validationMessage;
    }

    if (!userNameIsValid) {
        userNameEl.className = "form-control is-invalid";
        document.querySelector(`#userName + div`).innerHTML = userNameEl.validationMessage;
    }

    if (!emailIsValid) {
        emailEl.className = "form-control is-invalid";
        document.querySelector(`#email + div`).innerHTML = emailEl.validationMessage;
    }


    if (!passwordIsValid) {
        passwordEl.className = "form-control is-invalid";
        checkValidationForPassword2(passwordEl.value);
    }

    if (nameIsValid && passwordIsValid && userNameIsValid && emailIsValid && lastNameIsValid) {
        const data = {
            name: nameEl.value,
            lastName: lastNameEl.value,
            username: userNameEl.value,
            email: emailEl.value,
            password: passwordEl.value
        }

        axios.post("https://localhost:7079/api/Auth/Register", data).then(res => {
            const Toast = Swal.mixin({
                toast: true,
                position: "bottom-end",
                showConfirmButton: false,
                timer: 3000,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.onmouseenter = Swal.stopTimer;
                    toast.onmouseleave = Swal.resumeTimer;
                }
            });
            Toast.fire({
                icon: "success",
                title: "Kayıt işlemi başarıyla tamamlandı. Giriş yapabilirsiniz!"
            });
            gotoLogin();
        });
    }
}