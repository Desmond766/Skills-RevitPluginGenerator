---
kind: method
id: M:Autodesk.Revit.UI.UIApplication.CreateAddInCommandBinding(Autodesk.Revit.UI.RevitCommandId)
source: html/a9a2ddeb-f35c-de4f-55b2-83f6fdea7dae.htm
---
# Autodesk.Revit.UI.UIApplication.CreateAddInCommandBinding Method

Creates a new AddInCommandBinding.

## Syntax (C#)
```csharp
public AddInCommandBinding CreateAddInCommandBinding(
	RevitCommandId revitCommandId
)
```

## Parameters
- **revitCommandId** (`Autodesk.Revit.UI.RevitCommandId`) - The Revit command id to identify the command handler you want to replace.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when uiApplication or revitCommandId
is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the given command already has been bound.

