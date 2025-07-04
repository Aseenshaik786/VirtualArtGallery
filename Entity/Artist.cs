﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Entity
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Website { get; set; }
        public string ContactInfo { get; set; }

        public Artist() { }

        public Artist(int artistID, string name, string biography, string birthDate, string nationality, string website, string contactInfo)
        {
            ArtistID = artistID;
            Name = name;
            Biography = biography;
            BirthDate = birthDate;
            Nationality = nationality;
            Website = website;
            ContactInfo = contactInfo;
        }
    }
}
