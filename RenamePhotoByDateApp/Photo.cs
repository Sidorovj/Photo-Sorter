using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamePhotoByDateApp
{
    class Photo : IComparable<Photo>
    {
        public string Path { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public Photo(string path, DateTime cr)
        {
            Path = path;
            CreatedOn = cr;
        }

        public int CompareTo(Photo other)
        {
            return this.CreatedOn < other.CreatedOn ? -1 : this.CreatedOn > other.CreatedOn ? 1 : 0;
        }
    }
}
