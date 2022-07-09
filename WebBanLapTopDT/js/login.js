var USER = 'admin';
var PASS ='12345';

var USER1 = 'hoangngoc';
var PASS1 ='123';

var inputusername = document.getElementById('username');
var inputpassword = document.getElementById('password');

var formloign = document.getElementById('form-loign');

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
        formloign.action = "QuanTri.html"
    }
    else if(username==USER1 && password==PASS1){
        formloign.action = "laptop.html"
    }
    else{
        alert('Dang nhap that bai')
    }
}