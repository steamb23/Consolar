﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamB23.Consolar;
using SteamB23.Consolar.UI;

namespace ConsolarTest
{
    class Program
    {
        static void Main(string[] args)
        {
            InputManager inputMgr = new InputManager();
            /*
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
            textLine.Depresent();
            */
            // 선택지 테스트
            Option option = new Option(new string[] { "1. 집으로", "2. 강으로", "3. 산으로", "4. 들로" }, 0, 0, 50);
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
            }

            Console.ReadKey(true);
        }
    }
}