---
kind: method
id: M:Autodesk.Revit.DB.ColumnAttachment.AddColumnAttachment(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FamilyInstance,Autodesk.Revit.DB.Element,System.Int32,Autodesk.Revit.DB.ColumnAttachmentCutStyle,Autodesk.Revit.DB.ColumnAttachmentJustification,System.Double)
source: html/27944249-fe98-f6ef-ba85-6408535b2d0b.htm
---
# Autodesk.Revit.DB.ColumnAttachment.AddColumnAttachment Method

Attaches the column to the target. If an attachment already
 exists with the same "baseOrTop" value, no attachment is made.

## Syntax (C#)
```csharp
public static void AddColumnAttachment(
	Document doc,
	FamilyInstance column,
	Element target,
	int baseOrTop,
	ColumnAttachmentCutStyle cutColumnStyle,
	ColumnAttachmentJustification justification,
	double attachOffset
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The document containing column and target.
- **column** (`Autodesk.Revit.DB.FamilyInstance`) - A column.
- **target** (`Autodesk.Revit.DB.Element`) - A target element.
- **baseOrTop** (`System.Int32`) - 0 to attach the column base, 1 to attach the column top.
- **cutColumnStyle** (`Autodesk.Revit.DB.ColumnAttachmentCutStyle`) - Control the handling of columns that intersect their targets.
- **justification** (`Autodesk.Revit.DB.ColumnAttachmentJustification`) - Control the column extent in cases where the target is not a uniform height.
- **attachOffset** (`System.Double`) - An additional offset for the bottom. If positive, the column base or top will
 be higher than the attachment point; if negative, lower.

## Remarks
This method modifies both column and target elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - column is not a column that supports ColumnAttachments.
 -or-
 target is not a valid target for ColumnAttachments.
 -or-
 column already has an attachment at its base or top as specified by baseOrTop.
 -or-
 column already has an attachment to target.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - baseOrTop must be either 0 or 1.
 -or-
 The given value for attachOffset must be no more than 30000 feet in absolute value.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

