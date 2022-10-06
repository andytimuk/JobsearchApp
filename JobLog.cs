public static class JobLog
{
    public static String[] Input(String[] storedInput, int noOfItems, string jobWebsite)
    {
        int i = 0;
        while (i < noOfItems)
        {
            Console.WriteLine($"Enter a {jobWebsite} company name and job title");
            storedInput[i] = Console.ReadLine();
            i++;
        }

        return storedInput;
    }
}