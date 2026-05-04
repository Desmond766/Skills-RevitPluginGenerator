---
kind: method
id: M:Autodesk.Revit.DB.ColumnAttachment.IsValidTarget(Autodesk.Revit.DB.FamilyInstance,Autodesk.Revit.DB.Element)
source: html/930335df-a9b3-d76c-1080-61cfb0d8ef2d.htm
---
# Autodesk.Revit.DB.ColumnAttachment.IsValidTarget Method

Says whether the element can be used as a target for a new attachment.

## Syntax (C#)
```csharp
public static bool IsValidTarget(
	FamilyInstance column,
	Element target
)
```

## Parameters
- **column** (`Autodesk.Revit.DB.FamilyInstance`) - The column to attach. If the target is a beam or brace, the column
 will be checked to see if it is slanted. Otherwise, this argument
 is not used and may be omitted.
- **target** (`Autodesk.Revit.DB.Element`) - A proposed target element for a column attachment.

## Remarks
Valid targets are roofs, floors, and ceilings. Beams and braces
 are also valid targets, except for slanted columns.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

