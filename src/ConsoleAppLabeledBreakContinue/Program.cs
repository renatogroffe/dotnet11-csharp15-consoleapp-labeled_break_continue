using ConsoleAppLabeledBreakContinue.Inputs;
using System.Runtime.InteropServices;

Console.WriteLine("***** Testes com .NET 11 + C# 15 | Extension Indexers *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");
Console.WriteLine();

string[] endpoints =
[
    "https://baconipsum.com/api/?type=meat-and-filler&paras=2",
    "https://baconipsum.com/api/?type=meat-and-filler&paras=2&format=text"
];

using HttpClient cliente = new();

endpoints: for (int i = 0; i < endpoints.Length; i++)
{
    Console.WriteLine($"** Endpoint: {endpoints[i]}");

    requests: for (int tentativa = 1; tentativa <= 5; tentativa++)
    {
        Console.WriteLine($"Requisicao {tentativa}:");

        try
        {
            using HttpResponseMessage resposta = await cliente.GetAsync(endpoints[i]);
            Console.WriteLine($"Status: {(int)resposta.StatusCode} ({resposta.StatusCode})");
            Console.WriteLine(await resposta.Content.ReadAsStringAsync());
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Falha na requisicao: {ex.Message}");
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine($"Requisicao cancelada ou tempo esgotado: {ex.Message}");
        }

        Console.WriteLine();
        var answer = InputHelper.GetAnswerLoop();
        if (answer == AcoesPossiveis.CONTINUE_REQUESTS)
            continue requests;
        else if (answer == AcoesPossiveis.BREAK_REQUESTS)
            break requests;
        else if (answer == AcoesPossiveis.CONTINUE_ENDPOINTS)
            continue endpoints;
        else if (answer == AcoesPossiveis.BREAK_ENDPOINTS)
            break endpoints;
    }
}