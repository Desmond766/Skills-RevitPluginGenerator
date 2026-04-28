---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.AddCommandLink(Autodesk.Revit.UI.TaskDialogCommandLinkId,System.String)
zh: 提示、弹窗、消息框
source: html/e721540a-09a5-3bbd-2f58-b1f85b78de25.htm
---
# Autodesk.Revit.UI.TaskDialog.AddCommandLink Method

**中文**: 提示、弹窗、消息框

Adds a CommandLink associated to the given id, displaying the indicating main content.

## Syntax (C#)
```csharp
public void AddCommandLink(
	TaskDialogCommandLinkId id,
	string mainContent
)
```

## Parameters
- **id** (`Autodesk.Revit.UI.TaskDialogCommandLinkId`) - The id of the CommandLink. This corresponds to the value returned by Show() when the link is chosen by the user.
- **mainContent** (`System.String`) - The main content of the CommandLink.

## Remarks
Parameter mainContent cannot contain newlines. If the id has already been set to the task dialog, the new CommandLink definition overrides the old one. CommandLinks will always be shown in the dialog in the order of their ids.

