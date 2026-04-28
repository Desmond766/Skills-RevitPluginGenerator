---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SplitStraight(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.XYZ)
source: html/6f5e92db-db24-b4a0-2578-f232c8cedf94.htm
---
# Autodesk.Revit.DB.FabricationPart.SplitStraight Method

Splits the straight into two at the passed in point.

## Syntax (C#)
```csharp
public ElementId SplitStraight(
	Document document,
	ElementId partId,
	XYZ position
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **partId** (`Autodesk.Revit.DB.ElementId`) - Identifier of the straight to split.
- **position** (`Autodesk.Revit.DB.XYZ`) - The position to split in the straight.

## Returns
Returns the element identifier of the new straight.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The part is not a straight.
 -or-
 The position is not on the straight.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

