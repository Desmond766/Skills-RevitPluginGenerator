---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.PostCommand(Autodesk.Revit.UI.RevitCommandId)
source: html/b0df464d-1733-ea9e-ac40-399fa9c9a037.htm
---
# Autodesk.Revit.UI.UIApplication.PostCommand Method

Posts the command to the Revit message queue to be invoked when control returns from the current API context.

## Syntax (C#)
```csharp
public void PostCommand(
	RevitCommandId commandId
)
```

## Parameters
- **commandId** (`Autodesk.Revit.UI.RevitCommandId`) - The command Id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when commandId is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - If the command cannot be posted.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - If there is a command already been posted.

