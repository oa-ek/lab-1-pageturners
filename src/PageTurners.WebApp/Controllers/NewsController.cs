﻿using Microsoft.AspNetCore.Mvc;

public class NewsController : Controller
{
    public IActionResult News1()
    {
        // Опис першої новини
        var model = new NewsModel
        {
            Title = "Нова книга від відомого автора",
            ImageUrl = "/images/books3.jpg",
            Description = "Очікується виход нового роману від автора, який завжди здатен зачаровувати своїх читачів. Цей автор відомий своєю унікальною здатністю створювати відвертий і зворушливий світ у кожній своїй книзі.\r\n\r\nЦей новий роман - не виняток. Він пронизаний емоціями, неймовірною інтригою та глибокими персонажами. Захоплююча історія розгортається перед читачами, ведучи їх у подорож, що запам'ятається надовго.\r\n\r\nАвтор вміє відтворити образи і відчуття так чітко, що здається, що ви переживаєте всі пригоди разом із головними героями. Він робить кожен рядок проникненим справжньою магією слова, і саме це робить його книги неперевершеними шедеврами світової літератури.\r\n\r\nНе пропустіть цей винятковий роман. Він точно зачарує вас та залишить незабутні враження. Будьте готові до захоплюючої подорожі у світ літературних див і важливих відкриттів.."
        };
        return View("News", model);
    }

    public IActionResult News2()
    {
        // Опис другої новини
        var model = new NewsModel
        {
            Title = "Кращі книги цього місяця",
            ImageUrl = "/images/books2.jpg",
            Description = "<b>Захоплюючі Шедеври: Найкращі Книги Цього Місяця</b>\r\n\r\nЦього місяця ми запрошуємо вас у захоплюючу подорож у світ літературних шедеврів. Якщо ви шукаєте відмінну книгу для свого читацького списку, то ця стаття саме для вас. Ми обрали найкращі твори, що точно зачарують ваше читацьке серце та залишать незабутні враження.\r\n\r\n<b>1. \"Відкривайте Новий Світ\" - Автор Ім'я Автора</b>\r\n\r\nЦя книга - справжній скарб для любителів наукової фантастики. Відкрийте для себе новий світ, де межа між реальністю та фантазією зникає. Автор імовірною майстерністю переплітає сюжети, створюючи непередбачені повороти. Поглибіться у цей роман, і ви знайдете себе на краю космосу, де немає меж для уяви.\r\n\r\n<b>2. \"Листи до Митця\" - Ім'я Автора</b>\r\n\r\nЦя книга - як відкриття листа від старого друга. Вирушайте у подорож по найтеплішим спогадам та найглибшим роздумам. Автор дарує читачам свою душу у кожному рядку, і ви точно відчуєте цю інтимність. \"Листи до Митця\" - це нагадування про важливість мистецтва та людських зв'язків.\r\n\r\nЦі книги - лише початок вашої літературної подорожі цього місяця. Незалежно від того, які теми або жанри вас цікавлять, вони обов'язково здивують вас своєю якістю та глибиною. Не вагайтеся залишитися наодинці з цими шедеврами, оскільки вони принесуть вам не тільки задоволення, а й нові думки та враження. Рушайте в подорож у світ слів та історій, де кожна книга - це ключ до незвіданих горизонтів."
        };
        return View("News", model);
    }
}

public class NewsModel
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
}