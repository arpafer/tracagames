namespace tracagamesApi.users.application.dtos
{
    public class WaitingRoom
    {
        public int Id { get; set; }
        public List<WaitingUser> waitingUser { get; set; }        
    }
}