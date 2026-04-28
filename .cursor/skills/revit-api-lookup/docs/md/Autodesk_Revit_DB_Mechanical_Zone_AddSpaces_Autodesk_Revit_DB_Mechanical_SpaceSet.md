---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.Zone.AddSpaces(Autodesk.Revit.DB.Mechanical.SpaceSet)
source: html/455eec6f-75c4-1f73-ef11-326975163398.htm
---
# Autodesk.Revit.DB.Mechanical.Zone.AddSpaces Method

Add a set of existing spaces to Zone element.

## Syntax (C#)
```csharp
public bool AddSpaces(
	SpaceSet spaces
)
```

## Parameters
- **spaces** (`Autodesk.Revit.DB.Mechanical.SpaceSet`) - The spaces which want to add to zone element.

## Returns
If successful the current zone element will add a set of input spaces, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the specified parameter Value is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the input spaces cannot be added to current zone element.

