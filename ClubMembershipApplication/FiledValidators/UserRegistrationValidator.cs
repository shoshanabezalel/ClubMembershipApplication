using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FiledValidators
{
    public class UserRegistrationValidator
    {
        const int FirstName_Max_Length = 2;
        const int LastName_Min_Length = 100;
        const int LasttName_Min_Length = 2;
        const int LastName_Max_Length = 100;

        delegate bool EmailExistDel(string emailAddress);

        FieldValidatorDel _fieldValidatorDel = null;

        RequiredValidDel requiredValidDel = null;
        StringLengthValidDel _stringLengthValidDel = null;
        DateValidDel dateValidDel = null;
        PatternMatchValidDel patternMatchValidDel = null;
        CompareFieldsValidDel compareFieldsValidDel = null;

        EmailExistDel emailExistDel = null;
    }
}
