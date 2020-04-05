nusing System;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class SendMail : System.Web.UI.Page
{
    protected void btn_SendMessage_Click(object sender, EventArgs e)
    {
        SmtpClient smtpClient = new SmtpClient("domain.a2hosted.com", 25);

        smtpClient.Credentials = new System.Net.NetworkCredential("user@example.com", "password");
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

        MailMessage mailMessage = new MailMessage(txtFrom.Text, txtTo.Text);
        mailMessage.Subject = txtSubject.Text;
        mailMessage.Body = txtBody.Text;

        try
        {
            smtpClient.Send(mailMessage);
            Label1.Text = "Message sent";
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString();
        }
    }
}