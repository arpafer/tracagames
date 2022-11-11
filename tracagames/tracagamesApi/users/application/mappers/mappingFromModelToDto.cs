using tracagamesApi.users.models;

namespace tracagamesApi.users.application.mappers
{
    internal class MappingFromModelToDto : MapperBase<models.WaitingUser, dtos.WaitingUser>
    {
        public dtos.WaitingUser map(models.WaitingUser model)
        {
            dtos.WaitingUser wu = new dtos.WaitingUser();
            wu.userName = model.user.userName;
            wu.email = model.user.email;
            wu.logged = model.user.isLogged;
            wu.password = model.user.password;
            wu.gameName = model.gameName;
            wu.fecha = model.fecha;
            wu.introducedNick = model.introducedNick;
            return wu;
        }
    }
}