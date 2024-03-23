

namespace Settings
{
    public class Settings
    {
        public bool Publicum { set; get;}
        public bool Voice { set; get;}
        public bool Pulse { set; get;}
        
        public Settings()
        {
            Publicum = true;
            Voice = true;
            Pulse = true;
        }
        
        
    }
}
