using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TextBoxGenerator
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string inputText = string.Empty;
        private string outputText = string.Empty;

        private bool box = false;
        private bool diagonal = false;

        public string InputText
        {
            get { return inputText; }
            set
            {
                if (Equals(value, inputText)) return;
                inputText = value;
                UpdateOutputText(value.ToUpper());
                OnPropertyChanged();
            }
        }

        public string OutputText
        {
            get { return outputText; }
            set
            {
                if (Equals(value, outputText)) return;
                outputText = value;
                OnPropertyChanged();
            }
        }

        public bool Box
        {
            get { return box; }
            set
            {
                if (Equals(value, box)) return;
                box = value;
                OnPropertyChanged();
            }
        }

        public bool Diagonal
        {
            get { return diagonal; }
            set
            {
                if (Equals(value, diagonal)) return;
                diagonal = value;
                OnPropertyChanged();
            }
        }

        #region OutputText Update Methods

        // LINEOTEXT
        // I
        // N
        // E
        // O
        // T
        // E
        // X
        // T

        private void UpdateOutputText(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < input.Length; row++)
            {
                for (int column = 0; column < input.Length; column++)
                {
                    // If first row, always append, then continue
                    if (row == 0)
                    {
                        sb.Append(input[column]);
                        continue;
                    }
                    if (column == 0)
                    {
                        sb.Append(input[row]);
                        continue;
                    }

                    if (diagonal && (row == column))// || row + column == input.Length))
                    {
                        sb.Append(input[row]);
                        continue;
                    }

                    if (box && row == (input.Length - 1))
                    {
                        sb.Append(input[(input.Length - 1) - column]);
                        continue;
                    }

                    if (box && column == (input.Length - 1))
                    {
                        sb.Append(input[(input.Length - 1) - row]);
                        continue;
                    }

                    sb.Append(' ');
                }

                sb.AppendLine();
            }

            OutputText = sb.ToString();
        }

        #endregion

        #region Property Changed Event Handler

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
