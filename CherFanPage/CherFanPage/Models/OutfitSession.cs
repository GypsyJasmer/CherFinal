using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace CherFanPage.Models
{
    public class OutfitSession
    {
        private const string OutfitKey = "myoutfits";
        private const string CountKey = "outfitcount";
        private const string OutfitYearKey = "conf";


        private ISession session { get; set; }
        public OutfitSession(ISession session) {
            this.session = session;
        }

        public void SetMyOutfits(List<Outfit> outfits) {
            session.SetObject(OutfitKey, outfits);
            session.SetInt32(CountKey, outfits.Count);
        }
        public List<Outfit> GetMyOutfits() =>
            session.GetObject<List<Outfit>>(OutfitKey) ?? new List<Outfit>();
        public int? GetMyOutfitsCount() => session.GetInt32(CountKey);

        public void SetActiveOutfitYear(string conference) =>
            session.SetString(OutfitYearKey, conference);
        public string GetActiveOutfitYear() => session.GetString(OutfitYearKey);



        public void RemoveMyOutfits() {
            session.Remove(OutfitKey);
            session.Remove(CountKey);
        }
    }
}
