using tracagamesApi.users.models;

namespace tracagamesApi.users.application.mappers
{
    internal class MappingFromDtoToModel : MapperBase<dtos.WaitingUser, models.WaitingUser>
    {
        public models.WaitingUser map(dtos.WaitingUser model)
        {
            models.WaitingUser wu = new models.WaitingUser();
            wu.user.userName = model.userName;
            wu.user.email = model.email;
            wu.user.isLogged = model.logged;
            wu.user.password = model.password;
            wu.gameName = model.gameName;
            wu.fecha = model.fecha;
            wu.introducedNick = model.introducedNick;            
            return wu;
        }
    }
}