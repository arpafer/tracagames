namespace tracagamesApi.users.application.dtos
{
    public class WaitingUser: User
    {
        public string gameName { get; set; }
        public DateTime fecha { get; set; }
        public bool introducedNick { get; set; }
    }
}
