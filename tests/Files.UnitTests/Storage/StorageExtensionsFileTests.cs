using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Files.Core.Storage.Extensions;
using Files.Core.Storage.Storables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Files.UnitTests.Storage
{
	[TestClass]
	public class StorageExtensionsFileTests
	{
		[TestMethod]
		public async Task OpenStreamAsync_ShouldCallOpenStreamAsyncFromIFileExtended_WhenFileIsIFileExtended()
		{
			// Arrange
			var mockFileExtended = new Mock<IFileExtended>();
			var expectedStream = new MemoryStream();
			mockFileExtended
				.Setup(file => file.OpenStreamAsync(It.IsAny<FileAccess>(), It.IsAny<FileShare>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(expectedStream);

			IFile file = mockFileExtended.Object;

			// Act
			var result = await StorageExtensions.OpenStreamAsync(file, FileAccess.Read);

			// Assert
			Assert.AreEqual(expectedStream, result);
			mockFileExtended.Verify(file => file.OpenStreamAsync(It.IsAny<FileAccess>(), It.IsAny<FileShare>(), It.IsAny<CancellationToken>()), Times.Once);
		}

		[TestMethod]
		public async Task OpenStreamAsync_ShouldCallOpenStreamAsyncFromIFile_WhenFileIsNotIFileExtended()
		{
			// Arrange
			var mockFile = new Mock<IFile>();
			var expectedStream = new MemoryStream();
			mockFile
				.Setup(file => file.OpenStreamAsync(It.IsAny<FileAccess>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(expectedStream);

			IFile file = mockFile.Object;

			// Act
			var result = await StorageExtensions.OpenStreamAsync(file, FileAccess.Read);

			// Assert
			Assert.AreEqual(expectedStream, result);
			mockFile.Verify(file => file.OpenStreamAsync(It.IsAny<FileAccess>(), It.IsAny<CancellationToken>()), Times.Once);
		}
	}
}
