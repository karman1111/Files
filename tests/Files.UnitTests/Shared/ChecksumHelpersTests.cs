using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Files.Shared.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Files.UnitTests.Shared
{
	[TestClass]
	public class ChecksumHelpersTests
	{
		// Test for CalculateChecksumForPath
		[TestMethod]
		public void CalculateChecksumForPath_ShouldReturnValidChecksum()
		{
			// Arrange
			string path = @"C:\Test\file.txt";

			// Act
			string checksum = ChecksumHelpers.CalculateChecksumForPath(path);

			// Assert
			Assert.IsNotNull(checksum);
			Assert.AreEqual(32, checksum.Length); // MD5 produces a 32-character hex string
		}

		// Test for CreateCRC32 (Stream-based)
		[TestMethod]
		public async Task CreateCRC32_ShouldReturnValidChecksum()
		{
			// Arrange
			var inputData = new byte[] { 1, 2, 3, 4, 5 }; // Example data to calculate CRC32
			using var stream = new MemoryStream(inputData);
			var cancellationToken = CancellationToken.None;

			// Act
			string crc32Checksum = await ChecksumHelpers.CreateCRC32(stream, cancellationToken);

			// Assert
			Assert.IsNotNull(crc32Checksum);
			Assert.AreEqual(8, crc32Checksum.Length); // CRC32 produces an 8-character hex string
		}
	}
}
