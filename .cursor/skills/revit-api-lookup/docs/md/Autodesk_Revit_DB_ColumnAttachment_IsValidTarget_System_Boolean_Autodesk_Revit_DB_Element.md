---
kind: method
id: M:Autodesk.Revit.DB.ColumnAttachment.IsValidTarget(System.Boolean,Autodesk.Revit.DB.Element)
source: html/667421da-a275-dc4b-93ea-92eb921878a4.htm
---
# Autodesk.Revit.DB.ColumnAttachment.IsValidTarget Method

Says whether the element can be used as a target for a new attachment.

## Syntax (C#)
```csharp
public static bool IsValidTarget(
	bool forSlantedColumn,
	Element target
)
```

## Parameters
- **forSlantedColumn** (`System.Boolean`) - If true, check whether the target is valid for a slanted column;
 if false, check whether the target is valid for a vertical column.
- **target** (`Autodesk.Revit.DB.Element`) - A proposed target element for a column attachment.

## Remarks
Valid targets are roofs, floors, ceilings, levels. Beams and braces
 are valid targets, except for slanted columns.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

