---
kind: method
id: M:Autodesk.Revit.UI.IExternalCommand.Execute(Autodesk.Revit.UI.ExternalCommandData,System.String@,Autodesk.Revit.DB.ElementSet)
source: html/ab42c8d3-d361-88d2-5043-2d427d1238fc.htm
---
# Autodesk.Revit.UI.IExternalCommand.Execute Method

Overload this method to implement and external command within Revit.

## Syntax (C#)
```csharp
Result Execute(
	ExternalCommandData commandData,
	out string message,
	ElementSet elements
)
```

## Parameters
- **commandData** (`Autodesk.Revit.UI.ExternalCommandData`) - An ExternalCommandData object which contains reference to Application and View
needed by external command.
- **message** (`System.String %`) - Error message can be returned by external command. This will be displayed only if the command status
was "Failed". There is a limit of 1023 characters for this message; strings longer than this will be truncated.
- **elements** (`Autodesk.Revit.DB.ElementSet`) - Element set indicating problem elements to display in the failure dialog. This will be used
only if the command status was "Failed".

## Returns
The result indicates if the execution fails, succeeds, or was canceled by user. If it does not
succeed, Revit will undo any changes made by the external command.

