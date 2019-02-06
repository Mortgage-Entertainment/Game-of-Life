using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Timer;

namespace Game_of_Life.Options
{
    class Handlers
    {
        /*
         *  Класс обработчиков событий
         *  
         *  Здесь пишутся все обработчики
         *   например, один из важнейших в игре, обработчик фпс
         *   
         */
         
        //---------------------------------------------------Обработчик FPS------------------------------------------------------------------------\\
        
        int FramesCount = 0;
        int FPSCount;

        private void OnIdle()
        {
            /*
             *  Обработчик события простоя приложения
             *  
             *  Выступает в роли таймера 
             *   с интелектуальным интервалом
             *    ( как только доступен новый цикл (кадр), один будет выполнен )
             *  
             *  Оброботчик FPS
             *  
             */
            

            sleep(100);   //  ограничение ( чтобы на начальных этапах разработки фпс не имел недопустимых значений )

            FramesCount++;
        }

        private void FPSMeterM()
        {
            /*
             *  Таймер с интервалом в секунду
             *  
             *  Нужен для измерения фпс
             *   ( кол-ва проходов OnIdle 
             *     за один проход этого таймера )
             *  
             */
            

            FPSCount = FramesCount;
            FramesCount = 0;
        }

        public void FPSInitialize()
        {
            /*
             *  Инициализирует 
             *    обработчик FPS и
             *    его измеритель
             *  
             *  Создаёт таймер и назначет его обработчик
             *  
             *  Назначает OnIdle ( обработчик FPS )
             *  
             */
            

            TimerCallback fpsm = new TimerCallback(FPSMeterM);
            Timer FPSMeterT = new Timer(fpsm, 0, 1000);

            Application.Idle = new EventHandler(OnIdle);
        }
    }
}
