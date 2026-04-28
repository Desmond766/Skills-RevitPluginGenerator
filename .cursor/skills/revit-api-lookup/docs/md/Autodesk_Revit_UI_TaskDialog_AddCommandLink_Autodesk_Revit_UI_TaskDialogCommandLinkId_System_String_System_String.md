---
kind: method
id: M:Autodesk.Revit.UI.TaskDialog.AddCommandLink(Autodesk.Revit.UI.TaskDialogCommandLinkId,System.String,System.String)
zh: 提示、弹窗、消息框
source: html/b8dafee6-cb97-6a2f-116c-3a7a9af9b8ef.htm
---
# Autodesk.Revit.UI.TaskDialog.AddCommandLink Method

**中文**: 提示、弹窗、消息框

Adds a CommandLink associated to the given id, displaying the indicating main and supporting content.

## Syntax (C#)
```csharp
public void AddCommandLink(
	TaskDialogCommandLinkId id,
	string mainContent,
	string supportingContent
)
```

## Parameters
- **id** (`Autodesk.Revit.UI.TaskDialogCommandLinkId`) - The id of the CommandLink. This corresponds to the value returned by Show() when the link is chosen by the user.
- **mainContent** (`System.String`) - The main content of the CommandLink.
- **supportingContent** (`System.String`) - The main content of the CommandLink.

## Remarks
Parameter mainContent cannot contain newlines. If the id has already been set to the task dialog, the new CommandLink definition overrides the old one. CommandLinks will always be shown in the dialog in the order of their ids.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when mainContent is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when mainContent is an empty string.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the mainContent contains newline characters.

