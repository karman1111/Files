﻿// Copyright (c) 2023 Files Community
// Licensed under the MIT License. See the LICENSE.

namespace Files.Core.ViewModels.Dialogs.AddItemDialog
{
	public sealed class AddItemDialogListItemViewModel : ObservableObject
	{
		public string? Header { get; set; }

		public string? SubHeader { get; set; }

		public string? Glyph { get; set; }

		public IImageModel? Icon { get; set; }

		public bool IsItemEnabled { get; set; }

		public AddItemDialogResultModel? ItemResult { get; set; }
	}
}
