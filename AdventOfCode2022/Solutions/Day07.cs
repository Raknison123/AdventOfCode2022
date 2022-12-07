using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022.Solutions
{
    public class Day07 : DayBase
    {
        private readonly Folder _folderStructure;
        public Day07(string input = null) : base(input)
        {
            _folderStructure = ParseFolderStructure();
        }

        protected override object SolvePart1()
        {
            var folderSizes = new List<int>();
            FindFoldersWithSizeSmallerThanThreshold(_folderStructure, 100000, folderSizes);

            return folderSizes.Sum();
        }

        private int FindFoldersWithSizeSmallerThanThreshold(Folder folder, int threshold, List<int> resultSizes)
        {
            var size = folder.Files.Select(f => f.Size).Sum();
            foreach (var subFolder in folder.SubFolders)
            {
                size += FindFoldersWithSizeSmallerThanThreshold(subFolder, 100000, resultSizes);
            }

            // Here we know the current folder size (including all content from subfolders
            if (size <= threshold)
            {
                resultSizes.Add(size);
            }

            return size;
        }

        protected override object SolvePart2()
        {
            var totalDiskSpace = 70000000;
            var freeSpaceNeeded = 30000000;
            var spaceUsed = FindFoldersWithSizeSmallerThanThreshold(_folderStructure, 0, new List<int>());
            var maxDiskUsageAllowed = spaceUsed + freeSpaceNeeded - totalDiskSpace;

            var resultSizes = new List<int>();
            FindFolderDeleteCandidates(_folderStructure, maxDiskUsageAllowed, resultSizes);
            return resultSizes.Min();
        }

        private int FindFolderDeleteCandidates(Folder folder, int maxDiskUseAllowed, List<int> resultSizes)
        {
            var size = folder.Files.Select(f => f.Size).Sum();
            foreach (var subFolder in folder.SubFolders)
            {
                size += FindFolderDeleteCandidates(subFolder, maxDiskUseAllowed, resultSizes);
            }

            if (size >= maxDiskUseAllowed)
            {
                resultSizes.Add(size);
            }

            return size;
        }

        private Folder ParseFolderStructure()
        {
            var folders = new Folder("/");
            Folder currentFolder = folders;

            foreach (var row in Input)
            {
                if (row.StartsWith('$')) // It's a command
                {
                    var command = row.Split("$ ")[1].Split(" ");
                    if (command[0] == "cd")
                    {
                        if (command[1] == "..")
                        {
                            currentFolder = currentFolder.ParentFolder;
                        }
                        else if (command[1] != "/")
                        {
                            currentFolder = currentFolder.SubFolders.Single(s => s.Name == command[1]);
                        }
                    }
                }
                else
                {
                    var splitted = row.Split(" ");
                    if (splitted[0] == "dir") // It's a folder
                    {
                        if (!currentFolder.SubFolders.Any(s => s.Name == splitted[1]))
                        {
                            var subFolder = new Folder(splitted[1])
                            {
                                ParentFolder = currentFolder
                            };
                            currentFolder.SubFolders.Add(subFolder);
                        }
                    }
                    else // It's a file
                    {
                        currentFolder.Files.Add(new File { Name = splitted[1], Size = Convert.ToInt32(splitted[0]) });
                    }
                }
            }

            return folders;
        }
    }

    public class Folder
    {
        public Folder(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public List<Folder> SubFolders { get; set; } = new List<Folder>();

        public Folder ParentFolder { get; set; }

        public List<File> Files { get; set; } = new List<File>();
    }

    public class File
    {
        public string Name { get; set; }

        public int Size { get; set; }
    }
}

