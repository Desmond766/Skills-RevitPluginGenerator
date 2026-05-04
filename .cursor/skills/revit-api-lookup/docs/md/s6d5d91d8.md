---
kind: method
id: M:Autodesk.Revit.UI.Events.DisplayingOptionsDialogEventArgs.AddTab(System.String,Autodesk.Revit.UI.TabbedDialogExtension)
source: html/3b76b99d-65c3-d2b9-25ad-8069da549af1.htm
---
# Autodesk.Revit.UI.Events.DisplayingOptionsDialogEventArgs.AddTab Method

Add tab to option dialog with tab name and handler information.

## Syntax (C#)
```csharp
public void AddTab(
	string newTabName,
	TabbedDialogExtension tabbedDialogExtension
)
```

## Parameters
- **newTabName** (`System.String`) - The new tab page name.
- **tabbedDialogExtension** (`Autodesk.Revit.UI.TabbedDialogExtension`) - The handlers information for the new tab page.

## Remarks
There is a limit to the number of options page permitted in the dialog.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the limit
of pages allowed in the Options dialog will be exceeded (99).

