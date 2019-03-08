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
        CT_BASE,          // Обычная, ничего не умеющая, клетка
        CT_NEURON,        // Нейрон
        CT_BUILDING,      // Тип строительной клетки
        CT_LEUKOCYTE,     // Лейкоцит
        CT_MUSCLE,        // Мышца
        CT_DEAD           // Мёртвая клетка
    };

    public enum ResourseType
    {
        /*
         * Перечисление, объект которого будет показывать то,
         * какой тип ресурсов можно добыть с определённой клетки.
         * 
         * Префикс RT - ResourseType
         */

        RT_SALT = 0,       // Соль
        RT_CABODRA,        // Углеводы (carbohydrates)
        RT_PROTEIN,        // Белок
        RT_LYMPH,          // Лимфа
        RT_GLYCOGEN,       // Гликоген
        RT_WBC,            // Белые кровяные тельца (White Blood Cell)
        RT_PROTandCAB      // Протеин и углеводы (PROTEIN AND CABODRA)
    };
}
