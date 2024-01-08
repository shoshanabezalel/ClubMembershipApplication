using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FiledValidators
{
    public delegate bool FieldValidatorDel(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage);
    public interface IFieldValidators
    {
        void InitialiseValidatorDelegates();
        string[] FieldArray {  get; }
        FieldValidatorDel ValidatorDel { get; }
    }
}
