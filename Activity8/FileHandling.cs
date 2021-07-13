using System;
using System.IO;
using System.Text;

namespace CSharp.Activity.CoreUtilities
{
    public class FileHandling
    {
        private readonly string Path;

        /// <summary>
        /// Constructor to initialize.
        /// </summary>
        /// <param name="path">File name and path.</param>
        public FileHandling(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            }

            Path = path;

            File.WriteAllText(Path, "", Encoding.UTF8);
        }

        /// <summary>
        /// Writes the input contents to the file.
        /// </summary>
        /// <param name="contents">Data to write.</param>
        public void WriteToDisk(string contents)
        {
            if (contents == null)
            {
                throw new ArgumentNullException(nameof(contents));
            }

            File.AppendAllText(Path, contents, Encoding.UTF8);
        }

        /// <summary>
        /// Reads the contents of the file from the disk.
        /// </summary>
        /// <returns>Contents of the file as a string.</returns>
        public string ReadFromDisk()
        {
            return File.ReadAllText(Path, Encoding.UTF8);
        }
    }
}
