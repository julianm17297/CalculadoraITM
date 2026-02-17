using System;

namespace TareaCalculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Inicializamos las variables necesarias
            double numeroUno = 0;
            double numeroDos = 0;
            double resultado = 0;
            string operacion = "";
            bool operacionValida = true;

            Console.WriteLine("=== CALCULADORA MATEMÁTICA S.A.S ===");

            // 2. ENTRADA USANDO EL METODO DEL FINAL Y LLAMANDO LAS VARIABLES PARA ASIGNAR LOS VALORES
            numeroUno = LeerNumero("Ingresa el primer número: ");

            Console.Write("Elige la operación (suma +, resta -, multiplicacion *, division /): ");
            operacion = Console.ReadLine();

            numeroDos = LeerNumero("Ingresa el segundo número: ");

            // 3. LÓGICA DE OPERACIÓN
            switch (operacion)
            {
                case "+": resultado = numeroUno + numeroDos; break;
                case "-": resultado = numeroUno - numeroDos; break;
                case "*": resultado = numeroUno * numeroDos; break;
                case "/":
                    if (numeroDos == 0) // Validación división por cero
                    {
                        MostrarError("Error: No se puede dividir entre cero.");
                        operacionValida = false;
                    }
                    else { resultado = numeroUno / numeroDos; }
                    break;
                default:
                    MostrarError("Operación no válida.");
                    operacionValida = false;
                    break;
            }

            // 4. SALIDA
            if (operacionValida)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nResultado: {numeroUno} {operacion} {numeroDos} = {resultado}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        //  MÉTODO: CREAMOS UNO QUE LEE Y VALIDA NROS, PARA NO REPETIR EL CODIGO DE VALIDACION EN CADA NUMERO
        static double LeerNumero(string mensaje)
        {
            double numero;
            bool esValido;
            do
            {
                Console.Write(mensaje);
                esValido = double.TryParse(Console.ReadLine(), out numero);
                if (!esValido)
                {
                    MostrarError("Error: Debe ingresar un número válido.");
                }
            } while (!esValido);
            return numero;
        }

        // MÉTODO EXTRA: Para no repetir los colores de error,ya que si no por cada error tendriamos que repetir el mismo codigo.
        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}










