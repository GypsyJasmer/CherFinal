using System.Collections.Generic;

namespace CherFanPage.Models
{
    public class OutfitListViewModel : OutfitViewModel
    {
        public List<Outfit> Outfits{ get; set; }

        // use full properties for Conferences and Divisions 
        // so can add 'All' item at beginning
        private List<OutfitYear> outfitYears;

        public List<OutfitYear> OutfitYears
        {
            get => outfitYears; 
            set {
                outfitYears = new List<OutfitYear> {
                    new OutfitYear { OutfitYearID = "all", Decade = "All" }
                };
                outfitYears.AddRange(value);
            }
        }


        // methods to help view determine active link
        public string CheckActiveOutfitYear(string c) => 
            c.ToLower() == ActiveDecade.ToLower() ? "active" : "";

    }
}
