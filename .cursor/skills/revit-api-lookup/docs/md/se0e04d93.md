---
kind: method
id: M:Autodesk.Revit.DB.ColumnAttachment.GetColumnAttachment(Autodesk.Revit.DB.FamilyInstance,System.Int32)
source: html/2cf91eab-b1ab-f6e1-8816-23146ded3484.htm
---
# Autodesk.Revit.DB.ColumnAttachment.GetColumnAttachment Method

Look up a column attachment. There is at most one attachment on
 the base and one on the top.

## Syntax (C#)
```csharp
public static ColumnAttachment GetColumnAttachment(
	FamilyInstance column,
	int baseOrTop
)
```

## Parameters
- **column** (`Autodesk.Revit.DB.FamilyInstance`) - A column.
- **baseOrTop** (`System.Int32`) - 0 for base, 1 for top.

## Returns
The column attachment for the base or top of the column, or Nothing nullptr a null reference ( Nothing in Visual Basic) if that end
 of the column is unattached.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - baseOrTop must be either 0 or 1.

