namespace tracagamesApi.users.models
{
    //internal class WaitingUser : User
    internal class WaitingUser
    {
        private int _id;
        private User _user;
        private string _gameName;
        private DateTime _fecha;
        private bool _introducedNick;

        internal WaitingUser()
        {
            this._user = new User();
        }

        /*     public WaitingUser(string userName, string email, string gameName, DateTime fecha, bool introducedNick) : base(userName, "", email, true)
             {
                 this._gameName = gameName;
                 this._fecha = fecha;
                 this._introducedNick = introducedNick;
             } */


        /*  public WaitingUser(string userName, string email, string gameName, DateTime fecha, bool introducedNick) 
          {
              this.user = new User() { userName = userName, email = email, isLogged = true };
              this._gameName = gameName;
              this._fecha = fecha;
              this._introducedNick = introducedNick;
          } */

        public User user {
            get { return _user; }
            set { _user = value; }
        }

        public int Id {
            get { return _id; }
            set { this._id = value; }
        }

        public string gameName { 
            get { return _gameName; }
            set { this._gameName = value;  }
        }

        public DateTime fecha { 
            get { return _fecha;  }
            set { this._fecha = value; }         
        }
        public bool introducedNick { 
            get { return _introducedNick;  }
            set { _introducedNick = value; }
        }
    }
}
