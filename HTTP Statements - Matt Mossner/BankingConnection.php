<?php

/**
* Banking Connector class for socket server connections.
*/
class BankingConnection {
   
   private $accountNumber, $pinNumber;
   private $adapter;

   // Server constructor
   public function __construct($hostname, $port) {
      $this->adapter = new ServerAdapter($hostname, $port);
      $this->accountNumber = -1;
      $this->pinNumber = -1;
   }

   // Check for server online status.
   public function isServerOnline() {
      return $this->adapter->isConnected();
   }

   // Set the initial banking information.
   public function setBankingInformation($accountNum, $pin) {
      $this->accountNumber = $accountNum;
      $this->pinNumber = $pin;
   }

   // Check if the account provided is valid.
   public function isValidAccount() {
      $dataSend = array($this->accountNumber, $this->pinNumber);
      $data = $this->adapter->sendCommand("isvalid", $dataSend);
      return (trim($data) == "TRUE");
   }

   // Get the shares and balances for an account.
   public function getShares() {
      $dataSend = array($this->accountNumber, $this->pinNumber);
      $returnData = array();
      $data = $this->adapter->sendCommand("getshares", $dataSend);
      $lines = explode("#", $data);
      foreach ($lines as $line) {
         $lineData = explode(",", $line);
         array_push($returnData, array($lineData[0], $lineData[1], $lineData[2] ));
      }
      return $returnData;
   }

   // Withdraw funds from an account.
   public function withdraw($amount, $shareNum) {
      $dataSend = array($this->accountNumber, $this->pinNumber, $amount, intval($shareNum));
      $returnData = array();
      $data = $this->adapter->sendCommand("withdraw", $dataSend);
      return (trim($data) == "TRUE");
   }

   // Deposit funds to an account.
   public function deposit($amount, $shareNum) {
      $dataSend = array($this->accountNumber, $this->pinNumber, $amount, intval($shareNum));
      $returnData = array();
      $data = $this->adapter->sendCommand("deposit", $dataSend);
      return (trim($data) == "TRUE");
   }

   // Get the transaction history for a share as a list.
   public function getTransactionHistory($shareNum) {
      $dataSend = array($this->accountNumber, $this->pinNumber, intval($shareNum));
      $data = $this->adapter->sendCommand("history", $dataSend);
      return explode("#", $data);
   }

   // Get the account information for an account number.
   public function getAccountInformation() {
      $returnData = array();
      $dataSend = array($this->accountNumber, $this->pinNumber);
      $data = $this->adapter->sendCommand("getinfo", $dataSend);
      $lines = explode("#", $data);
      if (count($lines) >= 1)
         $returnData["name"] = $lines[0];
      if (count($lines) >= 2)
         $returnData["address"] = $lines[1];
      if (count($lines) >= 3)
         $returnData["phone"] = $lines[2];
      if (count($lines) >= 4)
         $returnData["email"] = $lines[3];
      return $returnData;
   }
}

/**
 * Server adapter class for jNetworkInterfaceServer.
 */
class ServerAdapter {

   private $hostname;
   private $port;
   private $isConnected = false;
   private $clientSocket;

   // Build member data.
   public function __construct($hostname, $port) {
      $this->hostname = $hostname;
      $this->port = $port;
   }

   // Connection status for the socket.
   public function isConnected() {
      $this->connect();
      return $this->isConnected;
   }

   // Send a command to the socket server.
   public function sendCommand($command, $data) {
      $this->connect();
      if ($this->isConnected) {
         fwrite($this->clientSocket, $command.PHP_EOL);
      if (!empty($data))
         foreach ($data as $dataItem)
            fwrite($this->clientSocket, $dataItem.PHP_EOL);
         fwrite($this->clientSocket, "END COMMAND".PHP_EOL);
         $return = stream_get_contents($this->clientSocket);
         $this->closeConnection();
         return $return;
      } else
         return "INVALID CONNECTION";
   }

   // Make a connection to the socket server.
   private function connect() {
      if (!$this->isConnected) {
         $this->clientSocket = @stream_socket_client("tcp://".$this->hostname.":".$this->port, $errno, $msg, 5);
      }
      if ($this->clientSocket === false)
         $this->isConnected = false;
      else
         $this->isConnected = true;
   }

   // Close the socket connections and update the flag.
   private function closeConnection() {
      if ($this->isConnected)
         fclose($this->clientSocket);
      $this->isConnected = false;
   }
}
