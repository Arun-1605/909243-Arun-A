namespace CalculatorLib
{
    public class Calculator
    {
        public int Add(int firstNumber,int secondNumber)
        {
            if (firstNumber>0 && secondNumber>0)
            {
                return firstNumber + secondNumber;
            }
            else
            {
                return 0;
            }
        }

        public int Subtract(int firstNumber, int secondNumber)
        {
            if ((firstNumber > 0 && secondNumber > 0)  && (firstNumber > secondNumber))
            {
                return firstNumber - secondNumber;
            }
            else
            {
                return 0;
            }
        }

        public int Mutiply(int firstNumber, int secondNumber)
        {
            if (firstNumber > 0 && secondNumber > 0)
            {
                return firstNumber * secondNumber;
            }
            else
            {
                return 0;
            }
        }

        public double Divide(int firstNumber, int secondNumber)
        {
            if (firstNumber > 0 && secondNumber > 0)
            {
                return  firstNumber / secondNumber;
            }
            else
            {
                return 0;
            }
        }

        public int div(int dividend, int devisor)
        {
            if (devisor < 0)
            {
                throw new DivideByZeroException();
            }
            return dividend / devisor;
        }


    }
}
