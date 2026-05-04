---
kind: method
id: M:Autodesk.Revit.DB.GlobalParametersManager.MoveParameterDownOrder(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/ff6d35ee-db72-544c-033c-c8372842ebd0.htm
---
# Autodesk.Revit.DB.GlobalParametersManager.MoveParameterDownOrder Method

Moves given paramerer Down in the current order.

## Syntax (C#)
```csharp
public static bool MoveParameterDownOrder(
	Document document,
	ElementId parameterId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document containing the give global parameter
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - The parameter to move Down

## Returns
Indicates whether the parameter could be moved Down in order or not.

## Remarks
A parameter can only be moved within its parameter group, meaning that
 repeated moving a parameter will not push the parameter out of and into
 the next (in order) parameter group. When a parameter can no longer move
 because it is at the boundary of its group, this method returns False. This operation has no effect on the global parameters themselves.
 The rearranged order is only visible in the standard Global Parameters
 dialog. However, the order of parameters is serialized in the document,
 thus available on the DB level as well.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Global parameters are not supported in the given document.
 A possible cause is that it is not a project document,
 for global parameters are not supported in Revit families.
 -or-
 The input parameterId is not of a valid global parameter of the given document.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

