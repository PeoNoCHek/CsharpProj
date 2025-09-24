Config settings = new Config();
WorkersData workersData = new WorkersData(settings.namesPath, settings.positionPath);
workersData.root.PrintTree();
Requirements requirements = new Requirements(settings.requirementsPath);

Requirements.PrintRequirements(requirements.requirements_dictionary);


var (money, numbers) = TreePath.FindFastestPath(workersData, requirements);

if (numbers.Count > 0)
 {
     var pathWithNames = numbers.Select(n => $"{workersData.allWorkersData[n].name} ({n})");
    Console.WriteLine($"Минимальный путь: {string.Join(" --- ", pathWithNames)}, стоимость = {money}");
}
else
{
    Console.WriteLine("Путь не найден.");
}



