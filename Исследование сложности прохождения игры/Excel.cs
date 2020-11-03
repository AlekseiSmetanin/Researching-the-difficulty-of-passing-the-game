using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;

namespace Исследование_сложности_прохождения_игры
{
    class Excel
    {
        private Application ex;

        /// <summary>
        /// Создаёт объект для работы с файлом Экселя
        /// </summary>
        /// <param name="path">Путь к файлу Экселя</param>
        public Excel(string path)
        {
            ex = new Microsoft.Office.Interop.Excel.Application();
            ex.Workbooks.Open(path);
        }

        ~Excel()
        {
            ex.Workbooks.Close();
        }

        /// <summary>
        /// Возвращает значение, находящееся в листе Экселя sheetNumber, в ячейке, расположенной в строке row и столбце column
        /// </summary>
        /// <param name="sheetNumber">Лист Экселя, нумерация с единицы</param>
        /// <param name="row">Строка, нумерация с единицы</param>
        /// <param name="column">Столбец, нумерация с единицы</param>
        /// <returns></returns>
        public dynamic this[int sheetNumber, int row, int column]
        {
            get
            {
                Worksheet sheet = (Worksheet)ex.Worksheets.get_Item(sheetNumber);
                Range range = sheet.Cells[row, column];

                return range.Value;
            }
        }

        /// <summary>
        /// Возвращает число строк в листе Экселя
        /// </summary>
        /// <param name="sheetNumber">Лист Экселя, нумерация с единицы</param>
        /// <returns></returns>
        public int Height(int sheetNumber)
        {
            Worksheet sheet = (Worksheet)ex.Worksheets.get_Item(sheetNumber);
            var lastCell = sheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);

            return lastCell.Row;
        }

        /// <summary>
        /// Возвращает число столбцов в листе Экселя
        /// </summary>
        /// <param name="sheetNumber">Лист Экселя, нумерация с единицы</param>
        /// <returns></returns>
        public int Width(int sheetNumber)
        {
            Worksheet sheet = (Worksheet)ex.Worksheets.get_Item(sheetNumber);
            var lastCell = sheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);

            return lastCell.Column;
        }
    }
}
