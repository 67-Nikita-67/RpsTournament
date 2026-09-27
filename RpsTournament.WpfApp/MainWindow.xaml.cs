using System.Collections.ObjectModel;
using System.Windows;
using RpsTournament.Core;

namespace RpsTournament.WpfApp
{
    public partial class MainWindow : Window
    {
        private int roundNumber = 0;
        private int playerScore = 0;
        private int computerScore = 0;

        private ObservableCollection<GameRound> rounds =
            new ObservableCollection<GameRound>();

        public MainWindow()
        {
            InitializeComponent();
            RoundsGrid.ItemsSource = rounds;
        }

        private void Rock_Click(object sender, RoutedEventArgs e)
        {
            PlayRound(Move.Rock);
        }

        private void Paper_Click(object sender, RoutedEventArgs e)
        {
            PlayRound(Move.Paper);
        }

        private void Scissors_Click(object sender, RoutedEventArgs e)
        {
            PlayRound(Move.Scissors);
        }

        private void PlayRound(Move playerMove)
        {
            string playerName = NameTextBox.Text.Trim();

            if (playerName.Length < 2 || playerName.Length > 30)
            {
                MessageBox.Show("Nimi peab olema 2–30 märki.");
                return;
            }

            if (roundNumber >= 5)
            {
                MessageBox.Show("Turniir on juba lõppenud.");
                return;
            }

            Move computerMove = GameLogic.GetComputerMove();

            RoundResult result =
                GameLogic.GetResult(playerMove, computerMove);

            roundNumber++;

            if (result == RoundResult.PlayerWin)
            {
                playerScore++;
            }
            else if (result == RoundResult.ComputerWin)
            {
                computerScore++;
            }

            GameRound gameRound = new GameRound(
                roundNumber,
                playerMove,
                computerMove,
                result
            );

            rounds.Add(gameRound);

            ScoreText.Text =
                $"Seis: {playerScore} : {computerScore}";

            if (roundNumber == 5)
            {
                ShowFinalResult(playerName);
            }
        }

        private void ShowFinalResult(string playerName)
        {
            string message;

            if (playerScore > computerScore)
            {
                message = $"{playerName} võitis turniiri!";
            }
            else if (computerScore > playerScore)
            {
                message = "Arvuti võitis turniiri!";
            }
            else
            {
                message = "Turniir lõppes viigiga!";
            }

            message +=
                $"\nLõppskoor: {playerScore} : {computerScore}";

            MessageBox.Show(message, "Turniiri tulemus");
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            roundNumber = 0;
            playerScore = 0;
            computerScore = 0;

            rounds.Clear();

            ScoreText.Text = "Seis: 0 : 0";
        }
    }
}