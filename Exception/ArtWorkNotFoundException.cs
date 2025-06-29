using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualArtGallery.Exception
{
    public class ArtWorkNotFoundException : System.Exception
    {
        public ArtWorkNotFoundException(string message) : base(message) { }
    }
}
