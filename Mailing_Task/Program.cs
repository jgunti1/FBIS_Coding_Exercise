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
        if (File.Exists(resultFile)){
            Console.WriteLine("File already exists.");
        }
        string[] admission = File.ReadAllLines(inputFile1);
        string[] scholarship = File.ReadAllLines(inputFile2);

        using (StreamWriter sw = File.CreateText(resultFile))
        {
            int lineNum = 0;
            while(lineNum < admission.Length || lineNum < scholarship.Length)
            {
                if(lineNum < admission.Length)
                    sw.WriteLine(admission[lineNum]);
                if(lineNum < scholarship.Length)
                    sw.WriteLine(scholarship[lineNum]);
                lineNum++;
            }
        }
        string destinationFile = "Output/" +resultFile;
        File.Move(resultFile,destinationFile);
        
    
        
    }
    // Another attempt at moving files
    // Think I was doing too much but couldn't get it working
    public void ArchiveFiles () {
        string dateString = DateTime.Now.ToString("yyyyMMdd");
        string admSourceDir = "Input/Admission/" + dateString;
        string admDestinationDir = "Archive/Input/Admission/" + dateString;
        string schSourceDir = "Mailing_Task/Input/Admission/" + dateString;
        string schDestinationDir = "Mailing_Task/Archive/Input/Admission/" + dateString;
        // Console.WriteLine(Directory.Exists(admSourceDir));
        // Console.WriteLine(admSourceDir);
        // Console.WriteLine(Directory.Exists(admDestinationDir));
    

        
        
        /*
        // Assuming current project is in CombinedLetters directory
        string dateString = DateTime.Now.ToString("yyyyMMdd");
        string admission = "Input/Admission/" + dateString;
        string scholarships = "Input/Scholarships/" + dateString;
        string archiveAdmission = "Archive/" + admission;
        string archivePath = "/Users/jordangunti/Documents/FBIS_Coding_Exercise/Mailing_Task/Archive";
        
        // Archive files from Input to Archive

        
        // Check if there are files for the current day in format yyyyMMdd
        if (!Directory.Exists(admission) && !Directory.Exists(scholarships)) {
            Console.WriteLine("No Admissions or Scholarships for " + DateTime.Now.ToString("yyyy-MM-dd"));
        }
        else {
            // Gain access to files in Input folder
            // Create DirectoryInfo for Admissions and Scholarships
            // Gain access to the Admission and Scholarships folder
            DirectoryInfo diAdmission = new DirectoryInfo(admission);
            DirectoryInfo diScholarships = new DirectoryInfo(scholarships);
            DirectoryInfo diArchive = new DirectoryInfo(archiveAdmission);
            string[] filAdmission = Directory.GetFiles(admission);
            string[] filScholarships = Directory.GetFiles(scholarships);

            foreach (var filename in filAdmission) {
                string root = archivePath+"/"+filename;
                if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                else {
                    string file = Path.Combine(archivePath,filename.ToString());
                    if (!File.Exists(file)){
                        var source = Path.Combine("/Users/jordangunti/Documents/FBIS_Coding_Exercise/Mailing_Task", file);
                        var destination = Path.Combine(archivePath, file);
                        File.Copy(source, destination);
                    }
                    else {
                        Console.WriteLine("File already exists.");
                    }
                }
            }
            foreach (var filename in filScholarships) {
                string root = archivePath+"/"+filename;
                if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                else{
                    string file = Path.Combine(archivePath,filename.ToString());
                    if (!File.Exists(file)){
                        var source = Path.Combine("/Users/jordangunti/Documents/FBIS_Coding_Exercise/Mailing_Task", file);
                        var destination = Path.Combine(archivePath, file);
                        File.Copy(source, destination);
                    }
                    else {
                        Console.WriteLine("File already exists.");
                    }
                }
            }
        }
        */
    
    }
    static void Main()
    {
        LetterService p = new LetterService();
        // Keeping track of total letters combined
        int total = 0;
        // List to keep track of UID's to put in the report
        List<string> reportID = new List<string>();

        // Attempt at moving files,
        // Kept getting 
        // 'Unhandled exception. System.IO.DirectoryNotFoundException: Could not find a part of the path '/Users/jordangunti/Documents/FBIS_Coding_Exercise/Mailing_Task/Input/Admission/20230312'

        
        string dateString = DateTime.Now.ToString("yyyyMMdd");
        string[] admissionLetters = Directory.GetFiles("Input/Admission/" + dateString);
        string[] scholarshipLetters = Directory.GetFiles("Input/Scholarships/" + dateString);
        // Combine lists into one to check them at the same time
        var res = admissionLetters.Zip(scholarshipLetters, (a,s) => new {Admission = a, Scholarship = s});
        // Check if the files for the day exist
        if (Directory.Exists("Input/Admission/"+dateString) && Directory.Exists("Input/Scholarships/" + dateString)){
            foreach (var a in admissionLetters) {
                foreach (var s in scholarshipLetters) {
                    if (a.Substring(35,8)== s.Substring(40,8)) {
                        string id = a.Substring(35,8);
                        reportID.Add(id);
                        string newFile = id + "-admission-scholarship.txt";
                        string afile = a.Substring(25,22).ToString();
                        string sfile = s.Substring(28,24).ToString();
                        p.CombineTwoLetters(a,s,newFile);
                        total++;
                            
                    }
            }
        }
            // Create the text report
            string dateString2 = DateTime.Now.ToString("dd/MM/yyyy");
            string reportFile = dateString + "-report.txt";
            using (StreamWriter sw = new StreamWriter(reportFile)) {
                sw.WriteLine(dateString2 + " Report");
                sw.WriteLine("--------------------------");
                sw.WriteLine();
                sw.WriteLine("Number of Combined Letters: " + total);
                foreach (var id in reportID){
                    sw.WriteLine("  " + id);
                }
            }
            //Put it in the Output folder
            string destinationFile = "Output/" +reportFile;
            File.Move(reportFile,destinationFile);
        
        }
        else {
            string dateString2 = DateTime.Now.ToString("MM/dd/yyyy");
            Console.WriteLine("No Scholarships or Admissions for " + dateString2);
        }
        

    }
}
