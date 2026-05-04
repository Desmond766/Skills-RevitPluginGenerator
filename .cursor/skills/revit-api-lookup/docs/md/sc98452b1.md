---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.RemoveAddInCommandBinding(Autodesk.Revit.UI.RevitCommandId)
source: html/71a20b47-41d4-43be-4edb-b8b14cf56962.htm
---
# Autodesk.Revit.UI.UIApplication.RemoveAddInCommandBinding Method

Removes an AddInCommandBinding.

## Syntax (C#)
```csharp
public void RemoveAddInCommandBinding(
	RevitCommandId revitCommandId
)
```

## Parameters
- **revitCommandId** (`Autodesk.Revit.UI.RevitCommandId`) - The Revit command id to identify the command handler you want to remove the binding.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when uiApplication or revitCommandId
is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the given command is not bound with this add-in.

