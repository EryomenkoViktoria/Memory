using UnityEngine;

public class ResorcesLoader 
{
   public Theme GetTheme(string themeName)
    {
        return Resources.Load<Theme>(themeName);
    }
}
