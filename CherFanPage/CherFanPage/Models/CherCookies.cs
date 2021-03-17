using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CherFanPage.Models
{
    public class CherCookies
    {
        private const string OutfitKey = "myOutfits";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }
        public CherCookies(IRequestCookieCollection cookies) {
            requestCookies = cookies;
        }
        public CherCookies(IResponseCookies cookies) {
            responseCookies = cookies;
        }

        public void SetMyOutfitIds(List<Outfit> myOutfits)
        {
            List<string> ids = myOutfits.Select(t => t.OutfitID).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            RemoveMyOutfitIds();     // delete old cookie first
            responseCookies.Append(OutfitKey, idsString, options);
        }

        public string[] GetMyOutfitIds()
        {
            string cookie = requestCookies[OutfitKey];
            if (string.IsNullOrEmpty(cookie))
                return new string[] { };   // empty string array
            else
                return cookie.Split(Delimiter);
        }      

        public void RemoveMyOutfitIds()
        {
            responseCookies.Delete(OutfitKey);
        }
    }
}
