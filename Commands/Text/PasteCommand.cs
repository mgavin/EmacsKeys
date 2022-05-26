﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Text.Formatting;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using System.Windows;

namespace Microsoft.VisualStudio.Editor.EmacsEmulation.Commands
{
    /// <summary>
    /// This command pushes a mark with the location represented by the caret and then 
    /// inserts the top of the Clipboard Ring in the buffer at point.  
    /// The caret is at the end of the inserted text.
    /// 
    /// Note, repeatedly using c-y pastes repeated copies in the buffer, 
    /// even if c-y were to activate the region because emacs never replaces the region, 
    /// it always inserts at the point, ignoring that there’s a region. But I'm
    /// ignoring that behavior to emulate overwrite-selection mode.
    /// 
    /// Keys: Ctrl+Y
    /// </summary>
    /// 
    [EmacsCommand(VSConstants.VSStd97CmdID.Paste, UndoName = "Paste")]
    internal class PasteCommand : EmacsCommand
    {
        internal override void Execute(EmacsCommandContext context)
        {
            // emulate overwrite-selection mode, so don't adopt vanilla emacs behavior
            // Push the mark represented by the current position of the caret
            context.MarkSession.PushMark(false);

            context.CommandRouter.ExecuteDTECommand("Edit.Paste");
        }
    }
}
