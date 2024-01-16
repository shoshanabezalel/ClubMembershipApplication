using ClubMembershipApplication.FiledValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    // Im here 😛
    public interface IView
    {
        void RunView();
        IFieldValidator FieldValidator { get; }
    }
}
