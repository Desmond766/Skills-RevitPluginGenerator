---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.CanPostCommand(Autodesk.Revit.UI.RevitCommandId)
source: html/ad477369-623b-2747-9f76-f24b17aed6b4.htm
---
# Autodesk.Revit.UI.UIApplication.CanPostCommand Method

Identifies if the given command can be posted, using PostCommand(RevitCommandId) .

## Syntax (C#)
```csharp
public bool CanPostCommand(
	RevitCommandId commandId
)
```

## Parameters
- **commandId** (`Autodesk.Revit.UI.RevitCommandId`) - The command Id.

## Remarks
Only members of Autodesk.Revit.UI.PostableCommand or external commands can be posted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when commandId is Nothing nullptr a null reference ( Nothing in Visual Basic) .

