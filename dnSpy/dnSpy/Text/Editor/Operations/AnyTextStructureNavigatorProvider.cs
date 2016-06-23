﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.ComponentModel.Composition;
using dnSpy.Contracts.Text;
using dnSpy.Contracts.Text.Editor.Operations;

namespace dnSpy.Text.Editor.Operations {
	[ExportTextStructureNavigatorProvider(ContentTypes.ANY)]
	sealed class AnyTextStructureNavigatorProvider : ITextStructureNavigatorProvider {
		readonly IContentType contentType;

		[ImportingConstructor]
		AnyTextStructureNavigatorProvider(IContentTypeRegistryService contentTypeRegistryService) {
			this.contentType = contentTypeRegistryService.GetContentType(ContentTypes.ANY);
		}

		public ITextStructureNavigator CreateTextStructureNavigator(ITextBuffer textBuffer) =>
			new AnyTextStructureNavigator(textBuffer, contentType);
	}
}