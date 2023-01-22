using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using System;

namespace Shop.Domain.SiteEntities
{
    public class ContactUs : BaseEntity
    {
        private ContactUs()
        {

        }

        public string FullName { get; set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Title { get; private set; }
        public string MessageBody { get; private set; }
        public string? Answer { get; set; }
        public DateTime AnswerDate { get; set; }

        public ContactUs(string fullName, string email, string phoneNumber, string title, string messageBody)
        {
            Guard(fullName, email, phoneNumber, title, messageBody);
            Email = email;
            PhoneNumber = phoneNumber;
            Title = title;
            MessageBody = messageBody;
            FullName = fullName;
        }

        public void SetAnswer(string answer)
        {
            NullOrEmptyDomainDataException.CheckString(answer, nameof(answer));


            Answer = answer;
            AnswerDate = DateTime.Now;
        }
        private void Guard(string fullName, string email, string phoneNumber, string title, string messageBody)
        {
            NullOrEmptyDomainDataException.CheckString(fullName, nameof(fullName));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(messageBody, nameof(messageBody));

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمیل نامعتبر است");

            if (phoneNumber.IsValidPhoneNumber() == false)
                throw new InvalidDomainDataException("شماره تلفن نامعتبر است");

        }

    }
}
