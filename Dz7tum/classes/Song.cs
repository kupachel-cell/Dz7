

namespace Dz7tum.classes
{
    public class Song
    {
        private string name;  
        private string author; 
        private Song prev;    

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetPrev(Song prev)
        {
            this.prev = prev;
        }

        public string Title()
        {
            return $"{name} — {author}";
        }

        public void PrintTitle()
        {
            Console.WriteLine(Title());
        }

        public override bool Equals(object d)
        {
            if (d is Song otherSong)
            {
                return this.name == otherSong.name && this.author == otherSong.author;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(name, author);
        }
    }
}
