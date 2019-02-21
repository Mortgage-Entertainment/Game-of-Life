using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life.Options
{
    public enum CellType
    {
        /*
         * Перечисление, которое содержит названия типов клеток.
         * Будет юзаться для хранения типа клетки, которая содержится
         * в объекте класса EmtyCell
         *
         *   префикс CT - CellType
         */

        CT_NONE = 0,      // Это значение имеет каждый объект этого класса по умолчанию
        CT_NEURON,        // Нейрон
        CT_BUILDING,      // Тип строительной клетки
        CT_LEUKOCYTE,     // Лейкоцит
        CT_MUSCLE,        // Мышца
        CT_DEAD           // Мёртвая клетка
    };

    public enum ResourseType
    {
        RT_SALT = 0       // Соль

    };
}
