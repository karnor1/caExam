using CaExam.Models;
using System.Text.RegularExpressions;

namespace CaExam.Helpers
{

    public enum eInputTypes
    {
        PhoneNumber,
        PersonalId,
        Email,
        Name,
        Surname,
        GeneralString,
        GeneralNumber,
        NotNullorEmpty,
        Username,
        Password,
        Address

    }

    public class InputValidator
    {
        static public string IsInputValid (IFormFile img)
        {
            if (img == null || img.Length == 0)
                return ("No file uploaded.");

            if (!img.ContentType.StartsWith("image/"))
                return ("The uploaded file is not a valid image.");

            var extension = Path.GetExtension(img.FileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(extension) || !Shared.PermittedFileExtensions.permittedImageExtensions.Contains(extension))
                return ($"Invalid image file extension, you can only upload {string.Join(", ", Shared.PermittedFileExtensions.permittedImageExtensions)}");
            return null;
        }

        static public string IsInputValid(eInputTypes validator, object data)
        {
            if (data == null)
            {
                return "Provided data is null";
            }


            switch (validator)
            {
                case eInputTypes.PhoneNumber:
                    if (data is string _data)
                    {
                        if (_data.Length >= 13 && _data[0] == '+')
                        {
                            var numberPart = _data.Substring(1);

                            if (numberPart.Length == 12 && numberPart.All(char.IsDigit))
                            {
                                break;
                            }
                            return "Phone number must be 12 digits long after the '+' sign.";
                        }
                        return "Phone number must start with a '+' and be at least 13 characters long.";
                    }
                    return "Data provided is invalid.";


                case eInputTypes.PersonalId:
                    if (data is string id)
                    {
                        if (id.Length == 11 && id.All(char.IsDigit))
                        {
                            if (id[0] >= '1' && id[0] <= '6')
                            {
                                break;
                            }
                            return "Personal ID must start with a digit between 1 and 6.";
                        }
                        return "Personal ID must be exactly 11 digits long.";
                    }
                    return "Data provided is invalid.";

                case eInputTypes.Name:
                    if (data is string Name)
                    {
                        if ( Name.All(char.IsLetter) && !String.IsNullOrWhiteSpace(Name))
                        {
                            break;
                        }
                        return "Sorry, your name includes forbidden chars";
                    }
                    return "Data provided is invalid.";

                case eInputTypes.Surname:
                    if (data is string Surname)
                    {
                        if (Surname.All(char.IsLetter) && !String.IsNullOrWhiteSpace(Surname))
                        {
                            break;
                        }
                        return "Sorry, your Surname includes forbidden chars";
                    }
                    return "Data provided is invalid.";

                case eInputTypes.Email:
                    if (data is string Email &&  !String.IsNullOrWhiteSpace(Email))
                    {
                        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                        if (Regex.IsMatch(Email, emailPattern))
                        {
                            break;
                        }
                        return "Sorry, the Email you provided seems incorrect it must be like example@example.domain";
                    }
                    return "Data provided is invalid.";

                case eInputTypes.GeneralString:
                    if (data is string stringData)
                    {
                        if(!String.IsNullOrWhiteSpace(stringData))
                        {
                            if (stringData.All(char.IsLetter))
                            {
                                break;

                            } return ("This whole input must be only letters");
                        } return ("Data must be not empty");
                    }
                    return "Data provided is invalid.";

                case eInputTypes.Address:
                    if (data is string str)
                    {
                        if (str.Trim() != str)
                        {
                            return "String must not have spaces at the beginning or end.";
                        }

                        var spaceCount = str.Count(c => c == ' ');
                        if (spaceCount > 1)
                        {
                            return "String can contain at most one space in the middle.";
                        }

                        var cleanedStr = str.Replace(" ", "");
                        if (!cleanedStr.All(char.IsLetterOrDigit))
                        {
                            return "String can only contain letters, digits, and at most one space.";
                        }

                        break;
                    }
                    return "Data provided is invalid.";
                case eInputTypes.GeneralNumber:
                    if (data is string Number)
                    {
                        if (!String.IsNullOrWhiteSpace(Number))
                        {
                            if (Number.All(char.IsDigit))
                            {
                                break;

                            } return ("Sorry input must contain only digits");
                        }
                        return ("Data must be not empty");
                    }
                    return "Data provided is invalid.";

                case eInputTypes.NotNullorEmpty:
                    if (data is string notNull)
                    {
                        if (!String.IsNullOrWhiteSpace(notNull))
                        {
                            break;
                        }
                        return ("Data must be not empty");
                    }
                    return "Data provided is invalid.";


                default:

                    break;
            }

            return null;
        }
    }
}
