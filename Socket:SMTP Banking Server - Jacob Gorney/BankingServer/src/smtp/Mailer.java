package smtp;

import javax.mail.*;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;
import java.util.Properties;

/**
 * Created by Jacob Gorney
 */
public class Mailer {
    /**
     * Recipient email address.
     */
    private String recipient;
    /**
     * Message to send.
     */
    private String message;
    /**
     * Subject of message.
     */
    private String subject;

    /**
     * Constructor for mailer.
     * @param to To email address
     * @param message Message
     * @param subject Subject of email
     */
    public Mailer(String to, String message, String subject) {
        this.recipient = to;
        this.message = message;
        this.subject = subject;
    }

    /**
     * Send the email to the banking customer.
     */
    public void sendEmail() {
        // Build connection details for Google SMTP. Similar to HA.
        Properties p = new Properties();

        // Build info
        p.put("mail.smtp.host", "smtp.live.com");
        p.put("mail.smtp.auth", "true");
        p.put("mail.smtp.port", 587);
        p.put("mail.smtp.starttls.enable", "true");

        // Create a session
        Session gmailSession = Session.getInstance(p, new Authenticator() {
            @Override
            protected PasswordAuthentication getPasswordAuthentication() {
                // Authenticate with GMail's server.
                return new PasswordAuthentication("jtgorney@live.com", "PASSWORD HERE");
            }
        });
        try {
            // Create transport and build the message.
            Transport trans = gmailSession.getTransport();
            MimeMessage m = new MimeMessage(gmailSession);
            // Message
            m.setSubject(subject);
            m.setFrom(new InternetAddress("jtgorney@live.com"));
            m.addRecipient(Message.RecipientType.TO, new InternetAddress(recipient));
            m.setContent(message, "text/html");
            // Establish MTA connection
            trans.connect();
            // Send the message.
            trans.sendMessage(m, m.getRecipients(Message.RecipientType.TO));
            // Close the connection
            trans.close();
        } catch (Exception ex) { ex.printStackTrace(); }
    }
}
