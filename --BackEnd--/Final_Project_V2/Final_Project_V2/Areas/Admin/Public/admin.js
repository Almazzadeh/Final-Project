var email = document.querySelector('#email');
var password = document.querySelector('#password');
var icon = document.querySelector('i');


email.addEventListener('change', function(){
    label(email);
})

password.addEventListener('change', function(){
    label(password);
})


function label(x){
    if(x.value){
        x.style.borderBottomColor = "#08c";
        x.nextElementSibling.style.top = "-9px";
        x.nextElementSibling.style.fontSize = "12px";
        x.nextElementSibling.style.color = "#08c";
        x.nextElementSibling.style.zIndex = "1";
    }
    else{
        x.style.borderBottomColor = "lightgray";
        x.nextElementSibling.style.top = "5px";
        x.nextElementSibling.style.fontSize = "16px";
        x.nextElementSibling.style.color = "gray";
        x.nextElementSibling.style.zIndex = "-1";
    }
}

icon.addEventListener('click', function(){
    if (password.type === "password") {
        icon.className = "fas fa-eye";
        password.type = "text";
    } else {
        icon.className = "fas fa-eye-slash";
        password.type = "password";
    }
})

function passwordVisibility(x) {
    
}

