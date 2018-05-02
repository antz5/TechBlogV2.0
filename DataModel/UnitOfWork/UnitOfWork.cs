using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;

namespace DataModel.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private BlogTechnicallyEntities _context = null;
        private GenericRepository.GenericRepository<BlogTechnically_Post> _postRepository;
        private GenericRepository.GenericRepository<BlogTechnically_User> _userRepository;
        private GenericRepository.GenericRepository<BlogTechnically_Token> _tokenRepository;
        private GenericRepository.GenericRepository<BlogTechnically_Category> _categoryRepository;
        private GenericRepository.GenericRepository<BlogTechnically_Comment> _commentRepository;
        private GenericRepository.GenericRepository<BlogTechnically_Permission> _permissionRepository;
        private GenericRepository.GenericRepository<BlogTechnically_Profile> _profileRepository;
        private GenericRepository.GenericRepository<BlogTechnically_Role> _roleRepository;

        public UnitOfWork()
        {
            _context = new BlogTechnicallyEntities();
        }

        public GenericRepository.GenericRepository<BlogTechnically_Post> PostRepository
        {
           get
            {
                if (this._postRepository == null)
                    this._postRepository = new GenericRepository.GenericRepository<BlogTechnically_Post>(_context);
                return _postRepository;
            }

        }

        public GenericRepository.GenericRepository<BlogTechnically_User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository.GenericRepository<BlogTechnically_User>(_context);
                return _userRepository;
            }

        }

        public GenericRepository.GenericRepository<BlogTechnically_Category> CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                    this._categoryRepository = new GenericRepository.GenericRepository<BlogTechnically_Category>(_context);

                return _categoryRepository;
            }
        }

        public GenericRepository.GenericRepository<BlogTechnically_Comment> CommentRepository
        {
            get
            {
                if (this._commentRepository == null)
                    this._commentRepository = new GenericRepository.GenericRepository<BlogTechnically_Comment>(_context);

                return _commentRepository;
            }
        }

        public GenericRepository.GenericRepository<BlogTechnically_Permission> PermissionRepository
        {
            get
            {
                if (this._permissionRepository == null)
                    this._permissionRepository = new GenericRepository.GenericRepository<BlogTechnically_Permission>(_context);

                return _permissionRepository;
            }
        }

        public GenericRepository.GenericRepository<BlogTechnically_Profile> ProfileRepository
        {
            get
            {
                if (this._profileRepository == null)
                    this._profileRepository = new GenericRepository.GenericRepository<BlogTechnically_Profile>(_context);

                return _profileRepository;
            }
        }

        public GenericRepository.GenericRepository<BlogTechnically_Role> RoleRepository
        {
            get
            {
                if (this._roleRepository == null)
                    this._roleRepository = new GenericRepository.GenericRepository<BlogTechnically_Role>(_context);
                return _roleRepository;
            }
        }

        public GenericRepository.GenericRepository<BlogTechnically_Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new GenericRepository.GenericRepository<BlogTechnically_Token>(_context);
                return _tokenRepository;
            }
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var output = new List<string>();
                foreach (var error in ex.EntityValidationErrors)
                {
                    output.Add(string.Format("{0}:Entity of type\"{1}\" in state \"{2}\" has the following validation errors: " + DateTime.Now, error.Entry.State));
                    foreach (var ve in error.ValidationErrors)
                    {
                        output.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                    File.AppendAllLines(System.Environment.CurrentDirectory + "\\error.txt", output);
                    throw ex;
                }              
            }
        }

        bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
