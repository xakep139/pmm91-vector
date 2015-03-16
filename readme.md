Проект для выполнения задания по дисциплине "Технологии ООП"
=============

Преподаватель - Рояк Михаил Эммануилович
-------

Правила
-------

 * __Прежде чем начать что-то менять, обновите проект__ (выполните `svn update`);
 * Пишем все на *Microsoft Visual Studio 2012* (не ниже Update 3);
 * Используем *SVN* ([TortoiseSVN](http://tortoisesvn.net/) и [AnkhSVN](https://ankhsvn.open.collab.net/));
 * Перед тем как что-либо писать или проектировать пожалуйста просмотрите  [видео-уроки](https://www.youtube.com/user/Defazze?feature=watch), особенно 3й, 6й, 7й, а лучше все! Тогда вам сразу станет понятно как проектировать свою часть дабы не усложнять жизнь :);
 * При написании кода, пожалуйста следуйте следующим [правилам](http://michaelsmirnov.blogspot.ru/2011/01/c.html) - это упростит его понимание всем членам команды. Много комментариев не бывает))).

Участники
-------
 Архитектор проекта: *Хабарова Ксения* (по совместительству ИО команды Graphics).
 Бригады (неактивные выделены __жирным__):
 * _geometry_ (*Викторова*, Петрова, Тепляков, Мельников);
 * _graphics_ (*Давыдов*, Боличев, Приб, Шевчук, __Небогатиков__);
 * _GUI_ (*Балабаев*, Анищенко, Тесёлкин, __Казакова, Чемерилов__);
 * _IO & commands_ (*Валова*, Долговых, Воронова, Лисичкина).

Пример описания функции
-------
```c#
/// <summary>
/// Добавление фигуры
/// </summary>
/// <param name="fig">Добавляемая фигура</param>
/// <returns>Возвращает успешность добавления</returns>
bool AddFigure(IFigure fig);
```
```c#
//Да прибудет с Вами сила!
```
