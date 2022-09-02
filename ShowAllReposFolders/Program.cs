Console.WriteLine("Show All Repos Folders!");

string logPath = @"C:\Users\gpdou\Desktop\DisplayFolders.log";
StreamWriter sw = File.AppendText(logPath);

DisplayAllFolders(@"C:\repos\C37\repos");

sw.Close();

void DisplayAllFolders(string folder, bool displayFiles = false) {
    string[] folders = Directory.GetDirectories(folder);
    foreach(string f in folders) {
        Console.WriteLine(f);
        WriteLog(f);
        if(displayFiles)
            DisplayAllFilesInFolder(f);
        DisplayAllFolders(f);
    }
}
#region DisplayAllFilesInFolder
void DisplayAllFilesInFolder(string folder) {
    string[] files = Directory.GetFiles(folder);
    foreach(string file in files) {
        Console.WriteLine(file);
        WriteLog(file);
    }
}
#endregion
#region WriteLog
void WriteLog(string message) {
    sw.WriteLine($"{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"):-30} {message}");
}
#endregion