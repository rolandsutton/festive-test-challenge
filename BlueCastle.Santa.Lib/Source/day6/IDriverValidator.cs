namespace BlueCastle.Santa.Lib.Source.day6;

public interface IDriverValidator
{
    bool IsValid(Func<bool> sleighValidation );
}