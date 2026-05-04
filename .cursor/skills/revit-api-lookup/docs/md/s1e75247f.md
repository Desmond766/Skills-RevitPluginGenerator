---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Zone.RemoveSpaces(Autodesk.Revit.DB.Mechanical.SpaceSet)
source: html/2d015441-724c-d576-fcd6-5a00d9b94d44.htm
---
# Autodesk.Revit.DB.Mechanical.Zone.RemoveSpaces Method

Remove a set of existing spaces to the current Zone element.

## Syntax (C#)
```csharp
public bool RemoveSpaces(
	SpaceSet spaces
)
```

## Parameters
- **spaces** (`Autodesk.Revit.DB.Mechanical.SpaceSet`) - The spaces which want to delete from the current zone element.

## Returns
If successful the current zone element will remove a set of input spaces, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the specified parameter Value is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the input spaces cannot be deleted from current zone element.

