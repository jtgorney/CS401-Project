<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<link rel="stylesheet" type="text/css" href="statement.css" />
</head>
<body>
   <h1>Bank Statement</h1>
<?php

require_once("BankingConnection.php");

$connection = new BankingConnection("97.84.176.46", 8080);

$connection->setBankingInformation(intval($_POST["acctNum"]), intval($_POST["pin"]));

// Write account information
$accountInfo = $connection->getAccountInformation();
echo "   <div>".PHP_EOL;
echo "      <p>".trim($accountInfo["name"])."</p>".PHP_EOL;
echo "      <p>".trim($accountInfo["address"])."</p>".PHP_EOL;
echo "      <p>".trim($accountInfo["phone"])."</p>".PHP_EOL;
echo "      <p>".trim($accountInfo["email"])."</p>".PHP_EOL;
echo "   </div>".PHP_EOL;

// Write information for each share
$shares = $connection->getShares();
foreach ($shares as $share)
{
   $shareId = $share[0];
   // Write share name
   echo "   <h2>".trim($share[2])."</h2>".PHP_EOL;
   echo "   <hr />".PHP_EOL;
   // Write share balance
   echo "   <p id=\"balance\">Balance: <span>$".trim($share[1])."</span></p>".PHP_EOL;
   // Write transaction history for the current share
   $transactions = $connection->getTransactionHistory($shareId);
   if (sizeof($transactions) > 0 && strcmp($transactions[0], "\r\n") != 0)
   {
      echo "   <h3>Transaction History</h3>".PHP_EOL;
      foreach ($transactions as $transaction)
         echo "      <p>".trim($transaction)."</p>".PHP_EOL;
   }
   echo "   <hr />".PHP_EOL;
}

?>