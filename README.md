# Программа для исследования сложности прохождения игры
В данной программе, по предоставленным заказчиком данным из Excel файла, было исследовано поведение пользователей мобильной игры. Было посчитано, сколько игроков прошло каждый из уровней игры и показано отношение количества людей, прошедших отдельные уровни к количеству людей, стартовавших игру. По рассчитанным данным был построен график воронки и определены уровни, на которых больше всего игроков прекращают прохождение, что позволило заказчику скорректировать сложность
разрабатываемой им игры. При разработке был использован C#, Windows Forms.
	
  На рисунке 1 показан графический интерфейс разработанной программы.
  
  ![](https://github.com/AlekseiSmetanin/Researching-the-difficulty-of-passing-the-game/blob/master/Screenshots/Github%20project%205%20pic%201.png "Рисунок 1 – Графический интерфейс программы")
  
  Рисунок 1 – Графический интерфейс программы

На рисунке 2 показан фрагмент данных, обрабатываемых программой. В столбце PlayerUid содержатся идентификаторы игроков, а в столбце Max AchievedStep содержатся максимальные уровни, достигнутые соответствующими игроками.

![](https://github.com/AlekseiSmetanin/Researching-the-difficulty-of-passing-the-game/blob/master/Screenshots/Github%20project%205%20pic%202.PNG "Рисунок 2 – Пример обрабатываемых программой данных")

Рисунок 2 – Пример обрабатываемых программой  данных

Из рисунка 1 видно, что значительная доля пользователей бросала прохождение на уровнях 1, 2 и 7. Получив данную рекомендацию, заказчик уменьшил сложность данных уровней.
