using System;

using System.Collections.Generic;
using Xamarin.Forms;

namespace Sprat
{
    public enum Language { Ru, En}

    public class App : Application
	{
		static public float ScreenWidth;
		static public float ScreenHeight;

        static public Dictionary<string, Tuple<string, string>> Strings = new Dictionary<string, Tuple<string, string>>()
        {
            { "Name", new Tuple<string, string>("Кильки", "Sprat") },
            { "Round", new Tuple<string, string>("Раунд", "Round") },
            { "Player0", new Tuple<string, string>("Игрок", "Player") },
            { "Player1", new Tuple<string, string>("Вова", "Vova") },
            { "Player2", new Tuple<string, string>("Дима", "Dima") },
            { "Player3", new Tuple<string, string>("Юра", "Yura") },
            { "Play", new Tuple<string, string>("Играть", "Play") },
            { "Settings", new Tuple<string, string>("Настройки", "Settings") },
            { "Description", new Tuple<string, string>("Описание", "Description") },
            { "DescriptionText", new Tuple<string, string>(@"Игра проходит в 2 этапа. На первом этапе игроки получают только штрафные очки, на втором − отыгрываются. Каждый этап состоит из нескольких сдач. Каждый игрок получает по 8 карт. Заход происходит по очереди по кругу. Первый заходящий определяется жребием.

   1 этап (Штрафной)

  Козырей нет. Ходить обязательно в масть. При отсутствии масти, сбрасывать можно любую карту за некоторыми исключениями.

   Не брать взяток — за каждую взятку по 2 штрафных очка. Итого: −16 очков.
   Не брать червей — за каждую червовую карту по 2 штрафных очка. С червей в этой партии при наличии других мастей ходить нельзя. Итого: −16 очков.
   Не брать «мальчиков» (валетов)— за каждого «мальчика» во взятке по 4 штрафных очка. Итого: −16 очков. (Либо: ни валетов, ни королей, но тогда за каждого по 2 штрафных очка).
   Не брать «девочек» (дам)— за каждую «девочку» во взятке по 4 штрафных очка. Итого: −16 очков.
   Не брать «кинга» (червового короля) — за взятого короля червей даётся 16 штрафных очков. С червей ходить нельзя. При наличии червового короля на руках и отсутствии масти, с которой был сделан ход, обязательно его сбрасывать, то есть «кинга» придерживать нельзя. Итого: −16 очков.
   Не брать 2 последние взятки — за каждую взятку по 8 штрафных очка. Итого: −16 очков.
   Не брать ничего («ералаш») — отрицательные очки начисляются как за все предыдущие партии (за взятки, за валетов, «кинга» ит.д.). С червей заходить нельзя. Итого: −96 очков.

  При игре 3 игроков число разыгрываемых штрафных очков заменяется на 30 в раздаче «не брать взяток» и на 24 во всех остальных. Соответственно за каждую взятку черви начисляется 3 штрафных очка, мальчика/девочку — по 6, «2 последние» — по 12 очков и «кинг» — 24 очка. В «ералаше» разыгрывается 150 очков сразу.

   2 этап (Отыгрыш или «хвалёнки»)

  На этом этапе игроки стараются набирать положительные очки. За каждую взятку − 3 плюсовых очка. Всего за раздачу разыгрывается 24 положительных очка.

  При игре 3 игроков цена каждой взятки 5 плюсовых очков. Всего в этом случае за раздачу разыгрывается 50 плюсовых очков.

  Всем игрокам сдаётся по 3 карты. Сидящий слева от сдающего заказывает по этим картам козырь (либо «бескозырку»), либо может сказать: «по последней», то есть козырь будет определяться последней картой «хвалящегося», которая демонстрируется всем игрокам. Также можно заказать «мизер», где старшинство карт поменяется местами (7 становится самой старшей картой, туз − самой младшей). Остальные игроки могут перекупить игру за некоторое количество взяток, которое в конце сдачи они передадут тому, у кого купили. Кроме того, игрок может без игры расписать всем по 2 взятки.

  Всего на этом этапе 8 сдач, то есть каждый имеет возможность «хвалиться» по 2 раза (если играется в первой части игры «ералаш»).

  Существует вариант, когда «хвалёнки» проходят в один круг (4 сдачи), а в пятой сдаче играется «обратный ералаш», когда за взятки, «девочек», «мальчиков», червей ит.д. начисляяются очки, так же как и на первом этапе, но со знаком «+» (всего 96 очков).

  Существует вариант кинга, когда на втором этапе играются те же партии, что и на первом, только с положительными очками («брать червей», «брать 2 последние взятки» ит.д.).

  Нередко играют короткий «кинг» — без «ералаша» и с 4 сдачами «хваленок».

  При правильном подсчёте очков в итоге сумма очков всех игроков должна равняться нулю", @"The game takes place in 2 stages. At the first stage the players get only the penalty points, the second - vengeance. Each stage consists of a few donations. Each player receives 8 cards. Sunset occurs turns around. First the Descending determined by lot.


Stage 1 (Penalty)


No Trumps. Walk necessarily follow suit. In the absence of color, you can reset any card with a few exceptions.

Do not take bribes - for every bribe to 2 penalty points. Total: -16 points.
Do not take the worms - for each card on Hearts 2 penalty points. With worms in this game can not walk in the presence of other kinds. Total: -16 points.
Do not take the ""boys"" (jacks) - for each ""boy"" in a bribe to 4 penalty points. Total: -16 points. (Or: no jacks or kings, but then for each of 2 penalty points).
Do not take the ""girls"" (ladies) - for every ""little girl"" in a bribe to 4 penalty points. Total: -16 points.
Do not take the ""King"" (King of Hearts) - for the capture of the king of hearts is given 16 penalty points. Since worms can not walk. In the presence of the King of Hearts in her arms and the absence of color, with which the course has been made, it is sure to reset it, ie ""King"" can not hold. Total: -16 points.
Do not take 2 last bribe - for every bribe to 8 penalty points. Total: -16 points.
Do not take anything ( ""pie"") - as the negative points are awarded for all the previous games (for a bribe, for the jacks, ""King,"" etc...). Since worms can not come. Total: -96 points.

With the game 3 players played out the number of penalty points is replaced by the 30 in hand, ""do not take bribes"" and 24 in all others. Accordingly, for each trick worms charged 3 penalty points, a boy / girl - 6, ""Last 2"" - 12 points and ""king"" - 24 points. In the ""Jumble"" is played to 150 points immediately.

Stage 2 (or wagering ""hvalёnki"")


At this stage, players try to gain positive points. For every bribe - plus 3 points. For only the hand is played to 24 points positive.

With the game 3 players each bribes price plus 5 points. Total in this case, the hand is played for 50 plus points.

All players are rented for 3 cards. Sitting to the left of the dealer orders for these cards trump (or ""peakless cap""), or it may say ""at last"", that is the trump card will be determined by the latest ""boasting,"" a map that demonstrates to all players. You can also order a ""minuscule"", where the cards will be swapped seniority (7 becomes the highest card, the ace - the lowest). The other players can buy up the game for a certain amount of bribes, which at the end of the date they will give to the one who bought it. In addition, the player can not play all the paint for 2 bribes.

Total at this stage 8 donations, ie everyone has the opportunity to ""brag"" 2 times (if played in the first part of the ""pie"" of the game).

There is an option when ""hvalenki"" held in one round (4 date), and the fifth delivery of the game ""Reverse pie"" when for a bribe, ""girls"", ""boys"", worms and TD nachislyayayutsya glasses, as well as and in the first stage, but with the sign ""+"" (total 96 points).

There is a version of King, when the second stage are played by the same party as the first, with positive points only ( ""take the worms ',' taking bribes last 2"" and so on. D.).

Often playing short ""king"" - without the ""Jumble"" and 4 ""turn hvalenok"".

With the proper calculation of points as a result of the sum of points of all players must be zero") },
            { "Hint1", new Tuple<string, string>("Не бери взяток", "Don't take bribes") },
            { "Hint2", new Tuple<string, string>("Не бери червы", "Don't take hearts") },
            { "Hint3", new Tuple<string, string>("Не бери валетов и королей", "Don't take jacks and kings") },
            { "Hint4", new Tuple<string, string>("Не бери дам", "Don't take queens") },
            { "Hint5", new Tuple<string, string>("Не бери две последние взятки", "Don't take two last bribes") },
            { "Hint6", new Tuple<string, string>("Не бери червого короля", "Don't take heart's king") },
            { "Hint0", new Tuple<string, string>("Берем взятки", "Take bribes") },
            { "Trump", new Tuple<string, string>("Козырь", "Trump") },
            { "Header", new Tuple<string, string>("Выберите язык", "Select language") }
        };

        public App ()
		{
            // The root page of your application
            MainPage = new NavigationPage(new StartPage());
            //MainPage = new NewPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

