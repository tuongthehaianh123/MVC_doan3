


 /* function hienthi(p)
  {
      
      for(x in p)
      {
          document.writeln(p[x]);
          document.writeln("<hr>");
          
      }
  }
  var p={name="le thanh ngoc",age="hy"};
  hienthi();
  alert(p); 
  */

 var occar=document.getElementById("giohang");
 occar.click=giohang_click;
 function giohang_click(){
     alert('aa');
     var oqlgiohang=document.getElementById("modelgiohang");
     oqlgiohang.style.display="Block";
 }

 