﻿using System;
using System.IO;

class Program
{
    static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();

    static void Main()
    {
        // Start with drives if you have to search the entire computer.
        //string[] drives = Environment.GetLogicalDrives();

       // foreach (string dr in drives)
        
           // DriveInfo di = new DriveInfo(dr);

            // Here we skip the drive if it is not ready to be read. This
            // is not necessarily the appropriate action in all scenarios.
            //if (!di.IsReady)
            
                //Console.WriteLine("The drive {0} could not be read", di.Name);
               // continue;
            
            DirectoryInfo rootDir = new DirectoryInfo(@"C:\");
            WalkDirectoryTree(rootDir);
        

        // Write out all the files that could not be processed.
        Console.WriteLine("Files with restricted access:");
        foreach (string s in log)
        {
            Console.WriteLine(s);
        }
        // Keep the console window open in debug mode.
        Console.WriteLine("Press any key");
        Console.ReadKey();
    }

    static void WalkDirectoryTree(DirectoryInfo root)
    {
        //FileInfo[] files = null;
        DirectoryInfo[] subDirs = null;

        // First, process all the files directly under this folder
        try
        {
            subDirs = root.GetDirectories();
        }
        // This is thrown if even one of the files requires permissions greater
        // than the application provides.
        catch (UnauthorizedAccessException e)
        {
            // This code just writes out the message and continues to recurse.
            // You may decide to do something different here. For example, you
            // can try to elevate your privileges and access the file again.
            log.Add(e.Message);
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        if (subDirs != null)
        {
            foreach (DirectoryInfo di in subDirs)
            {
                // In this example, we only access the existing FileInfo object. If we
                // want to open, delete or modify the file, then
                // a try-catch block is required here to handle the case
                // where the file has been deleted since the call to TraverseTree().
                Console.WriteLine(di.Name);
            }

            // Now find all the subdirectories under this directory.
            

            foreach (DirectoryInfo dirInfo in subDirs)
            {
                // Resursive call for each subdirectory.
                WalkDirectoryTree(dirInfo);
            }
            //files = root.GetFiles("*.*");
        }
    }
}