namespace BlueCastle.Santa.Lib.Source.day5;

public interface IDriverValidator
{
    bool TryIsValid(string driver, out IDriverInfo driverInfo);
}