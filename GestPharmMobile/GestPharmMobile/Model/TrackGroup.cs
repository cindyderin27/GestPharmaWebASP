using System;
using System.Collections.Generic;
using System.Text;

namespace GestPharmMobile.Model
{
    class TrackGroup : List<Track>
    {
        public string Date { get; private set; }

        public TrackGroup(string date, List<Track> tracks) : base(tracks)
        {
            Date = date;
        }
        public override string ToString()
        {
            return Date;
        }
    }
}
