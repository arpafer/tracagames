namespace tracagamesApi.users.application.mappers
{
    internal interface MapperBase <T1, T2>
    {
        T2 map(T1 t1);
    }
}
