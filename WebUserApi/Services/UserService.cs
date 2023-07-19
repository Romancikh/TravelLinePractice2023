using AutoMapper;
using WebUserApi.Entities;
using WebUserApi.Helpers;
using WebUserApi.Models.Users;

namespace WebUserApi.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById( int id );
        void Create( CreateRequest model );
        void Update( int id, UpdateRequest model );
        void Delete( int id );
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserService( DataContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById( int id )
        {
            return GetUser( id );
        }

        public void Create( CreateRequest model )
        {
            if ( _context.Users.Any( x => x.Email == model.Email ) )
                throw new AppException( "User with the email '" + model.Email + "' already exists" );

            var user = _mapper.Map<User>( model );

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword( model.Password );

            _context.Users.Add( user );
            _context.SaveChanges();
        }

        public void Update( int id, UpdateRequest model )
        {
            var user = GetUser( id );

            if ( model.Email != user.Email && _context.Users.Any( x => x.Email == model.Email ) )
                throw new AppException( "User with the email '" + model.Email + "' already exists" );

            if ( !string.IsNullOrEmpty( model.Password ) )
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword( model.Password );

            _mapper.Map( model, user );
            _context.Users.Update( user );
            _context.SaveChanges();
        }

        public void Delete( int id )
        {
            var user = GetUser( id );
            _context.Users.Remove( user );
            _context.SaveChanges();
        }

        private User GetUser( int id )
        {
            var user = _context.Users.Find( id );
            return user ?? throw new KeyNotFoundException( "User not found" );
        }
    }
}
