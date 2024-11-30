using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Files.Shared.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Files.UnitTests.Shared
{
	[TestClass]
	public class AsyncManualResetEventTests
	{
		[TestMethod]
		public async Task Test_SetAndWait()
		{
			var asyncEvent = new AsyncManualResetEvent();
			var waitTask = asyncEvent.WaitAsync(CancellationToken.None);

			asyncEvent.Set();

			await waitTask;  // Should complete immediately
			Assert.IsTrue(waitTask.IsCompletedSuccessfully);
		}

		[TestMethod]
		public async Task Test_TimeoutAfterDelay()
		{
			var asyncEvent = new AsyncManualResetEvent();
			var result = await asyncEvent.WaitAsync(1000, CancellationToken.None);

			Assert.IsFalse(result); // It should return false because no event is set within 1000 ms
		}

		[TestMethod]
		public async Task Test_SetAfterWait()
		{
			var asyncEvent = new AsyncManualResetEvent();
			var waitTask = asyncEvent.WaitAsync(CancellationToken.None);

			// Simulate some delay
			await Task.Delay(100);

			asyncEvent.Set();

			await waitTask;  // Should complete once Set() is called
			Assert.IsTrue(waitTask.IsCompletedSuccessfully);
		}
	}
}
