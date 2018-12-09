using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Game_of_Life.Cells
{
    class EmtyCell
    {
        /*Класс пустой клетки.
         * Объект этого класса визуально будет
         * выступать в роли фоновых клеток
         * и невизульно содержать другие объекты вроде нейрона.
         */

        const int ArraySize = 150;
        private int Value = 0;
        private int x, y;
        static private EmtyCell[,] Grid = new EmtyCell[ArraySize, ArraySize];
        
        CellType Type;

        private enum CellType
        {
            /* Перечисление, которое содержит названия типов клеток.
             * Будет юзаться для хранения типа клетки, которая содержится
             * в объекте класса EmtyCell
             */

            None = 0,      // Это значение имеет каждый объект этого класса по умолчанию
            Neuron,        // Нейрон
            Building,      // Тип строительной клетки
            Leukocyte,     // Лейкоцит
            Muscle,        // Мышца
            Dead           // Мёртвая клетка
        };

        static public void SetGridImageSize(uint IndexX, uint IndexY, double CellHeight)                // нужно переименовать поля
        {
            Grid[IndexX, IndexY].Model.Height = CellHeight;
            Grid[IndexX, IndexY].Model.Width = CellHeight;
        }

        public EmtyCell()   // Конструктор по умолчанию класса EmptyCell
        {
            Type = 0;   // Устанавливаем в тип клетки значение None
            Value++;
        }

        static public void SetImagePosition(uint IndexX, uint IndexY, double CellHeight, uint RowsCount, uint CellsinRow, uint value)
        {
            Grid[IndexX, IndexY].Model.Left = (SystemParameters.PrimaryScreenHeight / 2) - (CellHeight / 2) + (CellHeight * RowsCount) + ScrollPosition.GetLeftofSet() - ScrollPosition.GetRightofSet();
            Grid[IndexX, IndexY].Model.Left = (SystemParameters.PrimaryScreenWidth / 2) - (CellHeight / 2) - (CellHeight * RowsCount) - (CellHeight * (CellsinRow - value)) + ScrollPosition.GetToptofSet() - ScrollPosition.GetDowntofSet();
        }
    }
}
