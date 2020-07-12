using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculWPFMVVM.Model;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace CalculWPFMVVM.VM
{

    public class CalculatorVM : INotifyPropertyChanged
    {
        /// <summary>
        /// ViewModel
        /// Класс для создания связи между Model и View.
        /// </summary>
       
        public CalculatorModel selectedCalculator;
        public ObservableCollection<CalculatorModel> calculators;

        /// <summary>
        /// Конструктор класса VM, который создает 5 элементов класса Model, с задаными названиями формул
        /// </summary>
        public CalculatorVM()
        {
            calculators = new ObservableCollection<CalculatorModel>()
            {
                new CalculatorModel("Линейная"),
                new CalculatorModel("Квадратичная"),
                new CalculatorModel("Кубическая"),
                new CalculatorModel("4-ой степени"),
                new CalculatorModel("5-ой степени")
            };
        }
        /// <summary>
        /// Свойство класса VM которое возвращает или изменяет выбранную формулу.
        /// </summary>
        public CalculatorModel SelectedCalculator
        {
            get
            {
                return this.selectedCalculator;
            }
            set
            {
                this.selectedCalculator = value;
                OnPropertyChanged("SelectedCalculator");
            }
        }
        public ObservableCollection<CalculatorModel> Calculators
        {
            get
            {
                return this.calculators;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    
}
