---
kind: method
id: M:Autodesk.Revit.DB.ColumnAttachment.RemoveColumnAttachment(Autodesk.Revit.DB.FamilyInstance,System.Int32)
source: html/bd8558bc-0436-235b-3a2f-a8d154059ea6.htm
---
# Autodesk.Revit.DB.ColumnAttachment.RemoveColumnAttachment Method

Removes an attachment at the top or base of a column, if there is one.

## Syntax (C#)
```csharp
public static void RemoveColumnAttachment(
	FamilyInstance column,
	int baseOrTop
)
```

## Parameters
- **column** (`Autodesk.Revit.DB.FamilyInstance`) - A column.
- **baseOrTop** (`System.Int32`) - 0 for base, 1 for top.

## Remarks
This method modifies both column and target elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - baseOrTop must be either 0 or 1.

