namespace CodeWars.Tasks.CodeWars;

public class TheHashtagGenerator
{
    public string GenerateHashtag(string stringToHashtag)
    {
        if (string.IsNullOrEmpty(stringToHashtag))
        {
            return "";
        }
        return "#" + stringToHashtag.Replace(" ", "");
    }
}