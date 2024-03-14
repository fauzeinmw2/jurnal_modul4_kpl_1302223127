using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4_1302223127
{
    public enum EnumStateGame { Jongkok, Berdiri, Terbang, Tengkurap };
    public enum EnumTriggerGame { TombolW, TombolS, TombolX };

    public class PosisiKarakterGame
    {
        class TransitionGame
        {
            public EnumStateGame stateAwal;
            public EnumStateGame stateAkhir;
            public EnumTriggerGame trigger;

            public TransitionGame(EnumStateGame stateAwal, EnumStateGame stateAkhir, EnumTriggerGame trigger)
            {
                this.stateAwal = stateAwal;
                this.stateAkhir = stateAkhir;
                this.trigger = trigger;
            }
        }

        TransitionGame[] transitionGames =
        {
            new TransitionGame(EnumStateGame.Jongkok, EnumStateGame.Berdiri, EnumTriggerGame.TombolW),
            new TransitionGame(EnumStateGame.Berdiri, EnumStateGame.Jongkok, EnumTriggerGame.TombolS),

            new TransitionGame(EnumStateGame.Tengkurap, EnumStateGame.Jongkok, EnumTriggerGame.TombolW),
            new TransitionGame(EnumStateGame.Jongkok, EnumStateGame.Tengkurap, EnumTriggerGame.TombolS),

            new TransitionGame(EnumStateGame.Berdiri, EnumStateGame.Terbang, EnumTriggerGame.TombolW),
            new TransitionGame(EnumStateGame.Terbang, EnumStateGame.Berdiri, EnumTriggerGame.TombolS),

            new TransitionGame(EnumStateGame.Terbang, EnumStateGame.Jongkok, EnumTriggerGame.TombolX)
        };

        public EnumStateGame currentState = EnumStateGame.Berdiri;

        private EnumStateGame GetNextStateGame(EnumStateGame stateAwal, EnumTriggerGame trigger)
        {
            EnumStateGame stateAkhir = stateAwal;
            for (int i = 0; i < transitionGames.Length; i++)
            {
                TransitionGame transition = transitionGames[i];
                if (stateAwal == transition.stateAwal && trigger == transition.trigger)
                {
                    stateAkhir = transition.stateAkhir;
                }
            }

            return stateAkhir;
        }

        public void ActionGame(EnumTriggerGame trigger)
        {
            Console.Write("\n");
            Console.WriteLine("Posisi Awal : " + currentState);
            Console.WriteLine("Trigger : " + trigger);

            EnumStateGame tempCurrentState = currentState;
            currentState = GetNextStateGame(currentState, trigger);

            if (tempCurrentState == EnumStateGame.Terbang && currentState == EnumStateGame.Jongkok)
            {  
                Console.WriteLine("Posisi Landing");
            }
            else if (tempCurrentState == EnumStateGame.Berdiri && currentState == EnumStateGame.Terbang)
            {
                Console.WriteLine("Posisi Take Off");
            }
            else if(tempCurrentState == currentState)
            {
                Console.WriteLine("Tidak Aksi yang Dilakukan");
            }
            else
            {
                Console.WriteLine("Aksi Trigger ini, Bukan Bagian saya yang ngehandle :v");
            }
        }
    }
}
