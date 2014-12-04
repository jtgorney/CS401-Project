<?php

require_once("BankingConnection.php");

$connection = new BankingConnection("97.84.176.46", 8080);

// Always set the info before calling a method.
// Account Number: 1, Pin Number: 123
$connection->setBankingInformation(intval($_POST["acctNum"]), intval($_POST["pin"]));

// Check for a server connection
// This checks if the server is online.
if (! $connection->isServerOnline())
{
   echo "UNAVAILABLE";
   exit;
}
   
// Check the validity of an account
if (! $connection->isValidAccount())
{
   echo "INVALID";
   exit;
}  

echo "SUCCESS";

?>