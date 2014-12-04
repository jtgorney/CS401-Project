/**
 The MIT License (MIT)

 Copyright (c) 2014 Jacob Gorney

 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in
 all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 THE SOFTWARE.
 */

package jNetworking.jNetworkInterface.Commands;

import db.DBConnection;
import jNetworking.jNetworkInterface.Command;
import smtp.Mailer;

import java.net.Socket;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * jNetworkInterfaceServer Command object template.
 */
public class Withdraw implements Command {

    private int accountNum;
    private int pin;
    private double amount;
    private int shareNum;

    @Override
    public void setup(ArrayList<String> input, Socket client) {
        // Do nothing for this command
        // Store the URL
        accountNum = Integer.parseInt(input.get(0));
        pin = Integer.parseInt(input.get(1));
        amount = Double.parseDouble(input.get(2));
        shareNum = Integer.parseInt(input.get(3));
    }

    @Override
    public String run() {
        // Get the DB connection
        Connection dbc = DBConnection.getConnection();
        Statement stmt = null;
        String response = "FALSE";
        String query = "UPDATE `shares` SET `balance` = `balance` - " + amount + " WHERE `account_num` = " + accountNum +
                " AND `share_id` = " + shareNum + ";";
        try {
            stmt = dbc.createStatement();
            stmt.execute(query);
            response = "TRUE";
            // Add transaction history
            String share = "SELECT `share_name`, `balance` FROM `shares` WHERE `share_id` = '" + shareNum
                    + "' AND `account_num` = '" + accountNum + "';";
            // Get share info
            stmt = dbc.createStatement();
            ResultSet res1 = stmt.executeQuery(share);
            res1.next();
            String shareName = res1.getString("share_name");
            double balance = res1.getDouble("balance") - amount;
            // Execute transaction entry
            String history = "INSERT INTO `transaction` (`share_id`, `account_num`, `amount`, `balance`, `description`)" +
                    " VALUES(" + shareNum + ", " + accountNum + ", " + amount + ", " + balance + ", '" +
                    "W - " + amount + " FROM " + shareName + "');";
            // Exec stmt
            stmt = dbc.createStatement();
            stmt.execute(history);
            // Send email
            String email = "SELECT `email` FROM `account` WHERE `account_num` = '" + accountNum + "' AND `pin` = '" +
                    pin + "' LIMIT 1;";
            stmt = dbc.createStatement();
            ResultSet res2 = stmt.executeQuery(email);
            if (res2.next()) {
                Mailer mailer = new Mailer(res2.getString("email"), "Dear Account Holder,<br /><br />" +
                        "We are sending you This email in regards to a recent transaction on your account. A withdraw of $ "
                        + amount + " has been made.<br /><br />Thank you,<br />CS401 Bank", "Withdraw on your account");
                mailer.sendEmail();
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return response;
    }
}