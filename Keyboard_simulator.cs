using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExam
{
    [AddINotifyPropertyChangedInterface]
    internal class Keyboard_simulator 
    {
        public string Text = "Harry Potter and the Half-Blood Prince is the sixth book in J.K. Rowling's iconic Harry Potter series. In this installment, Harry returns to Hogwarts School of Witchcraft and Wizardry for his sixth year of magical education. However, the atmosphere at Hogwarts is tense as the wizarding world faces increasing threats from the dark wizard Voldemort and his followers, the Death Eaters.";
        public string currentText {  get; set; }
        public string History {  get; set; }
        public string Now { get; set; }
        public string Next { get; set; }
        public int Fale { get; set; }

        public Keyboard_simulator() 
        {
            Fale = 0;
        }

        public void StartValue()
        {
            History = "";
            Now = Text[0].ToString();
            currentText = Text.Substring(1);
            Next = currentText;
        }

        public void ChangeText()
        {
            History += Now;
            Now = currentText[0].ToString();
            currentText = currentText.Substring(1);
            Next = currentText;
        }
    }
}
