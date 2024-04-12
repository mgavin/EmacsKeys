using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Text.Formatting;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using Microsoft.VisualStudio.Text;

namespace Microsoft.VisualStudio.Editor.EmacsEmulation.Commands
{
    /// <summary>
    /// This command is the opposite of scroll-down-command.
    /// 
    /// Keys: PgUp | Alt+V
    /// </summary>
    [EmacsCommand(EmacsCommandID.ScrollPageUp, CanBeRepeated = true, InverseCommand = EmacsCommandID.ScrollPageDown)]
    internal class ScrollPageUpCommand : EmacsCommand
    {
        internal override void Execute(EmacsCommandContext context)
        {
                        context.EditorOperations.MoveToTopOfView();
                        context.EditorOperations.ScrollLineCenter();
        }
    }
}
