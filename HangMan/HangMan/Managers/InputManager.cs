using System.Text.RegularExpressions;

namespace HangMan
{
    class InputManager
    {
        const string pattern = "^[a-zA-Z]{1}.*";

        public void Init()
        {
            throw new System.NotImplementedException();
        }

        public string ReadInput(string input)
        {
            if (ValidateInput(input))
            { 
                return input[0].ToString();
            }
            else
                return null;
        }

        private bool ValidateInput(string input)
        {
            if (Regex.IsMatch(input, pattern))
                return true;
            else
                return false;
        }

    }
}
