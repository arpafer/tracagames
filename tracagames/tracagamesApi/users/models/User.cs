namespace tracagamesApi.users.models
{
    internal class User
    {
        private string userName;
        private string password;
        private string email;
        private bool isLogged;

        internal User(string userName, string password, string email, bool isLogged = false)
        {
            this.set(userName, password, email, isLogged);
        }

        internal void setLogged()
        {
            this.isLogged = true;
        }

        internal void setLogout()
        {
            this.isLogged = false;
        }

        internal void set(string userName, string password, string email, bool isLogged)
        {
            this.userName = userName;
            this.password = password;
            this.isLogged = isLogged;
            this.email = email;
        }

        internal application.dtos.User cloneToDto()
        {
            return new application.dtos.User() { email = this.email, logged = this.isLogged, userName = this.userName };
        }
    }
}