using AutoMapper;
using WebUserApi.Entities;
using WebUserApi.Models.Users;

namespace WebUserApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateRequest, User>();

            CreateMap<UpdateRequest, User>()
                .ForAllMembers( x => x.Condition(
                    ( src, dest, prop ) =>
                    {
                        if ( prop == null ) return false;
                        if ( prop.GetType() == typeof( string ) && string.IsNullOrEmpty( (string)prop ) ) return false;

                        if ( x.DestinationMember.Name == "Role" && src.Role == null ) return false;

                        return true;
                    }
                ) );
        }
    }
}
