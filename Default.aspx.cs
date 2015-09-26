using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage();
        MailAddress mailadd = new MailAddress("amitashukla0906@gmail.com","Amita Shukla");
        msg.From = mailadd;
        msg.To.Add(new MailAddress(TextBox1.Text));
        msg.Subject = TextBox2.Text;
        msg.Body = TextBox4.Text;
        if (FileUpload1.HasFile)
        {
            msg.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
        }
        
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        NetworkCredential nkc = new NetworkCredential("amitashukla0906@gmail.com", "*******");
        smtp.Credentials = nkc;
        smtp.EnableSsl = true;

        try
        {
            smtp.Send(msg);
            Label5.Text = "Email sent successfully";
        }
        catch(Exception ex)
        {
            Label5.Text = ex.Message;
        }
    }
}