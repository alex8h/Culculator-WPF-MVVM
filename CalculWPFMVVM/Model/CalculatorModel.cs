using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CalculWPFMVVM.Model 
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Model
        /// Класс для хранения параметров;
        /// вычислений необходимых функций.
        /// </summary>
        private string formula;
        private int coeff_a;
        private int coeff_b;
        private int coeff_c;
        private int number_of_args;
        private int[] args_x;
        private int[] args_y;
        private int[] f_x_y;
        private int[] future_coeffs_c = new int[] { 1, 2, 3, 4, 5 };
        private int[] coeffs_c = new int[5];

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="f">Название формулы</param>
        public CalculatorModel(string f)
        {
            formula = f;
            coeff_a = 0;
            coeff_b = 0;
            coeff_c = 0;
            coeffs_c = Coeffs_c;
            number_of_args = 5;
            args_x = new int[number_of_args];
            args_y = new int[number_of_args];
            f_x_y = new int[number_of_args];
        }
        
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="n">Количество аргументов в массивах x,y и f(x,y)</param>
        public CalculatorModel(int n)
        {
            formula = "";
            coeff_a = 0;
            coeff_b = 0;
            coeff_c = 0;
            coeffs_c = Coeffs_c;
            number_of_args = n;
            args_x = new int[number_of_args];
            args_y = new int[number_of_args];
            f_x_y = new int[number_of_args];
        }
        /// <summary>
        /// Свойство, которое возвращает название формулы(string); 
        /// принимает тоже название формулы(string);
        /// извещает систему об изменении свойства.
        /// </summary>
        public string Formula
        {
            get
            {
                return this.formula;
            }
            set
            {
                this.formula = value;
                OnPropertyChanged("Formula");
                OnPropertyChanged("Coeff_a");
                OnPropertyChanged("Coeff_b");
                OnPropertyChanged("Coeff_c");
                OnPropertyChanged("Coeffs_c");
                OnPropertyChanged("Args_x");
                OnPropertyChanged("Args_y");
                OnPropertyChanged("F_x_y");
            }
        }
        /// <summary>
        /// Свойство, которое принимает и возвращает коеффициент а;
        /// извещает систему об изменении свойства.
        /// </summary>
        public int Coeff_a
        {
            get
            {
                return this.coeff_a;
            }
            set
            {
                this.coeff_a = value;
                OnPropertyChanged("Coeff_a");
                OnPropertyChanged("F_x_y");
            }
        }
        /// <summary>
        /// Свойство, которое принимает и возвращает коеффициент b;
        /// извещает систему об изменении свойства.
        /// </summary>
        public int Coeff_b
        {
            get
            {
                return this.coeff_b;
            }
            set
            {
                this.coeff_b = value;
                OnPropertyChanged("Coeff_b");
                OnPropertyChanged("F_x_y");
            }
        }
        /// <summary>
        /// Свойство, которое генерирует элементы Combobox и отправляет их в место вызова. 
        /// </summary>
        public int[] Coeffs_c
        {
            get
            {
                coeffs_c = Change_coeff_c(future_coeffs_c);
                return coeffs_c;
            }
        }
        /// <summary>
        /// Метод для генерации элементов Combobox, в зависимости от формулы.
        /// </summary>
        /// <param name="c">Название формулы</param>
        /// <returns></returns>
        public int[] Change_coeff_c(int[] c)
        {
            int f = 0;
            int[] result = new int[5];
            switch (Formula)
            {
                case "Линейная":
                    f = 1;
                    break;
                case "Квадратичная":
                    f = 2;
                    break;
                case "Кубическая":
                    f = 3;
                    break;
                case "4-ой степени":
                    f = 4;
                    break;
                case "5-ой степени":
                    f = 5;
                    break;
            }
            for (int i = 0; i < 5; i++)
            {
                result[i] = c[i] * (int)(System.Math.Pow(10, f - 1));
            }
            return result;
        }

        /// <summary>
        /// Свойство, которое принимает выбранный элемент в Combobox и возвращает коеффициент c;
        /// извещает систему об изменении свойства.
        /// </summary>
        public int Coeff_c
        {
            get
            {
                return this.coeff_c;
            }
            set
            {
                this.coeff_c = value;
                OnPropertyChanged("Coeff_c");
                OnPropertyChanged("F_x_y");
            }
        }
        /// <summary>
        /// СВойство, принимает и возвращает значение x,
        /// извещает систему об изменении свойства.
        /// </summary>
        public int[] Args_x
        {
            get
            {
                return args_x;
            }
            set
            {
                args_x = value;
                OnPropertyChanged("Args_x");
                OnPropertyChanged("F_x_y");
            }
        }
        /// <summary>
        /// СВойство, принимает и возвращает значение y,
        /// извещает систему об изменении свойства.
        /// </summary>
        public int[] Args_y
        {
            get
            {
                return args_y;
            }
            set
            {
                args_y = value;
                OnPropertyChanged("Args_y");
                OnPropertyChanged("F_x_y");
            }
        }
        /// <summary>
        /// Возвращает вычисленное значение f(x,y).
        /// </summary>
        public int[] F_x_y
        {
            get
            {
                f_x_y = Function(formula, coeff_a, coeff_b, coeff_c, args_x, args_x, number_of_args);
                return f_x_y;
            }

        }
        /// <summary>
        /// Метод вычисления функции.
        /// </summary>
        /// <param name="formula">Название формулы</param>
        /// <param name="a">Коэффициент а</param>
        /// <param name="b">Коэффициент b</param>
        /// <param name="c">Коэффициент c</param>
        /// <param name="x">Массив из аргументов функции x</param>
        /// <param name="y">Массив из аргументов функции y</param>
        /// <param name="number">Количество аргументов в массивах x,y и f(x,y)</param>
        /// <returns>Массив из значений функции f(x,y)</returns>
        public int[] Function(string formula, int a, int b, int c, int[] x, int[] y, int number)
        {
            int[] result = new int[number];
            int f = 0;
            switch(formula)
            {
                case "Линейная":        f = 1;
                                        break;
                case "Квадратичная":    f = 2;
                                        break;
                case "Кубическая":      f = 3;
                                        break;
                case "4-ой степени":    f = 4;
                                        break;
                case "5-ой степени":    f = 5;
                                        break;
            }

            for(int i  = 0; i < number; i++)
            {
                int x_in_power = (int)(System.Math.Pow(x[i], f));
                int y_in_power = (int)(System.Math.Pow(y[i], f - 1));
                result[i] = c + a * x_in_power + b * y_in_power;
            }
            
            return result;

        }
        /// <summary>
        /// Интерфейс INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Функция для извещения системы об изменении свойств.
        /// </summary>
        /// <param name="prop">Имя свойства</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "") 
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
