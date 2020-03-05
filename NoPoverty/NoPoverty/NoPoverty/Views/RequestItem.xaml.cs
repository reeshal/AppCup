using NoPoverty.Models;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoPoverty.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class RequestItem : ContentPage
    {
        Donor current;
        public RequestItem(Donor d)
        {
            InitializeComponent();
            current = d;
            PhoneNumber.Text = current.PhoneNo;
            Email.Text = current.Email;
        }
        
        private void BtnCall_Click(object sender, EventArgs e)
        {
            var PhoneCallTask = CrossMessaging.Current.PhoneDialer;
            if (PhoneCallTask.CanMakePhoneCall)
                PhoneCallTask.MakePhoneCall(PhoneNumber.Text);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {

            var SmsTask = CrossMessaging.Current.SmsMessenger;

            if (SmsTask.CanSendSms)
                SmsTask.SendSms("57263859", SMSBody.Text);
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            var EmailTask = CrossMessaging.Current.EmailMessenger;
            string EmailSubject = "Request For Item";
            if (Subject.Text != null)
                EmailSubject = Subject.Text;

            if (EmailTask.CanSendEmail)
                EmailTask.SendEmail("sendto@gmail.com", EmailSubject, Body.Text);
        }
    }
}