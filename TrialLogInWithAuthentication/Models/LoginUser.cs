namespace TrialLogInWithAuthentication.Models
{
    public class LoginUser : User
    {
        public bool ShowError { get; set; }

        public LoginUser(bool showError)
        {
            ShowError = showError;
        }
    }
}
