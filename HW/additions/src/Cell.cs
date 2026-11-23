using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSIM_HW
{
    internal class Cell
    {
        //Тип даних для реалізації станів клітини
        private enum State
        {
            Alive,
            Dead,
            Stable
        }

        const double STABLE_CHANCE = 0.95;
        private int stableTimer;

        private State cellState;
        private State nextgenerationCellStage;


        Random rand;

        //Конструктор, новостворена клітина завжди буде мертвою
        public Cell()
        {
            cellState = State.Dead;
            
            rand = new Random();
        }

        public void generationalStateChange(int numOfAliveNeighbors)
        {
            switch (cellState)
            {
                case State.Alive:

                    if (numOfAliveNeighbors < 2)                  // помирає від недонаселеності
                        nextgenerationCellStage = State.Dead;
                    else if (numOfAliveNeighbors == 2)            // живе до наступного покоління
                        nextgenerationCellStage = stableChance(numOfAliveNeighbors); //State.Alive;
                    else if (numOfAliveNeighbors == 3)            // живе до наступного покоління
                        nextgenerationCellStage = stableChance(numOfAliveNeighbors); //State.Alive;
                    else                                          // 4 чи більше сусіда- > dies of overpopulation
                        nextgenerationCellStage = State.Dead;

                    break;
                case State.Dead:

                    if (numOfAliveNeighbors < 2)                  // залишається мертвою
                        nextgenerationCellStage = State.Dead;
                    else if (numOfAliveNeighbors == 2)            // залишається мертвою
                        nextgenerationCellStage = State.Dead;
                    else if (numOfAliveNeighbors == 3)            // стає живою
                        nextgenerationCellStage = State.Alive;
                    else                                          // залишається мертвою
                        nextgenerationCellStage = State.Dead;

                    break;

                case State.Stable:
                    if (stableTimer-- <= 0)
                        nextgenerationCellStage = State.Alive;
                    break;
            }
        }

        public bool canInfluenceNeighbors()
        {
            if (cellState == State.Alive || cellState == State.Stable)
                return true;
            return false;
        }
        public int getStateCode() 
        {
            if (cellState == State.Alive)
                return 1;
            else if (cellState == State.Dead)
                return 0;
            return -1;
        }
        public void swapState() 
        {
            if (cellState == State.Alive)
                cellState = State.Stable;
            else if (cellState == State.Stable)
                cellState = State.Dead;
            else
                cellState = State.Alive;
        }

        public void switchToNewGeneration()
        {
            cellState = nextgenerationCellStage;
        }

        private State stableChance(int numOfAliveNeighbors)
        {
            if (rand.NextDouble() >= STABLE_CHANCE){
                stableTimer = numOfAliveNeighbors - 1;
                return State.Stable;
            }
            return cellState;
        }

        public override string ToString()
        {
            if (cellState == State.Alive)
                return "Alive";
            else if (cellState == State.Dead)
                return "Dead";
            return "Stable";
        }
    }
}
