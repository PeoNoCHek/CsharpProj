public static class TreePath
{

    public static bool CheckIsThisBossAvailableToUseThisSub(int number_of_boss, int number_of_sub, WorkersData workers)
    {
        if (!workers.allWorkersData.ContainsKey(number_of_boss) || !workers.allWorkersData.ContainsKey(number_of_sub))
            return false;

        Tree current = workers.allWorkersData[number_of_sub];

        while (current != null)
        {
            if (current.number == number_of_boss)
                return true;

            current = current.parent;
        }

        return false;
    }


    public static (int money, List<int> numbers) FindFastestPath(WorkersData workers, Requirements requirements1)
    {
        var memory = new Dictionary<int, (int cost, List<int> path)>();



        (int cost, List<int> path) GetMinCostWithPath(int id, HashSet<int> visiting)
        {
        
            if (memory.TryGetValue(id, out var cached))
                return cached;

            if (visiting.Contains(id))
                return (int.MaxValue, new List<int>());

            if (!workers.allWorkersData.ContainsKey(id))
                return (int.MaxValue, new List<int>());

            visiting.Add(id);

            int selfMoney = workers.allWorkersData[id].money;

            if (!requirements1.requirements_dictionary.ContainsKey(id))
            {
                var p = new List<int> { id };
                memory[id] = (selfMoney, p);
                visiting.Remove(id);
                return memory[id];
            }

            int bestExtra = int.MaxValue;
            List<int> bestGroupPath = null;


            foreach (var group in requirements1.requirements_dictionary[id])
            {
                bool valid = true;
                int groupSum = 0;
                var groupPath = new List<int>();

                foreach (var sub in group)
                {
                    if (!CheckIsThisBossAvailableToUseThisSub(id, sub, workers))
                    {
                        valid = false;
                        break;
                    }

                    var (subCost, subPath) = GetMinCostWithPath(sub, visiting);
                    if (subCost == int.MaxValue)
                    {
                        valid = false;
                        break;
                    }

                    groupSum += subCost;
                    groupPath.AddRange(subPath);
                }

                if (valid && groupSum < bestExtra)
                {
                    bestExtra = groupSum;
                    bestGroupPath = groupPath;
                }
            }


            (int total, List<int> finalPath) result;
            if (bestExtra == int.MaxValue)
                result = (int.MaxValue, new List<int>());
            else
            {
                var final = new List<int>();
                final.AddRange(bestGroupPath);
                final.Add(id);
                result = (selfMoney + bestExtra, final);
            }

            memory[id] = result;
            visiting.Remove(id);
            return result;
        }

        var (rootCost, rootPath) = GetMinCostWithPath(workers.root.number, new HashSet<int>());
        return (rootCost == int.MaxValue ? 0 : rootCost, rootPath ?? new List<int>());
    }

}