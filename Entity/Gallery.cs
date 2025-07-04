﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Entity
{
    public class Gallery
    {
        public int GalleryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int CuratorID { get; set; }
        public string OpeningHours { get; set; }

        public Gallery() { }

        public Gallery(int galleryID, string name, string description, string location, int curatorID, string openingHours)
        {
            GalleryID = galleryID;
            Name = name;
            Description = description;
            Location = location;
            CuratorID = curatorID;
            OpeningHours = openingHours;
        }
    }
}
