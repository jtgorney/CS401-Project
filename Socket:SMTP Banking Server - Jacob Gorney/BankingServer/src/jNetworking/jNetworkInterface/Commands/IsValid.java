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

import java.net.Socket;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * jNetworkInterfaceServer Command object template.
 */
public class IsValid implements Command {

    private int accountNum;
    private int pin;

    @Override
    public void setup(ArrayList<String> input, Socket client) {
        // Do nothing for this command
        // Store the URL
        accountNum = Integer.parseInt(input.get(0));
        pin = Integer.parseInt(input.get(1));
    }

    @Override
    public String run() {
        // Get the DB connection
        Connection dbc = DBConnection.getConnection();
        Statement stmt = null;
        String response = "FALSE";
        String query = "SELECT COUNT(*) as c FROM `account` WHERE `account_num` = " + accountNum + " AND `pin` = " +
                pin + ";";
        try {
            stmt = dbc.createStatement();
            ResultSet res = stmt.executeQuery(query);
            res.next();
            if (res.getInt("c") == 1)
                response = "TRUE";
            else
                response = "FALSE";
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return response;
    }
}