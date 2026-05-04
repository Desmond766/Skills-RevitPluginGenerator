---
kind: method
id: M:Autodesk.Revit.UI.RevitCommandId.LookupPostableCommandId(Autodesk.Revit.UI.PostableCommand)
source: html/e5cb5335-70f7-3f74-2263-188847474335.htm
---
# Autodesk.Revit.UI.RevitCommandId.LookupPostableCommandId Method

Looks up and retrieves the Revit command id with the given id string.

## Syntax (C#)
```csharp
public static RevitCommandId LookupPostableCommandId(
	PostableCommand postableCommand
)
```

## Parameters
- **postableCommand** (`Autodesk.Revit.UI.PostableCommand`) - The postable command.

## Returns
The Revit command id. Returning Nothing nullptr a null reference ( Nothing in Visual Basic) if a command with the given name was not found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when name is Nothing nullptr a null reference ( Nothing in Visual Basic) .

