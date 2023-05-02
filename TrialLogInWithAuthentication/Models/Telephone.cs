namespace TrialLogInWithAuthentication.Models
{
    public class Telephone
    {
        public string Vendor {get;set;}
        public string Model { get;set;}

        public Telephone(string vendor , string model)
        {
            Vendor = vendor;
            Model = model;
        }
    }
}
