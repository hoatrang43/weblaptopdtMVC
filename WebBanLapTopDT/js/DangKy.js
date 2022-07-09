
function validate() {
    var name = document.getElementById('name').value
    var birth = document.getElementById('birth').value
    var address = document.getElementById('address').value
    var phone = document.getElementById('phone').value
    var email = document.getElementById('email').value
    var validate = document.getElementById('validate').value

        if(name.length>50 || hasNumber(name)==true){
            if(document.getElementById('e1').classList.contains('visiable')){
                document.getElementById('e1').classList.remove('visiable')
            }
        }
        else{
            if(!document.getElementById('e1').classList.contains('visiable')){
                document.getElementById('e1').classList.add('visiable')
            }
        }
    
        if(checkdatetime(birth) == false){
            if(document.getElementById('e2').classList.contains('visiable')){
                document.getElementById('e2').classList.remove('visiable')
            }
        }
        else{
            if(!document.getElementById('e2').classList.contains('visiable')){
                document.getElementById('e2').classList.add('visiable')
            }
        }
    
    
        if(address.length>40){
            if(document.getElementById('e3').classList.contains('visiable')){
                document.getElementById('e3').classList.remove('visiable')
            }
        }
        else{
            if(!document.getElementById('e3').classList.contains('visiable')){
                document.getElementById('e3').classList.add('visiable')
            }
        }
    
        if(isNumeric(phone)==false){
            if(document.getElementById('e4').classList.contains('visiable')){
                document.getElementById('e4').classList.remove('visiable')
            }
        }
        else{
            if(!document.getElementById('e4').classList.contains('visiable')){
                document.getElementById('e4').classList.add('visiable')
            }
        }
        
        if(!email.includes('@') || !email.includes(".")){
            if(document.getElementById('e5').classList.contains('visiable')){
                document.getElementById('e5').classList.remove('visiable')
            }
        }
        else{
            if(!document.getElementById('e5').classList.contains('visiable')){
                document.getElementById('e5').classList.add('visiable')
            }
        }
    
        if(isNumeric(validate)==false){
            if(document.getElementById('e6').classList.contains('visiable')){
                document.getElementById('e6').classList.remove('visiable')
            }
        }
        else{
            if(!document.getElementById('e6').classList.contains('visiable')){
                document.getElementById('e6').classList.add('visiable')
            }
        }
   

}

function isNumeric(str) {
    if (typeof str != "string") return false
    return !isNaN(str) && !isNaN(parseFloat(str))
  }

function hasNumber(myString) {
    return /\d/.test(myString);
  }

function checkdatetime(input){
  var reg = /(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d/;
  if (input.match(reg)) 
    return true;
  else {
    return false;
  }
}