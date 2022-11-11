using System.ComponentModel.DataAnnotations;
namespace tracagamesApi.users.models
{
    public class User
    {
        private int _id;
        private string _userName;
        private string _password;        
        private string _email;
        private bool _isLogged;

        public User() {
            
        }

        public User(string userName, string password, string email, bool isLogged = false)
        {           
            this.set(userName, password, email, isLogged);
        }

        public int Id {
            get { return this._id; }
            set { this._id = value;}
        }
        public string userName {
            get { return _userName; }            
            set { this._userName = value; }
        }        

        public string password {
            get { return _password; }
            set { this._password = value; }
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool isLogged {
            get { return _isLogged; }
            set { _isLogged = value; }
        }

        internal void setLogged()
        {
            this._isLogged = true;
        }

        internal void setLogout()
        {
            this._isLogged = false;
        }

        internal void set(string userName, string password, string email, bool isLogged)
        {
            this._userName = userName;
            this._password = password;
            this._isLogged = isLogged;
            this._email = email;
        }

        internal application.dtos.User cloneToDto()
        {
            return new application.dtos.User() { email = this._email, logged = this._isLogged, userName = this._userName };
        }
    }
}