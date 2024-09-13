namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"Veículo {placa} adicionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Não foi possível adicionar o veículo.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas) && horas >= 0)
                {
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa.ToUpper());

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
