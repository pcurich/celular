using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Celulares.Models.Seguridad
{
    public class ContextMemberShipProvider : MembershipProvider
    {
        public override string ApplicationName
        {
            get
            {
                return "Celulares";
            }
            set
            {
                this.ApplicationName = value;
            }
        }

        
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                DBContext db = new DBContext();
                Usuario usuario = db.T_Usuario.Where(u => u.Nombre == username && u.Contrasena == oldPassword).FirstOrDefault();
                if (usuario == null)
                {
                    return false;
                }
                else
                {
                    usuario.Contrasena = newPassword;
                    db.T_Usuario.Alter(usuario);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, MembershipCreateStatus status)
        {
            DBContext db = new DBContext();
            Usuario usuario = new Usuario();
            usuario.Nombre = username;
            usuario.Contrasena = password;
            usuario.Email = email;
            usuario.Pregunta = passwordQuestion;
            usuario.Respuesta = passwordAnswer;
            status = MembershipCreateStatus.Success;
            db.T_Usuario.Add(usuario);
            return null;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            return this.CreateUser(username,  password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey,out status);
        }


        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            DBContext Db = new DBContext();
            Usuario usuario=Db.T_Usuario.One(u => u.Email == email);
            if(usuario==null)
                return "";
            else
                return usuario.Nombre;
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Usuario user)
        {
            DBContext db = new DBContext();
            db.T_Usuario.Alter(user);
        }

        public override bool ValidateUser(string username, string password)
        {
            DBContext db = new DBContext();
            return db.T_Usuario.Any(u => u.Nombre == username && u.Contrasena == password);
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}