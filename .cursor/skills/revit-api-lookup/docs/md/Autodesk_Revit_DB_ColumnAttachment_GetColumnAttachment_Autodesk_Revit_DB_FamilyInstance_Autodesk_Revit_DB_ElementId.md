---
kind: method
id: M:Autodesk.Revit.DB.ColumnAttachment.GetColumnAttachment(Autodesk.Revit.DB.FamilyInstance,Autodesk.Revit.DB.ElementId)
source: html/15a48a2f-e0b1-f820-3c72-bc6daf8ff662.htm
---
# Autodesk.Revit.DB.ColumnAttachment.GetColumnAttachment Method

Look up a column attachment by specifying the target id.

## Syntax (C#)
```csharp
public static ColumnAttachment GetColumnAttachment(
	FamilyInstance column,
	ElementId targetId
)
```

## Parameters
- **column** (`Autodesk.Revit.DB.FamilyInstance`) - A column.
- **targetId** (`Autodesk.Revit.DB.ElementId`) - Id of a target element.

## Returns
The column attachment attaching the column to the target, or Nothing nullptr a null reference ( Nothing in Visual Basic) if there
 is no such attachment.

## Remarks
May return either a top or base attachment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

