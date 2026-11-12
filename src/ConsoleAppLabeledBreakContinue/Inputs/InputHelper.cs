using Sharprompt;

namespace ConsoleAppLabeledBreakContinue.Inputs;

public static class AcoesPossiveis
{
    public const string BREAK_ENDPOINTS = "BREAK_ENDPOINTS";
    public const string CONTINUE_ENDPOINTS = "CONTINUE_ENDPOINTS";
    public const string BREAK_REQUESTS = "BREAK_REQUESTS";
    public const string CONTINUE_REQUESTS = "CONTINUE_REQUESTS";
}

public static class InputHelper
{
    public static string GetAnswerLoop()
    {
        Console.WriteLine();
        var answer = Prompt.Select("Escolha a acao",
            [AcoesPossiveis.CONTINUE_REQUESTS, AcoesPossiveis.BREAK_REQUESTS,
            AcoesPossiveis.CONTINUE_ENDPOINTS, AcoesPossiveis.BREAK_ENDPOINTS]);
        Console.WriteLine();
        return answer;
    }
}