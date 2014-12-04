// Coded by: Matt Mossner

var acctValid = true;
var pinValid = true;
var error = null;
var request;

//---------------------------------------------------------------------------------------------------
// Called when the "retrieve statement" button is clicked.  Performs basic data validation of account
// number and PIN.  If either or both are invalid, appropriate error messages and visual cues are
// displayed, and focus is returned to the first offending field.  Otherwise, login() is called.
//---------------------------------------------------------------------------------------------------
function onSubmit()
{
   var acctBox = document.getElementById("acctbox");
   var acctLabel = document.getElementById("acctlabel");
   var pinBox = document.getElementById("pinbox");
   var pinLabel = document.getElementById("pinlabel");
   var acctExp = /^[0-9]+$/;
   var pinExp = /^([0-9]{4})$/;
   var msg = "";
   if (! pinExp.test(pinBox.value))
   {
      pinLabel.className = "invalid";
      pinBox.className = "invalid";
      pinValid = false;
      pinBox.focus();
      msg = "<p>*PIN must be 4 digits.</p>";
   }
   else
   {
      pinValid = true;
      pinLabel.className = "valid";
      pinBox.className = "valid";
   }
   if (! acctExp.test(acctBox.value))
   {
      acctLabel.className = "invalid";
      acctBox.className = "invalid";
      acctValid = false;
      acctBox.focus();
      msg = "<p>*Account number must be an integer.</p>" + msg;
   }
   else
   {
      acctValid = true;
      acctLabel.className = "valid";
      acctBox.className = "valid";
   }
   if (error != null)
   {
      document.body.removeChild(error);
   }
   if (acctValid && pinValid)
   {
      login();  
   }
   else
   {
      error = document.createElement("div");
      error.id = "error";
      error.innerHTML = msg;
      document.body.appendChild(error);
   }
}

//---------------------------------------------------------------------------------------------------
// This function sends the account credentials to the server, which verifies the account credentials.
//---------------------------------------------------------------------------------------------------
function login()
{
   if (window.XMLHttpRequest)
   {// code for IE7+, Firefox, Chrome, Opera, Safari
      request = new XMLHttpRequest();
   }
   else
   {// code for IE6, IE5
      request = new ActiveXObject("Microsoft.XMLHTTP");
   }
   request.open("POST", "login.php", true);
   request.setRequestHeader("Content-type","application/x-www-form-urlencoded");
   request.onreadystatechange = function() {verifyLogin();};
   request.send("acctNum=" + acctbox.value + "&pin=" + pinbox.value);
}

//--------------------------------------------------------------------------------------------------
// This function is called when the request object's ready state changes.  If the server returns a
// response message of "SUCCESS", the login form is submitted.  Otherwise, either the banking server
// could not be found or the account credentials were invalid.
//--------------------------------------------------------------------------------------------------
function verifyLogin()
{
   if (request.readyState==4 && request.status==200)
   {
      response = request.responseText;
      if (response == "SUCCESS")
      {
         document.getElementById("login").submit();
      }
      else
      {
         var msg;
         if (response == "INVALID")
         {
            msg = "<p>*Incorrect account number or PIN.</p>";
         }
         else if (response == "UNAVAILABLE")
         {
            msg = "<p>*Server unavailable.</p>";
         }
         error = document.createElement("div");
         error.id = "error";
         error.innerHTML = msg;
         document.body.appendChild(error);
      }
   }
}