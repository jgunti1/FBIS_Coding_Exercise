// See https://aka.ms/new-console-template for more information
public interface ILetterService 
{
    /// <summary>
    /// Combine two letter files into one file.
    /// </summary>
    /// <param name="inputFile1">File path for the first letter.</param>
    /// <param name="inputFile2">File path for the second letter.</param>
    /// <param name="resultFile">File path for the combined letter.</param>
    void CombineTwoLetters(string inputFile1,string inputFile2, string resultFile);
}
public class LetterService : ILetterService
{
    public void CombineTwoLetters(string inputFile1 ,string inputFile2, string resultFile) 
    {
        // My implementation here.
        // Merge the text content in the two input files
        // and write the merged content to the output file.

        // Assuming current project is in CombinedLetters directory
        const string folder = "Input";
        const string admission = "Admission";
        const string scholarships = "Scholarships";
        

    }
}