﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.Templates.Core.Gen;
using Microsoft.Templates.UI.Resources;

namespace Microsoft.Templates.UI.ViewModels.Common
{
    public class LayoutViewModel
    {
        public BasicInfoViewModel Template { get; set; }

        public bool IsReadOnly { get; set; }

        public LayoutViewModel(LayoutInfo layout, string platform, string projectType, string frameworkName)
        {
            IsReadOnly = layout.Layout.Readonly;
            if (!IsReadOnly)
            {
                Template = new TemplateInfoViewModel(layout.Template, platform, projectType, frameworkName)
                {
                    Title = string.Format(StringRes.TemplateDetailsLayoutOptional, layout.Template.Name),
                };
            }
            else
            {
                Template = new TemplateInfoViewModel(layout.Template, platform, projectType, frameworkName);
            }
        }
    }
}
