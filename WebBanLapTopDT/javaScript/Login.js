var USER = 'admin';
var PASS ='12345';

var USER1 = 'hoatrang';
var PASS1 ='123';

var inputusername = document.getElementById('username');
var inputpassword = document.getElementById('password');

var formloign = document.getElementById('form-login');

if(formloign.attachEvent){
    formloign.attachEvent('submit',onFormSubmit);

}
else{
    formloign.addEventListener('submit', onFormSubmit);

}

function onFormSubmit(e){
    var username = inputusername.value;
    var password = inputpassword.value;

    if(username==USER && password==PASS){
        formloign.action = "Admin.html"
    }
    else if(username==USER1 && password==PASS1){
        formloign.action = "HomePage.html"
    }
    else{
        alert('Dang nhap that bai')
    }
}