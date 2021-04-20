using GestPharmMobile.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestPharmMobile.ModelPages
{
    class TrackViewModel
    {
        public List<TrackGroup> Track { get; private set; } = new List<TrackGroup>();

        public TrackViewModel(bool emptyGroups = false)
        {
            // includeEmptyGroups = emptyGroups;
            CreateTrackCollection();
        }

        void CreateTrackCollection()
        {
            Track.Add(new TrackGroup("Sept 23, 2018", new List<Track>
            {
                new Track
                {
                    OrderId = "OD - 424923192 - N",
                    Price = "$4500",
                    Status = "Delivered",
                    NumberofItems = 5
                },

            }));

            Track.Add(new TrackGroup("Sept 23, 2018", new List<Track>
            {
                new Track
                {
                    OrderId = "OD - 424923192 - N",
                    Price = "$500",
                    Status = "Delivered",
                    NumberofItems = 5
                },
                new Track
                {
                    OrderId = "OD - 424923192 - N",
                    Price = "$700",
                    Status = "Delivered",
                    NumberofItems = 5
                }

            }));

            Track.Add(new TrackGroup("Sept 22, 2018", new List<Track>
            {
                new Track
                {
                    OrderId = "OD - 424923192 - N",
                    Price = "$1500",
                    Status = "Delivered",
                    NumberofItems = 5
                },
                new Track
                {
                    OrderId = "OD - 424923192 - N",
                    Price = "$2700",
                    Status = "Delivered",
                    NumberofItems = 5
                }

            }));
        }
    }
}
