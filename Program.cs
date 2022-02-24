using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno [] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcoesUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {

                    case "1":
                        Console.WriteLine("Informe o nome do aluno : ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Agora Informe a nota do aluno : ");

                        // var nota = decimal.Parse(Console.ReadLine());
                        if(decimal.TryParse(Console.ReadLine(), out decimal nota)){
                            aluno.Nota = nota;
                        }
                        else{
                            throw new ArgumentException("Valor da nota necessita ser decimal!");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;

                    case "2":
                        foreach(var a in alunos){
                            if (!string.IsNullOrEmpty(a.Nome)){
                                Console.WriteLine($"ALUNO {a.Nome} -> NOTA DE {a.Nome} : {a.Nota}");
                            }
                        }
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        int nrAlunos = 0;

                        for(int i=0; i < alunos.Length; i++){
                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Console.WriteLine($"MÉDIA DOS ALUNOS ATUALMENTE : {mediaGeral}");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcoesUsuario();
            }
            
        }

        private static string ObterOpcoesUsuario()
        {
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular  média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
