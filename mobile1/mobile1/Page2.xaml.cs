namespace mobile1;

public partial class Tripstraptrull : ContentPage
{
    private bool isPlayerXTurn = true; // Переменная для отслеживания текущего игрока
    private Button[,] buttons = new Button[3, 3]; // Массив кнопок для игрового поля
    private Random random = new Random();

    public Tripstraptrull() // Конструктор
    {
        InitializeComponent();

        // Инициализируем массив кнопок (предполагается, что они есть в XAML)
        buttons[0, 0] = Cell00;
        buttons[0, 1] = Cell01;
        buttons[0, 2] = Cell02;
        buttons[1, 0] = Cell10;
        buttons[1, 1] = Cell11;
        buttons[1, 2] = Cell12;
        buttons[2, 0] = Cell20;
        buttons[2, 1] = Cell21;
        buttons[2, 2] = Cell22;

        // Устанавливаем текст кнопки в зависимости от текущей темы
        UpdateThemeButtonText();
    }

    // Логика переключения между темной и светлой темами
    private void OnThemeSwitchClicked(object sender, EventArgs e)
    {
        // Переключаем тему
        if (App.Current.UserAppTheme == AppTheme.Light)
        {
            App.Current.UserAppTheme = AppTheme.Dark;
        }
        else
        {
            App.Current.UserAppTheme = AppTheme.Light;
        }

        // Обновляем текст кнопки после изменения темы
        UpdateThemeButtonText();
    }

    // Метод для обновления текста кнопки в зависимости от текущей темы
    private void UpdateThemeButtonText()
    {
        if (App.Current.UserAppTheme == AppTheme.Light)
        {
            ThemeSwitchButton.Text = "Темная тема";
        }
        else
        {
            ThemeSwitchButton.Text = "Светлая тема";
        }
    }

    // Обработка кликов по ячейке
    private void OnCellClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button == null || !string.IsNullOrEmpty(button.Text)) return;

        button.Text = isPlayerXTurn ? "X" : "O";
        button.TextColor = isPlayerXTurn ? Colors.Blue : Colors.Red;

        isPlayerXTurn = !isPlayerXTurn; // Меняем игрока
        CheckForWinner();
    }

    // Проверка победителя
    private void CheckForWinner()
    {
        string winner = null;

        // Проверка строк и столбцов
        for (int i = 0; i < 3; i++)
        {
            if (buttons[i, 0].Text == buttons[i, 1].Text && buttons[i, 1].Text == buttons[i, 2].Text && !string.IsNullOrEmpty(buttons[i, 0].Text))
                winner = buttons[i, 0].Text;
            if (buttons[0, i].Text == buttons[1, i].Text && buttons[1, i].Text == buttons[2, i].Text && !string.IsNullOrEmpty(buttons[0, i].Text))
                winner = buttons[0, i].Text;
        }

        // Проверка диагоналей
        if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && !string.IsNullOrEmpty(buttons[0, 0].Text))
            winner = buttons[0, 0].Text;
        if (buttons[0, 2].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 0].Text && !string.IsNullOrEmpty(buttons[0, 2].Text))
            winner = buttons[0, 2].Text;

        if (winner != null)
        {
            DisplayAlert("Победитель", $"Победил {winner}!", "OK");
            ShowPlayAgainPopup();
        }
        else if (IsBoardFull())
        {
            DisplayAlert("Ничья", "Ничья!", "OK");
            ShowPlayAgainPopup();
        }
    }

    // Проверка, заполнено ли игровое поле
    private bool IsBoardFull()
    {
        foreach (var button in buttons)
        {
            if (string.IsNullOrEmpty(button.Text))
                return false;
        }
        return true;
    }

    // Попап с предложением начать игру заново
    private async void ShowPlayAgainPopup()
    {
        bool playAgain = await DisplayAlert("Игра окончена", "Желаешь ли еще поиграть?", "Да", "Нет");
        if (playAgain)
        {
            OnNewGameClicked(this, EventArgs.Empty);
        }
    }

    // Начало новой игры
    private void OnNewGameClicked(object sender, EventArgs e)
    {
        foreach (var button in buttons)
        {
            button.Text = "";
            button.BackgroundColor = Colors.LightGray;
        }
        isPlayerXTurn = true;
    }

    // Случайный выбор первого игрока
    private void OnRandomPlayerClicked(object sender, EventArgs e)
    {
        isPlayerXTurn = random.Next(2) == 0;
        DisplayAlert("Первый ход", isPlayerXTurn ? "X ходит первым" : "O ходит первым", "OK");
    }
}
