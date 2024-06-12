namespace CommunityRegistry.Authentication
{
    public delegate bool FieldValidator(int fieldIndex, string field, string[] fieldArray, out string fieldInvalidMessage);
    public interface IFieldValidator
    {
        void InitializeValidatorDelegates();
        string[] FieldArray { get; }
        FieldValidator Validator { get; }

    }
}
