using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Files.Shared.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Files.UnitTests.Shared
{
	[TestClass]
	public class FileExtentionsHelpersTests
	{
		[TestMethod]
		public void HasExtension_ShouldReturnTrue_ForMatchingExtension()
		{
			// Arrange
			string filePath = @"C:\Documents\file.txt";

			// Act
			bool result = FileExtensionHelpers.HasExtension(filePath, ".txt", ".pdf", ".docx");

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void HasExtension_ShouldReturnFalse_ForNonMatchingExtension()
		{
			// Arrange
			string filePath = @"C:\Documents\file.txt";

			// Act
			bool result = FileExtensionHelpers.HasExtension(filePath, ".pdf", ".docx");

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void HasExtension_ShouldReturnFalse_ForNullFilePath()
		{
			// Arrange
			string filePath = null;

			// Act
			bool result = FileExtensionHelpers.HasExtension(filePath, ".txt", ".pdf");

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void HasExtension_ShouldReturnFalse_ForEmptyFilePath()
		{
			// Arrange
			string filePath = "";

			// Act
			bool result = FileExtensionHelpers.HasExtension(filePath, ".txt", ".pdf");

			// Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void HasExtension_ShouldReturnTrue_ForCaseInsensitiveExtension()
		{
			// Arrange
			string filePath = @"C:\Documents\file.TXT";

			// Act
			bool result = FileExtensionHelpers.HasExtension(filePath, ".txt");

			// Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void HasExtension_ShouldReturnTrue_ForMultipleMatchingExtensions()
		{
			// Arrange
			string filePath = @"C:\Documents\image.jpg";

			// Act
			bool result = FileExtensionHelpers.HasExtension(filePath, ".png", ".jpg", ".gif");

			// Assert
			Assert.IsTrue(result);
		}
	}
}
