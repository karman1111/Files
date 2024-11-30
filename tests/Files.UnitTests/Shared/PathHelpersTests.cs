using Files.Shared.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Files.UnitTests.Shared
{
	[TestClass]
	public class PathHelpersTests
	{

		[TestMethod]
		[DataRow(@"C:\Folder\Subfolder\file.txt", "file.txt")]
		[DataRow(@"\\NetworkShare\Folder\file.txt", "file.txt")]
		[DataRow(@"C:\file.txt", "file.txt")]
		[DataRow(@"\\NetworkShare\file.txt", "file.txt")]
		[DataRow(@"C:\Documents\Link.lnk", "Link")]
		public void FormatName_ShouldReturnCorrectFileName(string path, string expectedFileName)
		{
			// Act
			var result = PathHelpers.FormatName(path);

			// Assert
			Assert.AreEqual(expectedFileName, result);
		}

		[TestMethod]
		[DataRow("C:\\Users", "file.txt", "C:\\Users\\file.txt")]
		[DataRow("C:/Users", "file.txt", "C:/Users/file.txt")]
		[DataRow("", "file.txt", "file.txt")]
		[DataRow("C:\\Users\\Desktop", "document.pdf", "C:\\Users\\Desktop\\document.pdf")]
		public void Combine_ShouldCombinePathsCorrectly(string folder, string name, string expected)
		{
			// Act
			var result = PathHelpers.Combine(folder, name);

			// Assert
			Assert.AreEqual(expected, result);
		}

		[TestMethod]
		public void FormatName_ShouldHandleRootPaths()
		{
			// Act
			var result = PathHelpers.FormatName("C:\\");

			// Assert
			Assert.AreEqual("C:\\", result);
		}

		[TestMethod]
		public void FormatName_ShouldHandleNetworkPaths()
		{
			// Act
			var result = PathHelpers.FormatName(@"\\Network\Share\folder\file.lnk");

			// Assert
			Assert.AreEqual("file", result); // Should remove .lnk extension
		}

		[TestMethod]
		public void FormatName_ShouldHandleDrivePaths()
		{
			// Act
			var result = PathHelpers.FormatName(@"C:\");

			// Assert
			Assert.AreEqual(@"C:\", result); // Should return the full path as file name
		}

		[TestMethod]
		public void Combine_ShouldReturnNameIfFolderIsNullOrEmpty()
		{
			// Act
			var result = PathHelpers.Combine("", "file.txt");

			// Assert
			Assert.AreEqual("file.txt", result);
		}
	}
}
