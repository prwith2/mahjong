using mahjongfingertip.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Input;

namespace mahjongfingertip.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiUrl = "http://localhost:8080"; // URL da sua API

        private string _nomeJogador;
        private string _status;
        public ObservableCollection<Jogador> Jogadores { get; } = new ObservableCollection<Jogador>();

        public string NomeJogador
        {
            get => _nomeJogador;
            set => SetProperty(ref _nomeJogador, value);
        }

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public ICommand AdicionarJogadorCommand { get; }
        public ICommand IniciarPartidaCommand { get; }

        public MainViewModel()
        {
            AdicionarJogadorCommand = new Command(async () => await AdicionarJogador());
            IniciarPartidaCommand = new Command(async () => await IniciarPartida());
        }

        private async Task AdicionarJogador()
        {
            if (string.IsNullOrWhiteSpace(NomeJogador))
            {
                Status = "Por favor, insira um nome!";
                return;
            }

            var jogador = new Jogador { Nome = NomeJogador };

            var json = JsonSerializer.Serialize(jogador);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{ApiUrl}/jogadores", content);

            if (response.IsSuccessStatusCode)
            {
                Status = "Jogador adicionado com sucesso!";
                Jogadores.Add(jogador);
                NomeJogador = string.Empty; // Limpar o campo
            }
            else
            {
                Status = "Erro ao adicionar jogador.";
            }
        }

        private async Task IniciarPartida()
        {
            // Lógica para iniciar uma partida
            // Você pode criar a partida com IDs dos jogadores

            if (Jogadores.Count < 2)
            {
                Status = "Necessário pelo menos 2 jogadores para iniciar a partida.";
                return;
            }

            var partida = new Partida
            {
                Jogador1Id = Jogadores[0].Id, // Use IDs reais
                Jogador2Id = Jogadores[1].Id,
                Estado = "ATIVA"
            };

            var json = JsonSerializer.Serialize(partida);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{ApiUrl}/partidas", content);

            if (response.IsSuccessStatusCode)
            {
                Status = "Partida iniciada!";
            }
            else
            {
                Status = "Erro ao iniciar a partida.";
            }
        }
    }
}
