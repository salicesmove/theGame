using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.Clear();
            User NewUser = new User();
            Goblin Goblin = new Goblin();
            Orc Orc = new Orc();
            Spider Spider = new Spider();
            string action = null;
            Console.WriteLine("Уже прошло 5 минут, как вы очнулись. Глаза начали привыкать к полумраку \n\rпомещения, а сознание стало проясняться.  Очевидно, что далее оставаться \n\rздесь небезопасно и пора искать выход. Но можно сначала немного осмотреться.");
        Cave:
            NewUser.location = 1;
            Console.WriteLine("Вы находитесь в темной пещере. Что будете делать?");
            Console.WriteLine("-Введите go, чтобы перейти в следующее помещение \n\r-Введите look, чтобы осмотреться");
            action = Console.ReadLine();
            if ((action == "look") && (NewUser.sword == false))
            {
                Console.Clear();
                Console.WriteLine("Вы внимательно смотрите по сторонам и замечаете в противоположном углу дряхлый \n\rскелет. Подойдя поближе, вы замечаете, что он сжимает ржавый меч в своей \n\rкостлявой руке. Мысленно поблагодарив бедолагу за такой щедрый подарок, \n\rвы берете оружее и отходите от скелета.");
                NewUser.EquipSword();
                Console.WriteLine("А между прочим, меч еще может послужить вам верой и правдой! Взяв его в руки, вы получаете 8 к атаке.");
                goto Cave;
            }
            else if ((action == "look") && (NewUser.sword == true))
            {
                Console.Clear();
                Console.WriteLine("Вы еще раз окидываете взглядом пещеру, но не замечаете ничего интересного.");
                goto Cave;
            }
            else if (action == "go") goto Cross;
            else
            {
                Console.Clear();
                goto Cave;
            }
        Cross:
            Console.Clear();
            NewUser.location = 2;
            Console.WriteLine("Вы проходите по узкому коридору и оказываетесь на развилке. Куда пойдете дальше?");
            Console.WriteLine("-Введите w, чтобы пройти прямо \n\r-Введите a, чтобы пойти налево \n\r-Введите d, чтобы пойти направо \n\r-Введите s, чтобы вернуться в пещеру");
            action = Console.ReadLine();
            if ((action == "s") && (NewUser.location == 2))
            {
                Console.Clear();
                goto Cave;
            }
            if ((action == "w") && (NewUser.location == 2)) goto Holl;
            if ((action == "a") && (NewUser.location == 2)) goto Room;
            if ((action == "d") && (NewUser.location == 2)) goto Spider;
            else
            {
                Console.Clear();
                goto Cross;
            }
        Spider:
            Console.Clear();
            NewUser.location = 5;
            Console.WriteLine("Вы свернули направо и долго шли по коридору, пока не оказались в пещере с \n\rгигантским пауком! К вашей удаче, он спал и не заметил вас.");
            Spider1:
            Console.WriteLine("Что вы будете делать?");
            Console.WriteLine("-Введите attack, чтобы напасть на паука \n\r-Введите look, чтобы обыскать пещеру \n\r-Введите go, чтобы вернуться на развилку");
            action = Console.ReadLine();
            if ((action == "attack")&&(NewUser.location == 5))
            {
                Console.Clear();
                Console.WriteLine("С боевым кличем вы ринулись в атаку на спящее животное!");
                if (NewUser.BattleWin(NewUser.attack, NewUser.health, NewUser.defence, Spider.attack, Spider.health, Spider.defence, Spider.alive) == true)
                    Console.WriteLine("Удивительно! Вы точно честно играли?)");
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вы умерли! Наверное, не стоило будить этого паука...");
                    goto Lose;
                }
            }
            if ((action == "look") && (NewUser.location == 5) && (NewUser.key == false))
            {
                Console.Clear();
                Console.WriteLine("Едва дыша, вы аккуратно обходите пещеру, стараясь не задеть спящего паука. Краем глаза вы замечаете кусок металла, который при ближайшем осмотрении оказывается ключом! Вы решаете взять его с собой, на всякий случай.");
                NewUser.GetKey();
                goto Spider1;
            }
            if ((action == "look") && (NewUser.location == 5) && (NewUser.key == true))
            {
                Console.Clear();
                Console.WriteLine("Вы еще раз крадетесь по пещере, но больше не замечаете ничего интересного.");
                goto Spider1;
            }
            if ((action == "go") && (NewUser.location == 5))
                goto Cross;
            else
            {
                Console.Clear();
                goto Spider;                
            }
        Holl:
            NewUser.location = 4;
            if ((NewUser.location == 4) && (Orc.alive == true))
            {
                Console.Clear();
                Console.WriteLine("Вы проходите прямо и оказываетесь в просторном холле. В противоположном конце вы замечаете дверь, вот он путь к свободе! Но вашу радость прервал грозный рев: прямо на вас бежит орк с топором, сражения не избежать...");
                if (NewUser.BattleWin(NewUser.attack, NewUser.health, NewUser.defence, Orc.attack, Orc.health, Orc.defence, Orc.alive) == true)
                {
                    Console.WriteLine("Битва была нелегкой, но вам удалось одолеть орка! Теперь вам никто не мешает \n\rпройти к двери, только сможете ли вы ее открыть?..");
                    Orc.alive = false;
                }
                else
                {
                    Console.WriteLine("Орк оказался слишком силен и вы умираете под натиском его ударов... ");
                    goto Lose;
                }
            }
            Holl1:
            if ((NewUser.location == 4) && (Orc.alive == false))
            {
                Console.WriteLine("Что вы будете делать?");
                Console.WriteLine("-Введите door, чтобы подойти к двери \n\r-Введите go, чтобы вернуться на развилку");
            }
            action = Console.ReadLine();
            if ((NewUser.location == 4) && (Orc.alive == false) && (action == "go"))
                goto Cross;
            if ((NewUser.location == 4) && (Orc.alive == false) && (action == "door") && (NewUser.key == false)) 
            {
                Console.Clear();
                Console.WriteLine("Вы подходите к двери и обнаруживаете запертый замок. Да уж, без ключа такой \n\rне открыть... ");
                goto Holl1;
            }
            if ((NewUser.location == 4) && (Orc.alive == false) && (action == "door") && (NewUser.key == true))
            {
                Console.Clear();
                Console.WriteLine("Вы подходите к двери и вспоминаете про ключ, найденный в пещере паука! Дрожащими руками вы открываете замок и наконец видите солнечный свет, теперь вы свободны!");
                goto Win;
            }
            else
            {
                Console.Clear();
                goto Holl;
            }
        Room:
            NewUser.location = 3;
            if ((NewUser.location == 3)&&(Goblin.alive == true))
            {
                Console.Clear();
                Console.WriteLine("Вы свернули налево и еще долго шли по узкому коридору, пока не очутились \n\rв просторной комнате. Не успев опомниться, вы услышали пронзительный визг \n\rи заметили, как прямо на вас несется гоблин! Делать нечего, придется драться.");
                if (NewUser.BattleWin(NewUser.attack, NewUser.health, NewUser.defence, Goblin.attack, Goblin.health, Goblin.defence, Goblin.alive) == true)
                {
                    Goblin.alive = false;
                    Console.WriteLine("Одолев гоблина, вы наконец можете спокойно осмотреться вокруг. Похоже, он уже \n\rдавно обитает в этой комнате, а атмосфера в ней царит подстать ее бывшему \n\rхозяину. Впрочем, задерживаться здесь у вас нет никакого желания, разве что \n\rможно осмотреть тело поверженного врага.");
                }
                else
                {
                    Console.WriteLine("Гоблин убил вас! Эх, зря вы не поискали какое-нибудь оружее...");
                    goto Lose;
                }
            }
            if ((NewUser.location == 3) && (Goblin.alive == false) && (NewUser.armor == false))
            {
                Console.WriteLine("Вы находитесь в комнате гоблина.");
                Console.WriteLine("Что будете делать?");
                Console.WriteLine("-Введите look, чтобы осмотреть тело \n\r-Введите go, чтобы вернуться к развилке");
                action = Console.ReadLine();
                if (action == "look")
                {
                    Console.Clear();
                    Console.WriteLine("С отвращением оглядев гоблина, вы подумали, что его броня могла бы еще послужитьвам. Стянув ее с трупа, вы, немного брезгуя, надеваете ее на себя. Вы получаете +5 к броне!");
                    NewUser.EquipArmor();
                }
                if (action == "go")
                    goto Cross;                
            }
            Room1:
            if ((NewUser.location == 3) && (Goblin.alive == false) && (NewUser.armor == true))
            {
                Console.WriteLine("Вы находитесь в комнате гоблина.");
                Console.WriteLine("Что будете делать?");
                Console.WriteLine("-Введите look, чтобы осмотреть комнату \n\r-Введите go, чтобы вернуться к развилке");
                action = Console.ReadLine();
                if (action == "look")
                {
                    Console.Clear();
                    Console.WriteLine("Похоже, в этой комнате не осталось ничего интересного.");
                    goto Room1;
                }
                if (action == "go")
                    goto Cross;
                else
                {
                    Console.Clear();
                    goto Room;
                }
            }            
            Win:
            {
                Console.WriteLine("Поздравляю, вы победили!");
                goto End;
            }
            Lose:
            {
                Console.WriteLine("К сожалению, обстоятельства сложились не в вашу пользу. Хотите попробовать \n\rеще раз? \n\r-Введите yes, чтобы начать заново \n\r-Введите no, чтобы выйти ");
                action = Console.ReadLine();
                if (action == "yes") goto Start;
                if (action == "no") goto End;
            }
            End:
            Console.WriteLine("Спасибо за игру!");
            Console.ReadKey();


        }
    }
}
