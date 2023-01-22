using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SiteEntities.ValueObjects
{
    public class SocialNetworks
    {
        public SocialNetworks()
        {

        }
        public SocialNetworks(string? instagram, string? linkeDin, string? faceBook, string? twitter, string? telegram)
        {
            Instagram = instagram;
            LinkeDin = linkeDin;
            FaceBook = faceBook;
            Twitter = twitter;
            Telegram = telegram;
        }
        public string? Instagram { get; private set; }
        public string? LinkeDin { get; private set; }
        public string? FaceBook { get; private set; }
        public string? Twitter { get; private set; }
        public string? Telegram { get; private set; }
    }
}
