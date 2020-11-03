using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Исследование_сложности_прохождения_игры
{
    /// <summary>
    /// Класс осуществляет обработку пользовательских данных
    /// </summary>
    class Data
    {
        private StringBuilder text = new StringBuilder(500);
        private double[] chartData = new double[9];

        public Data (string path)
        {
            Excel excel = new Excel(path);

            int height = excel.Height(1);
            FirstEnter[] firstEnters = new FirstEnter[height - 1];

            //считаем данные из листа FirstEnter в массив структур             
            for (int i = 0; i < firstEnters.Length; i++)
            {
                firstEnters[i] = new FirstEnter((int)excel[1, i + 2, 1], (int)excel[1, i + 2, 2]);
            }

            //проверим, есть ли повторяющиеся значения на листе FirstEnter в столбце PlayerUid
            //для этого отсортируем массив
            Array.Sort(firstEnters, (x, y) => x.PlayerUid.CompareTo(y.PlayerUid));
            //если в нём есть такие повторяющиеся значения, то теперь они будут находиться на соседних позициях
            for (int i = 0; i < firstEnters.Length - 1; i++)
            {
                if (firstEnters[i].PlayerUid == firstEnters[i + 1].PlayerUid)
                {
                    throw new Exception("Обнаружены повторяющиеся значения PlayerUid в исходных данных");
                }
            }

            //посчитаем, сколько игроков до какого уровня игры дошло
            int[] people = new int[9];
            for (int i = 0; i < firstEnters.Length; i++)
            {
                people[firstEnters[i].MaxAchievedStep]++;
            }

            //найдём количество людей, прошедших отдельные уровни игры
            chartData[0] = firstEnters.Length;
            for (int i = 1; i < chartData.Length; i++)
            {
                chartData[i] = chartData[i - 1] - people[i - 1];
            }

            //сформируем строковое представление полученных данных
            text.Append("Шаг         Количество игроков         Часть игроков\n");
            for (int i = 0; i < chartData.Length; i++)
            {
                text.AppendFormat(" {0}", i);
                if (chartData[i] < 1000)
                    text.Append(" ");

                text.AppendFormat("                   {0}", chartData[i]);
                if (chartData[i] < 1000)
                    text.AppendFormat(" ");

                chartData[i] /= firstEnters.Length;
                text.AppendFormat("                                  {0:F5}\n", chartData[i]);
            }
        }

        public override string ToString()
        {
            return text.ToString();
        }

        public double[] ChartData
        {
            get
            {
                return chartData;
            }
        }
    }
}
