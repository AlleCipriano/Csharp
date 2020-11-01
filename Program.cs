using System;
using revisao;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[10];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");                    
                        var  aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");                      

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal.");
                        }                  
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA : {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        decimal v1 = Math.Round(mediaGeral, 2);
                        var v = v1;

                        Conceito conceitoGeral;
                        if(v1 < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }    
                        else if(v1 < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(v1 < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                         else if(v1 < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                             conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Media Geral: {v1} - Conceito: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
