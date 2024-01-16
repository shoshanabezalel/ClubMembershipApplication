using ClubMembershipApplication.Data;
using ClubMembershipApplication.FiledValidators;
using ClubMembershipApplication.Models;
using static ClubMembershipApplication.CommonOutputFormat;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IView // from the spaces between {UserLoginView : IView} - you can be sure it's my code... (I'm obsessed with spaces)
    {
        ILogin _loginUser = null;
        public IFieldValidator FieldValidator => null;

        public UserLoginView(ILogin login)
        {
            _loginUser = login;
        }
        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            CommonOutputText.WriteLoginHeading();

            Console.WriteLine("Please enter your email address: ");

            string emailAddress = Console.ReadLine();

            Console.WriteLine("Please enter your password: ");

            string password = Console.ReadLine();

            User user = _loginUser.Login(emailAddress, password);

            if (user != null )
            {
                //ToDo: Run Welcome View
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFrontColor(FontTheme.Danger);
                Console.WriteLine("The credentails that you entered do not match our records.");
                CommonOutputFormat.ChangeFrontColor(FontTheme.Default);
            }
        }
    }
}
