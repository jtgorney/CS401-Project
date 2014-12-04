package db;

import java.sql.Connection;
import java.sql.DriverManager;

/**
 * Database server connection.
 */
public class DBConnection {

    public static final String DB_NAME = "cs401_bank";
    public static final String DB_USERNAME = "cs401_bank";
    public static final String DB_PASSWORD = "PASSWORD";
    public static final String DB_HOST = "mysql.rentalsbyjb.com";
    private static Connection dbConnection;

    /**
     * Get the database connection.
     * @return Database connection
     */
    public static Connection getConnection() {
        try {
            if (dbConnection == null || !dbConnection.isValid(10) || dbConnection.isClosed()) {
                Class.forName("com.mysql.jdbc.Driver").newInstance();
                dbConnection = DriverManager.getConnection("jdbc:mysql://" + DB_HOST + "/" + DB_NAME + "?" +
                        "user=" + DB_USERNAME + "&password=" + DB_PASSWORD);
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        return dbConnection;
    }

    /**
     * Close the database connection.
     */
    public static void closeConnection() {
        try {
            dbConnection.close();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        dbConnection = null;
    }
}
