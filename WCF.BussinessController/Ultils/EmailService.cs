using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IMIC.CONTROLLERS.Ultils
{
    public class EmailService
    {
        public EmailService()
        {
        }

        public static EmailService Instance = new EmailService();

        /// <summary>
        /// Hàm gửi mail
        /// </summary>
        /// <param name="smtpUserName">Tên đăng nhập của smtp server. VD: mr.creditcard12@gmail.com</param>
        /// <param name="smtpPassword">Mật khẩu của email</param>
        /// <param name="smtpHost">smtp của Host. VD: smtp.gmail.com</param>
        /// <param name="smtpPort">port của server. VD: 25 - gmail</param>
        /// <param name="toEmail">Email của người nhận</param>
        /// <param name="subject">Chủ đề của Email</param>
        /// <param name="body">Nội dung của Email</param>
        /// <returns></returns>
        public bool Send(string smtpUserName, string smtpPassword, string smtpHost, int smtpPort,
            string toEmail, string subject, string body)
        {
            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.EnableSsl = true;// kiểu giao thức bảo mật Https
                    smtpClient.Host = smtpHost; // host
                    smtpClient.Port = smtpPort;//port
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(smtpUserName, smtpPassword);
                    var msg = new MailMessage
                    {
                        IsBodyHtml = true, // Cho phép nội dung là HTML
                        BodyEncoding = Encoding.UTF8,
                        From = new MailAddress(smtpUserName),
                        Subject = subject,
                        Body = body,
                        Priority = MailPriority.Normal,
                    };
                    msg.To.Add(toEmail);
                    smtpClient.Send(msg);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void SendWithInfo(string emailTo, string subject, string body)
        {
            // gửi mail
            string smtpUserName = "mr.creditcard12@gmail.com";
            string smtpPassword = "mvsnfxumwwblwfow";
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 25;
            EmailService service = new EmailService();
            service.Send(smtpUserName, smtpPassword, smtpHost, smtpPort, emailTo, subject, body);
        }

        public string MessageEmail(string username, string code)
        {
            string message = string.Format(@"<div>
                                                   <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#333333;font-size:20px;font-weight:400;text-transform:uppercase'>YÊU CẦU LẤY LẠI MẬT KHẨU</p>
                                                    <br>
                                             </div>
                                             <div>
                                                   <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#555;font-size:13px'>Chào&nbsp;<strong>{0}</strong>,<br>
                                                         <br>
                                                        <span>Bạn vừa thực hiện yêu cầu lấy lại mật khẩu trên hệ thống Quản Lý Công Nợ. Để hoàn tất việc khôi phục mật khẩu, vui lòng nhập chính xác Mã khôi phục dưới đấy vào trường CODE trên phần mềm quản lý:</span><br>
                                                        <span style='color:rgb(109, 74, 112); font-size:18px'><strong>{1}</strong></span>
                                                        <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#555;font-size:13px'>Nếu không phải bạn thực hiện, vui lòng&nbsp;<strong>Bỏ qua</strong>&nbsp;mail này.</p>
                                                        <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#555;font-size:13px'>Mọi thắc mắc xin vui lòng liên hệ website:<a target='_blank' href='http://www.imic.edu.vn/'>http://www.imic.edu.vn/</a>.</p>
                                                        <br>
                                                        <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#555;font-size:13px'>IMIC Team.</p>
                                                   </p>
                                             </div>", username, code);
            return message;
        }

        public string MessageNewPassword(string username, string newpassword)
        {
            string message = string.Format(@"<div>
                                                  <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#333333;font-size:20px;font-weight:400;text-transform:uppercase'>ĐẶT LẠI MẬT KHẨU</p>
                                                    <br>
                                             </div>
                                             <div>
                                                  <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#555;font-size:13px'>Chào&nbsp;<strong>{0}</strong>,<br>
                                                     <br>
                                                  <span>Bạn vừa thực hiện yêu cầu lấy lại mật khẩu trên hệ thống Quản Lý Công Nợ. Để đảm bảo tính bảo mật, hệ thống đã đặt lại mật khẩu mới cho tài khoản của bạn, như dưới đây:</span><br>
                                                  <span style='color:rgb(109, 74, 112); font-size:18px'><strong>{1}</strong></span>
                                                  <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#555;font-size:13px'>Bạn nên đổi lại mật khẩu sau khi đăng nhập thành công.</p>
                                                  <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#555;font-size:13px'>Mọi thắc mắc xin vui lòng liên hệ website:<a target='_blank' href='http://www.imic.edu.vn/'>http://www.imic.edu.vn/</a>.</p>
                                                      <br>
                                                  <p style='margin:0;font-family:Arial,Helvetica,sans-serif;color:#555;font-size:13px'>IMIC Team.</p>
                                                     </p>
                                            </div>", username, newpassword);
            return message;
        }
    }
}
