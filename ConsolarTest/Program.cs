using System;
using SteamB23.Consolar;
using SteamB23.Consolar.UI;

namespace ConsolarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            InputManager inputMgr = new InputManager();
            
            // 생성 테스트
            TextLine textLine = new TextLine(5, 10, 5, 60);

            textLine.Text = "asdfasdf";
            textLine.Present();

            Console.ReadKey(true);

            // 텍스트 테스트
            textLine.Text = "나는 전설이다\n곤니찌와\n날가져요 엉엉\r\n빌게이만세\n청강게이전공";
            textLine.Present();

            Console.ReadKey(true);

            // 오른쪽 정렬 테스트
            textLine.IsRight = true;
            textLine.Present();

            Console.ReadKey(true);
            //textLine.Depresent();
            */

            // 선택지 테스트
            Option option = new Option(new string[] { "1. [c red][bc black]집[c reset][bc reset]으로", "2. [c red]강[c reset]으로", "3. [c red]산[c reset]으로", "4. [c red]들[c reset]로", "5. [c red]학교[c reset]로", "6. [c red]식당[c reset]으로", "7. [c red]시내[c reset]로", }, 30, 5, 20
                ,backgroundColor:ConsoleColor.DarkMagenta);
            switch (option.GetSelect())
            {
                case 0:
                    Console.WriteLine("집에 가자.");
                    break;
                case 1:
                    Console.WriteLine("강에 가자.");
                    break;
                case 2:
                    Console.WriteLine("산에 가자.");
                    break;
                case 3:
                    Console.WriteLine("들에 가자.");
                    break;
                case 4:
                    Console.WriteLine("학교에 가자.");
                    break;
                case 5:
                    Console.WriteLine("식당에 가자.");
                    break;
                case 6:
                    Console.WriteLine("시내에 가자.");
                    break;
                default:
                    Console.WriteLine("지원되는 명령이 아닙니다.");
                    break;
            }
        }
    }
}
