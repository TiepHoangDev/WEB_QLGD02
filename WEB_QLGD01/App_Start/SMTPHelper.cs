using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.UI.WebControls;
using WCF.BussinessObject.Objects;
using WCF.BussinessController.BCL;

namespace WEB_QLGD01.App_Start
{
    public class SMTPHelper
    {
        public bool sendMail(string content, string email, string MailBCC, string title)
        {
            var objEmail = new EmailBCL().GetEmail();
            SmtpClient smtp = new SmtpClient();
            try
            {
                smtp.Credentials = new NetworkCredential(objEmail.Email, objEmail.Password);
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress(objEmail.Email);
                message.To.Add(email);
                message.Bcc.Add(MailBCC);
                message.Subject = title;
                message.Body = content;
                message.IsBodyHtml = true;
                smtp.Send(message);

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public string EmailContentEmailPassword(string Email, string password, string company, string link)
        {
            string content = "<div id='m_-3994148579517751183mailsub'>" +
   "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
       "<tbody>" +
           "<tr>" +
               "<td style='background:#2fc7f7;padding:.75pt .75pt .75pt .75pt'>" +
                   "<div align='center'>" +
                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='700' style='width:525.0pt'>" +
                           "<tbody>" +
                               "<tr style='height:1.25in'>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;padding:0in 0in 0in 0in;height:1.25in'>" +
                                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
                                           "<tbody>" +
                                               "<tr>" +
                                                   "<td width='40%' style='width:40.0%;padding:.75pt .75pt .75pt .75pt'>" +
                                                       "<p class='MsoNormal'><a href='Hoidapit.vn' target='_blank' ><img border='0' id='m_-3994148579517751183_x0000_i1025' src='http://hoidapit.com.vn/Content/assets/images/logoc5e6.png' alt='hoidapit.vn' class='CToWUd'></span></a><u></u><u></u>" +
                                                       "</p>" +
                                                   "</td>" +
                                                   "<td width='60%' style='width:60.0%;padding:.75pt .75pt .75pt .75pt'>" +
                                                       "<p class='MsoNormal' align='right' style='text-align:right'><span style='font-size:24.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;color:white'>Tạo tài khoản thành công<u></u><u></u></span>" +
                                                       "</p>" +
                                                   "</td>" +
                                               "</tr>" +
                                           "</tbody>" +
                                       "</table>" +
                                   "</td>" +
                               "</tr>" +
                               "<tr style='height:6.0pt'>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='700' style='width:525.0pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                               "</tr>" +
                               "<tr>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;background:white;padding:0in 0in 0in 0in'>" +
                                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
                                           "<tbody>" +
                                               "<tr>" +
                                                   "<td style='padding:11.25pt 11.25pt 11.25pt 11.25pt'>" +
                                                       "<p class='MsoNormal' style='margin-bottom:12.0pt'><b><span style='font-size:16.5pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Xin chào bạn</span></b><span style='font-size:13.5pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;'> <br><br> chúng tôi đã tạo thành công tài khoản là: " + Email + " và mật khẩu là: " + password + "  cho công ty <strong> " + company + "</strong> của bạn trên cộng đồng <a href='http://hoidapit.vn'> hoidapit.vn </a>. Bạn có thể truy cập vào link sau để kích hoạt tài khoản:  <br><br><a href= '" + link + "' >" + link + " </a> <br><br>Cảm ở bạn đã sử dụng cộng đồng  <a href='hoidapit.vn' target='_blank'>hoidapit.vn</a> của chúng tôi <br><br><br>Hy vọng bạn có thể tìm được những ứng viên phù hợp với công việc của bạn<br><br><br>Thư này được tạo một cách tự động - vui lòng không trả lời thư này <br><br><br><br></span><span style='font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Hoidapit.vn </span><u></u><u></u>" +
                                                       "</p>" +
                                                   "</td>" +
                                               "</tr>" +
                                           "</tbody>" +
                                       "</table>" +
                                  " </td>" +
                               "</tr>" +
                               "<tr style='height:6.0pt'>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td style='background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                               "</tr>" +
                               "<tr style='height:15.0pt'>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;padding:0in 0in 0in 0in;height:15.0pt'></td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>" +
               "</td>" +
           "</tr>" +
           "<tr style='height:75.0pt'>" +
               "<td style='background:#f5f8f9;padding:.75pt .75pt .75pt .75pt;height:75.0pt'>" +
                   "<div align='center'>" +
                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0'>" +
                           "<tbody>" +
                               "<tr>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='https://www.facebook.com/imicrosoft.edu.vn' target='_blank'><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1026' src='https://ci3.googleusercontent.com/proxy/OMlJv7kc47O5awmGhQBKEBLNjKvb48MClBwjPJxYFiefHK0wG2HIdtJ0FObosxlwUMeF8DcrwZjczjet5qsD2-_WOCEURIreo6zAdNl5eVxkmA=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoFacebook.png' alt='Facebook' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1027' src='https://ci5.googleusercontent.com/proxy/8MnPtMf9sTTnePLZLix8dBuBoD6vpM-zUj28nFagHctVFrOS0DxeJ7GGDvCZQllNV6YoDs54100_Tkih_8btP8RWmp0ZifNN__rORIztSF25=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoTwitter.png' alt='Twitter' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1028' src='https://ci4.googleusercontent.com/proxy/8B4aGn_GSfIXDqNP2ZYoKFnMMeWW3tjTv6oUZDzLL3d5spIOsPIxFmEXVR9Xgp1FRRV8f6TcmczkIAwgHHO7evT_h9O9kG0W8Bb66jKsGdJeJQ=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoLinkedin.png' alt='LinkedIn' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1029' src='https://ci6.googleusercontent.com/proxy/DlZYFXrMUcaXFw_zFCidtogxVfacBguREStkApRyt4r_94BEturC_IXrDJrGoM504IYt4E4eEvhPg70EveSaSU1uWnRRHL5Anw5UB5YEkX4=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoGoogle.png' alt='Google+' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='https://www.youtube.com/channel/UCiKvIsKnKjftoChlVbdDVMA' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1030' src='https://ci3.googleusercontent.com/proxy/fL5vFH0WdszfhVqrty2NSN7-mhQ4qm73MkfHcV-eXwuGn9461h2WDXEj2_LLUKPZv5ahoBMrbFRnPVuIlG82yD_pJwE545ecxVx94zkbup8y=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoYoutube.png' alt='YouTube' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                               "</tr>" +
                               "<tr>" +
                                   "<td colspan='9' style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal' align='center' style='text-align:center'><span style='font-size:10.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Powered by <a href='http://hoidaptit.vn' target='_blank'><span style='color:#575757'>Hoidapit.vn</span><span style='font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;color:#575757'> </span>" +
                                           "</a>" +
                                           "</span><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>" +
               "</td>" +
           "</tr>" +
       "</tbody>" +
   "</table>" +
   "<p class='MsoNormal'><u></u>&nbsp;<u></u>" +
   "</p>" +
"</div>";
            return content;
        }

        public string EmailContentMessage(string Fullname, string title, string link)
        {

            string content = "<div id='m_-3994148579517751183mailsub'>" +
   "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
       "<tbody>" +
           "<tr>" +
               "<td style='background:#2fc7f7;padding:.75pt .75pt .75pt .75pt'>" +
                   "<div align='center'>" +
                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='700' style='width:525.0pt'>" +
                           "<tbody>" +
                               "<tr style='height:1.25in'>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;padding:0in 0in 0in 0in;height:1.25in'>" +
                                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
                                           "<tbody>" +
                                               "<tr>" +
                                                   "<td width='40%' style='width:40.0%;padding:.75pt .75pt .75pt .75pt'>" +
                                                       "<p class='MsoNormal'><a href='Hoidapit.vn' target='_blank' ><img border='0' id='m_-3994148579517751183_x0000_i1025' src='http://hoidapit.com.vn/Content/assets/images/logoc5e6.png' alt='hoidapit.vn' class='CToWUd'></span></a><u></u><u></u>" +
                                                       "</p>" +
                                                   "</td>" +
                                                   "<td width='60%' style='width:60.0%;padding:.75pt .75pt .75pt .75pt'>" +
                                                       "<p class='MsoNormal' align='right' style='text-align:right'><span style='font-size:24.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;color:white'>Câu trả lời mới<u></u><u></u></span>" +
                                                       "</p>" +
                                                   "</td>" +
                                               "</tr>" +
                                           "</tbody>" +
                                       "</table>" +
                                   "</td>" +
                               "</tr>" +
                               "<tr style='height:6.0pt'>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='700' style='width:525.0pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                               "</tr>" +
                               "<tr>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;background:white;padding:0in 0in 0in 0in'>" +
                                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
                                           "<tbody>" +
                                               "<tr>" +
                                                   "<td style='padding:11.25pt 11.25pt 11.25pt 11.25pt'>" +
                                                       "<p class='MsoNormal' style='margin-bottom:12.0pt'><b><span style='font-size:16.5pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Xin chào bạn</span></b><span style='font-size:13.5pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;'> <br><br>" + Fullname + " đã trả lời trong câu hỏi <a href=" + link + ">" + title + "</a> bạn có thể truy cập vào link sau để biết chi tiết <br><br><a href=" + link + " >" + link + "</a> <br><br>Cảm ở bạn đã sử dụng cộng đồng  <a href='hoidapit.vn' target='_blank'>hoidapit.vn</a> của chúng tôi <br><br><br>Hy vọng bạn có thể tìm được những câu hỏi phù hợp với câu hỏi của bạn<br><br><br>Thư này được tạo một cách tự động - vui lòng không trả lời thư này <br><br><br><br></span><span style='font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Hoidapit.vn </span><u></u><u></u>" +
                                                       "</p>" +
                                                   "</td>" +
                                               "</tr>" +
                                           "</tbody>" +
                                       "</table>" +
                                  " </td>" +
                               "</tr>" +
                               "<tr style='height:6.0pt'>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td style='background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                               "</tr>" +
                               "<tr style='height:15.0pt'>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;padding:0in 0in 0in 0in;height:15.0pt'></td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>" +
               "</td>" +
           "</tr>" +
           "<tr style='height:75.0pt'>" +
               "<td style='background:#f5f8f9;padding:.75pt .75pt .75pt .75pt;height:75.0pt'>" +
                   "<div align='center'>" +
                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0'>" +
                           "<tbody>" +
                               "<tr>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='https://www.facebook.com/imicrosoft.edu.vn' target='_blank'><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1026' src='https://ci3.googleusercontent.com/proxy/OMlJv7kc47O5awmGhQBKEBLNjKvb48MClBwjPJxYFiefHK0wG2HIdtJ0FObosxlwUMeF8DcrwZjczjet5qsD2-_WOCEURIreo6zAdNl5eVxkmA=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoFacebook.png' alt='Facebook' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1027' src='https://ci5.googleusercontent.com/proxy/8MnPtMf9sTTnePLZLix8dBuBoD6vpM-zUj28nFagHctVFrOS0DxeJ7GGDvCZQllNV6YoDs54100_Tkih_8btP8RWmp0ZifNN__rORIztSF25=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoTwitter.png' alt='Twitter' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1028' src='https://ci4.googleusercontent.com/proxy/8B4aGn_GSfIXDqNP2ZYoKFnMMeWW3tjTv6oUZDzLL3d5spIOsPIxFmEXVR9Xgp1FRRV8f6TcmczkIAwgHHO7evT_h9O9kG0W8Bb66jKsGdJeJQ=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoLinkedin.png' alt='LinkedIn' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1029' src='https://ci6.googleusercontent.com/proxy/DlZYFXrMUcaXFw_zFCidtogxVfacBguREStkApRyt4r_94BEturC_IXrDJrGoM504IYt4E4eEvhPg70EveSaSU1uWnRRHL5Anw5UB5YEkX4=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoGoogle.png' alt='Google+' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='https://www.youtube.com/channel/UCiKvIsKnKjftoChlVbdDVMA' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1030' src='https://ci3.googleusercontent.com/proxy/fL5vFH0WdszfhVqrty2NSN7-mhQ4qm73MkfHcV-eXwuGn9461h2WDXEj2_LLUKPZv5ahoBMrbFRnPVuIlG82yD_pJwE545ecxVx94zkbup8y=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoYoutube.png' alt='YouTube' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                               "</tr>" +
                               "<tr>" +
                                   "<td colspan='9' style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal' align='center' style='text-align:center'><span style='font-size:10.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Powered by <a href='http://hoidaptit.vn' target='_blank'><span style='color:#575757'>Hoidapit.vn</span><span style='font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;color:#575757'> </span>" +
                                           "</a>" +
                                           "</span><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>" +
               "</td>" +
           "</tr>" +
       "</tbody>" +
   "</table>" +
   "<p class='MsoNormal'><u></u>&nbsp;<u></u>" +
   "</p>" +
"</div>";
            return content;
        }

        public string EmailReplyApply(string Company, string link, string title, string full)
        {
            string content = "<div id='m_-3994148579517751183mailsub'>" +
   "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
       "<tbody>" +
           "<tr>" +
               "<td style='background:#2fc7f7;padding:.75pt .75pt .75pt .75pt'>" +
                   "<div align='center'>" +
                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='700' style='width:525.0pt'>" +
                           "<tbody>" +
                               "<tr style='height:1.25in'>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;padding:0in 0in 0in 0in;height:1.25in'>" +
                                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
                                           "<tbody>" +
                                               "<tr>" +
                                                   "<td width='40%' style='width:40.0%;padding:.75pt .75pt .75pt .75pt'>" +
                                                       "<p class='MsoNormal'><a href='Hoidapit.vn' target='_blank' ><img border='0' id='m_-3994148579517751183_x0000_i1025' src='http://hoidapit.com.vn/Content/assets/images/logoc5e6.png' alt='hoidapit.vn' class='CToWUd'></span></a><u></u><u></u>" +
                                                       "</p>" +
                                                   "</td>" +
                                                   "<td width='60%' style='width:60.0%;padding:.75pt .75pt .75pt .75pt'>" +
                                                       "<p class='MsoNormal' align='right' style='text-align:right'><span style='font-size:24.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;color:white'>Tin tuyển dụng mới<u></u><u></u></span>" +
                                                       "</p>" +
                                                   "</td>" +
                                               "</tr>" +
                                           "</tbody>" +
                                       "</table>" +
                                   "</td>" +
                               "</tr>" +
                               "<tr style='height:6.0pt'>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='700' style='width:525.0pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                               "</tr>" +
                               "<tr>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;background:white;padding:0in 0in 0in 0in'>" +
                                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
                                           "<tbody>" +
                                               "<tr>" +
                                                   "<td style='padding:11.25pt 11.25pt 11.25pt 11.25pt'>" +
                                                       "<p class='MsoNormal' style='margin-bottom:12.0pt'><b><span style='font-size:16.5pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Xin chào bạn : " + full + "</span></b><span style='font-size:13.5pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;'> <br><br>" + Company + " đã đăng một tin tuyển dụng mới <a href=" + link + ">" + title + "</a> Bạn có thể truy cập vào link sau để biết chi tiết <br><br><a href=" + link + " >" + link + "</a> <br><br>Cảm ở bạn đã sử dụng cộng đồng  <a href='hoidapit.vn' target='_blank'>hoidapit.vn</a> của chúng tôi <br><br><br>Hy vọng bạn có thể tìm được công việc phù hợp với bạn<br><br><br>Thư này được tạo một cách tự động - vui lòng không trả lời thư này <br><br><br><br></span><span style='font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Hoidapit.vn </span><u></u><u></u>" +
                                                       "</p>" +
                                                   "</td>" +
                                               "</tr>" +
                                           "</tbody>" +
                                       "</table>" +
                                  " </td>" +
                               "</tr>" +
                               "<tr style='height:6.0pt'>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td style='background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                               "</tr>" +
                               "<tr style='height:15.0pt'>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;padding:0in 0in 0in 0in;height:15.0pt'></td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>" +
               "</td>" +
           "</tr>" +
           "<tr style='height:75.0pt'>" +
               "<td style='background:#f5f8f9;padding:.75pt .75pt .75pt .75pt;height:75.0pt'>" +
                   "<div align='center'>" +
                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0'>" +
                           "<tbody>" +
                               "<tr>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='https://www.facebook.com/imicrosoft.edu.vn' target='_blank'><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1026' src='https://ci3.googleusercontent.com/proxy/OMlJv7kc47O5awmGhQBKEBLNjKvb48MClBwjPJxYFiefHK0wG2HIdtJ0FObosxlwUMeF8DcrwZjczjet5qsD2-_WOCEURIreo6zAdNl5eVxkmA=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoFacebook.png' alt='Facebook' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1027' src='https://ci5.googleusercontent.com/proxy/8MnPtMf9sTTnePLZLix8dBuBoD6vpM-zUj28nFagHctVFrOS0DxeJ7GGDvCZQllNV6YoDs54100_Tkih_8btP8RWmp0ZifNN__rORIztSF25=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoTwitter.png' alt='Twitter' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1028' src='https://ci4.googleusercontent.com/proxy/8B4aGn_GSfIXDqNP2ZYoKFnMMeWW3tjTv6oUZDzLL3d5spIOsPIxFmEXVR9Xgp1FRRV8f6TcmczkIAwgHHO7evT_h9O9kG0W8Bb66jKsGdJeJQ=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoLinkedin.png' alt='LinkedIn' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1029' src='https://ci6.googleusercontent.com/proxy/DlZYFXrMUcaXFw_zFCidtogxVfacBguREStkApRyt4r_94BEturC_IXrDJrGoM504IYt4E4eEvhPg70EveSaSU1uWnRRHL5Anw5UB5YEkX4=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoGoogle.png' alt='Google+' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='https://www.youtube.com/channel/UCiKvIsKnKjftoChlVbdDVMA' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1030' src='https://ci3.googleusercontent.com/proxy/fL5vFH0WdszfhVqrty2NSN7-mhQ4qm73MkfHcV-eXwuGn9461h2WDXEj2_LLUKPZv5ahoBMrbFRnPVuIlG82yD_pJwE545ecxVx94zkbup8y=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoYoutube.png' alt='YouTube' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                               "</tr>" +
                               "<tr>" +
                                   "<td colspan='9' style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal' align='center' style='text-align:center'><span style='font-size:10.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Powered by <a href='http://hoidaptit.vn' target='_blank'><span style='color:#575757'>Hoidapit.vn</span><span style='font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;color:#575757'> </span>" +
                                           "</a>" +
                                           "</span><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>" +
               "</td>" +
           "</tr>" +
       "</tbody>" +
   "</table>" +
   "<p class='MsoNormal'><u></u>&nbsp;<u></u>" +
   "</p>" +
"</div>";
            return content;
        }

        public string EmailMessage(string Company, string phone, string email)
        {

            string content = "<div id='m_-3994148579517751183mailsub'>" +
   "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
       "<tbody>" +
           "<tr>" +
               "<td style='background:#2fc7f7;padding:.75pt .75pt .75pt .75pt'>" +
                   "<div align='center'>" +
                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='700' style='width:525.0pt'>" +
                           "<tbody>" +
                               "<tr style='height:1.25in'>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;padding:0in 0in 0in 0in;height:1.25in'>" +
                                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
                                           "<tbody>" +
                                               "<tr>" +
                                                   "<td width='40%' style='width:40.0%;padding:.75pt .75pt .75pt .75pt'>" +
                                                       "<p class='MsoNormal'><a href='Hoidapit.vn' target='_blank' ><img border='0' id='m_-3994148579517751183_x0000_i1025' src='http://hoidapit.com.vn/Content/assets/images/logoc5e6.png' alt='hoidapit.vn' class='CToWUd'></span></a><u></u><u></u>" +
                                                       "</p>" +
                                                   "</td>" +
                                                   "<td width='60%' style='width:60.0%;padding:.75pt .75pt .75pt .75pt'>" +
                                                       "<p class='MsoNormal' align='right' style='text-align:right'><span style='font-size:24.0pt;font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;;color:white'>Thông tin đăng ký mới <u></u><u></u></span>" +
                                                       "</p>" +
                                                   "</td>" +
                                               "</tr>" +
                                           "</tbody>" +
                                       "</table>" +
                                   "</td>" +
                               "</tr>" +
                               "<tr style='height:6.0pt'>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='700' style='width:525.0pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                               "</tr>" +
                               "<tr>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;background:white;padding:0in 0in 0in 0in'>" +
                                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0' width='100%' style='width:100.0%'>" +
                                           "<tbody>" +
                                               "<tr>" +
                                                   "<td style='padding:11.25pt 11.25pt 11.25pt 11.25pt'>" +
                                                       "<p class='MsoNormal' style='margin-bottom:12.0pt'><b><span style='font-size:16.5pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Xin chào ban quản trị hoidapit.vn</span></b><span style='font-size:13.5pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;'> <br><br> Công ty " + Company + " đã đăng ký làm đối tác tuyển dụng trên cộng đồng <a href='http://hoidapit.vn'>Hoidapit.vn</a><br/><br/> Thông tin liên hệ: <br/><br/>Email: " + email + " <br/><br/> Điện thoại: " + phone + " <br/><br/>Bạn có thể truy cập vào link sau để biết chi tiết <br><br><a href='http://hoidapit.vn/editorpanel' >Đăng nhập hệ thống </a> <br><br>Cảm ở bạn đã sử dụng cộng đồng  <a href='hoidapit.vn' target='_blank'>hoidapit.vn</a> của chúng tôi <br><br><br>Hy vọng bạn có thể tìm được những câu hỏi phù hợp với câu hỏi của bạn<br><br><br>Thư này được tạo một cách tự động - vui lòng không trả lời thư này <br><br><br><br></span><span style='font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Hoidapit.vn </span><u></u><u></u>" +
                                                       "</p>" +
                                                   "</td>" +
                                               "</tr>" +
                                           "</tbody>" +
                                       "</table>" +
                                  " </td>" +
                               "</tr>" +
                               "<tr style='height:6.0pt'>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td style='background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                                   "<td width='6' style='width:4.5pt;background:white;padding:0in 0in 0in 0in;height:6.0pt'></td>" +
                               "</tr>" +
                               "<tr style='height:15.0pt'>" +
                                   "<td width='700' colspan='3' style='width:525.0pt;padding:0in 0in 0in 0in;height:15.0pt'></td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>" +
               "</td>" +
           "</tr>" +
           "<tr style='height:75.0pt'>" +
               "<td style='background:#f5f8f9;padding:.75pt .75pt .75pt .75pt;height:75.0pt'>" +
                   "<div align='center'>" +
                       "<table class='m_-3994148579517751183MsoNormalTable' border='0' cellpadding='0'>" +
                           "<tbody>" +
                               "<tr>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='https://www.facebook.com/imicrosoft.edu.vn' target='_blank'><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1026' src='https://ci3.googleusercontent.com/proxy/OMlJv7kc47O5awmGhQBKEBLNjKvb48MClBwjPJxYFiefHK0wG2HIdtJ0FObosxlwUMeF8DcrwZjczjet5qsD2-_WOCEURIreo6zAdNl5eVxkmA=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoFacebook.png' alt='Facebook' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1027' src='https://ci5.googleusercontent.com/proxy/8MnPtMf9sTTnePLZLix8dBuBoD6vpM-zUj28nFagHctVFrOS0DxeJ7GGDvCZQllNV6YoDs54100_Tkih_8btP8RWmp0ZifNN__rORIztSF25=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoTwitter.png' alt='Twitter' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1028' src='https://ci4.googleusercontent.com/proxy/8B4aGn_GSfIXDqNP2ZYoKFnMMeWW3tjTv6oUZDzLL3d5spIOsPIxFmEXVR9Xgp1FRRV8f6TcmczkIAwgHHO7evT_h9O9kG0W8Bb66jKsGdJeJQ=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoLinkedin.png' alt='LinkedIn' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='javascript:;' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1029' src='https://ci6.googleusercontent.com/proxy/DlZYFXrMUcaXFw_zFCidtogxVfacBguREStkApRyt4r_94BEturC_IXrDJrGoM504IYt4E4eEvhPg70EveSaSU1uWnRRHL5Anw5UB5YEkX4=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoGoogle.png' alt='Google+' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'></td>" +
                                   "<td style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal'><a href='https://www.youtube.com/channel/UCiKvIsKnKjftoChlVbdDVMA' target='_blank' ><span style='text-decoration:none'><img border='0' id='m_-3994148579517751183_x0000_i1030' src='https://ci3.googleusercontent.com/proxy/fL5vFH0WdszfhVqrty2NSN7-mhQ4qm73MkfHcV-eXwuGn9461h2WDXEj2_LLUKPZv5ahoBMrbFRnPVuIlG82yD_pJwE545ecxVx94zkbup8y=s0-d-e1-ft#http://bitrix24.com/bitrix/templates/b24/img/icoYoutube.png' alt='YouTube' class='CToWUd'></span></a><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                               "</tr>" +
                               "<tr>" +
                                   "<td colspan='9' style='padding:.75pt .75pt .75pt .75pt'>" +
                                       "<p class='MsoNormal' align='center' style='text-align:center'><span style='font-size:10.0pt;font-family:&quot;Calibri&quot;,&quot;sans-serif&quot;;color:#575757'>Powered by <a href='http://hoidaptit.vn' target='_blank'><span style='color:#575757'>Hoidapit.vn</span><span style='font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;color:#575757'> </span>" +
                                           "</a>" +
                                           "</span><u></u><u></u>" +
                                       "</p>" +
                                   "</td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>" +
               "</td>" +
           "</tr>" +
       "</tbody>" +
   "</table>" +
   "<p class='MsoNormal'><u></u>&nbsp;<u></u>" +
   "</p>" +
"</div>";
            return content;
        }
    }
}