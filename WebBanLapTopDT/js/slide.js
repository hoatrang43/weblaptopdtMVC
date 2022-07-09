var i=5;
var N=9;

function Next(){
	if(i<N)
	{
		i +=1;
		
	}
	else
	{
		i=5;	
	}
	document.getElementById("slide").setAttribute("src",'./image/'+i+".jpg")
}
function Back(){
	if(i>1)
		i -=1;
	else
	{
		i=N;
		
	}
	document.getElementById("slide").setAttribute('src','./image/'+i+'.jpg')
}
function Image(){
	setInterval(Next,3000);//tự động chạy
}

function plusAmount(a){
	//document.getElementById();
	var x = document.getElementById(a).value;
	document.getElementById(a).value=Number(x)+1;
}

function subAmount(a){
	//document.getElementById();
	var x = document.getElementById(a).value;
	if(Number(x)>1)
		document.getElementById(a).value=Number(x)-1;
}