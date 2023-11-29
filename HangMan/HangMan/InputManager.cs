using System.Text.RegularExpressions;

namespace UnityTraining_1
{
    class InputManager
    {
        const string pattern = "^[a-zA-Z]{1}.*";
        public char ReadInput(string input)
        {
            if (ValidateInput(input))
                return input[0];
            else
                return ' ';
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
