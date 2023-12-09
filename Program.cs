using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bacv2._4
{
    internal class Program
    {
        static List<string> produtos = new List<string>
    {
        "Sucrilos Leite Moça 700 g - Cod. Produto: 1-",
        "Sucrilos Integral 700 g - Cod. Produto: 2",
        "Leite sem lactose derivado - Cod. Produto: 3",
        "Pão de forma fofinho - Cod. Produto: 4",
        "Coca-Cola Zero - Cod. Produto: 5",
        "Arroz integral tia anastacia - Cod. Produto: 6",
        "Bolo de chocolate simples - Cod. Produto: 7",
        "Suco de laranja pretes - Cod. Produto: 8",
        "Pão de queijo - Cod. Produto: 9",
        "Pacote de Biscoito de polvilho - Cod. Produto: 10",
        "Chocolate KitKat - Cod. Produto: 11"
    };

        static List<double> precos = new List<double>
    {
        12.50, 20.50, 7.50, 8.50, 4.50, 14.50, 8.90, 10.50, 1.00, 5.00, 3.90
    };

        static List<int> carrinho = new List<int>();
        static List<int> quantidadesSelecionadas = new List<int>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Menu();
                Console.SetCursorPosition(22, 10);
                Console.WriteLine("Selecione uma opção:");
                Console.SetCursorPosition(22, 11);
                Console.WriteLine("1 - Selecionar Produtos (pelo código)");
                Console.SetCursorPosition(22, 12);
                Console.WriteLine("2 - Resumo de Compra");
                Console.SetCursorPosition(22, 13);
                Console.WriteLine("3 - Sair");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        SelecionarProdutos();
                        break;
                    case 2:
                        ResumoCompra();
                        break;
                    case 3:
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
         
        static void Menu()
        {
            Console.SetWindowSize(80, 24);
            Console.Title = "Caixa";
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(3, 2);
            Console.Write("Projeto caixa - 2023-1D");
            int coluna, linha;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");

            for (coluna = 0; coluna < 78; coluna++)
            {
                Console.SetCursorPosition(coluna + 1, 0);
                Console.Write("═");
            }

            Console.SetCursorPosition(79, 0);
            Console.Write("╗");

            for (linha = 1; linha < 24; linha++)
            {
                Console.SetCursorPosition(0, linha);
                Console.Write("║");
            }
            Console.SetCursorPosition(0, 4);
            Console.Write("╠");

            for (coluna = 0; coluna < 78; coluna++)
            {
                Console.SetCursorPosition(coluna + 1, 4);
                Console.Write("═");
            }
            Console.SetCursorPosition(0, 23);
            Console.Write("╚");
            linha = 1;

            for (linha = 1; linha < 23; linha++)
            {
                Console.SetCursorPosition(79, linha);
                Console.Write("║");
            }
            Console.SetCursorPosition(79, 4);
            Console.Write("╣");
            coluna = 1;
            Console.SetCursorPosition(79, 23);
            Console.Write("╝");

            for (coluna = 0; coluna < 78; coluna++)
            {
                Console.SetCursorPosition(coluna + 1, 23);
                Console.Write("═");
            }
        }
        static void SelecionarProdutos()
        {
            Console.Clear();
            Console.WriteLine("digite 0 para sair");
           

            for (int i = 0; i < produtos.Count; i++)
            {
                
            }
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Digite o código do produto (ou 0 para sair): ");
                int codigo = int.Parse(Console.ReadLine());
                if (codigo == 0)
                    break;
                if (codigo >= 1 && codigo <= produtos.Count)
                {
                    Console.Write("Digite a quantidade desejada: ");
                    int quantidade = int.Parse(Console.ReadLine());

                    if (quantidade > 0)
                    {
                        carrinho.Add(codigo);
                        quantidadesSelecionadas.Add(quantidade);
                        Console.WriteLine("Produto adicionado ao carrinho!");
                    }
                }
                else
                {
                    Console.WriteLine("Código de produto inválido. Tente novamente.");
                }
            }
        }
        static void ResumoCompra()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Resumo da compra:");       
            double totalCompra = 0;
            for (int i = 0; i < carrinho.Count; i++)
            {
                int codigo = carrinho[i];
                int index = codigo - 1;
                double preco = precos[index];
                int quantidade = quantidadesSelecionadas[i];
                double subtotal = quantidade * preco;
                totalCompra += subtotal;
                Console.WriteLine($"{produtos[index]} - Quantidade: {quantidade} - Preço Unitário: R${preco:F2} - Subtotal: R${subtotal:F2}");
            }
            Console.WriteLine($"Total da compra: R${totalCompra:F2}");
            Console.WriteLine("Selecione o meio de pagamento:");
            Console.WriteLine("1 - Dinheiro");
            Console.WriteLine("2 - Cartão débito");
            Console.WriteLine("3 - Cartão crédito");
            int opcaoPagamento = int.Parse(Console.ReadLine());

            switch (opcaoPagamento)
            {
                case 1:
                    Dinheiro(totalCompra);
                    break;
                case 2:
                    DebitoPag(totalCompra);
                    break;
                case 3:
                    Credito(totalCompra);
                    break;
                default:
                    Console.WriteLine("Opção de pagamento inválida.");
                    break;
            }
        }
        static void Dinheiro(double totalCompra)
        {
            Console.WriteLine("Digite o valor pago com dinheiro:");
            double dinheiro = double.Parse(Console.ReadLine());
            double troco = dinheiro - totalCompra;

            if (troco >= 0)
            {
                Console.WriteLine($"Troco: R${troco:F2}");
            }
            else
            {
                Console.WriteLine("O valor pago é insuficiente.");
            }
            Console.ReadLine();
        }

        static void DebitoPag(double totalCompra)
        {
            double taxaDebito = 0.025; // Taxa de transação de débito
            double totalComTaxa = totalCompra * (1 + taxaDebito);

            Console.WriteLine($"Total da compra com taxa de débito: R${totalComTaxa:F2}");

            double cartaoDebito = double.Parse(Console.ReadLine());

           
            Console.ReadLine();
        }
        static void Credito(double totalCompra)
        {
            double taxaCredito = 0.025; // Taxa de transação de crédito
            double totalComTaxa = totalCompra * (1 + taxaCredito);
            Console.WriteLine($"Total da compra com taxa de crédito: R${totalComTaxa:F2}");
            double cartaoCredito = double.Parse(Console.ReadLine());
            Console.ReadLine();
        }
    }
}
//Maria Cecilia e Taina
//1D
