using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life.Cells
{
    class EmtyCell
    {
        /*Класс пустой клетки.
         * Объект этого класса визуально будет
         * выступать в роли фоновых клеток
         * и невизульно содержать другие объекты вроде нейрона.
         */

        const int Value = 150;
        private int x, y;
        static private EmtyCell[,] Grid = new EmtyCell[Value, Value];
        
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

        public EmtyCell()   // Конструктор по умолчанию класса EmptyCell
        {
            Type = 0;   // Устанавливаем в тип клетки значение None
        }
    }
}
