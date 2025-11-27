using System;
using System.Text;

internal class TroChoiDoanSoCSharp
{
    static public void Main()
    {

        Console.InputEncoding = UTF8Encoding.UTF8;
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Console.WriteLine("|| ===================== Menu ==================== ||");

        Console.WriteLine("||     Game Đoán Số Chạy Bằng Màn Hình Console     ||");

        Console.WriteLine("||     Số Bí Mật Gồm 3 Chữ Số ( 100 - 999 )        ||");

        Console.WriteLine("||     Bạn Có Tổng Cộng 7 Lượt Đoán                ||");

        Console.WriteLine("|| =============================================== ||");

        Random random = new Random();
        int TargetNumber = random.Next(100, 1000);
        string TargerString = TargetNumber.ToString();

        int attempt = 1;
        const int MAX_GUESS = 7;
        string guess;
        string feedback = " ";
        bool ResultKetQua = false;

        while( attempt <= MAX_GUESS && !ResultKetQua)
        {
            Console.WriteLine("|| Lần Thử Đầu Tiên Của Bạn {0} / {1} ||", attempt, MAX_GUESS);
            do
            {
                Console.Write(" Nhập Chữ Số : ");
                guess = Console.ReadLine();
                if (guess.Length != 3 || !int.TryParse(guess, out int n) || n < 100 || n > 1000)
                {
                    Console.WriteLine(" Bạn Đã Nhập Sai Định Dạng ⚠️ , Vui Lòng Nhập 3 Chữ Số Từ ( 100 - 999 ). ");
                    continue;
                }
                break;
            } while (true);

            feedback = GetFeedBack(TargerString , guess);
            Console.Write("|| Phản Hồi Máy Tính : {0} ", feedback);

            attempt++;

            if (feedback == "+++")
            {
                ResultKetQua = true;
            }
        }


        if (ResultKetQua)
        {
            Console.WriteLine("|| Chúc Mừng ! Bạn Đã Đoán Đúng , Số Bị Mật Là : {0} , Số Lần Đoán {1} ", TargetNumber, attempt - 1);
        }
        else
        {
            Console.WriteLine("|| Thật Tiếc ! Bạn Đã Hết Lượt Đoán , Số Bí Mật Là : {0} ||", TargetNumber);
        }
    }

    static public String GetFeedBack(string Target , string Guess)
    {
        char[] TargerChar = Target.ToCharArray();
        char[] GuessChar = Guess.ToCharArray();

        bool[] TargetMatched = new bool[3];
        bool[] GuessMatChed = new bool[3];

        string PlushFeedBack = " ";
        string QuestFeedBack = " ";

        for(int i = 0; i < 3; i++)
        {
            if (GuessChar[i] == TargerChar[i])
            {
                PlushFeedBack += "+";

                TargetMatched[i] = true;
                GuessMatChed[i] = true;
            }
        }

        for(int i = 0; i < 3; i++)
        {
            if (!GuessMatChed[i])
            {
                for(int j = 0; j<3;j ++)
                {
                    if (GuessChar[i] == TargerChar[j] && !TargetMatched[j])
                    {
                        QuestFeedBack += "?";

                        TargetMatched[j] = true;
                    }
                }
            }
        }
        return PlushFeedBack + QuestFeedBack;
    }
}