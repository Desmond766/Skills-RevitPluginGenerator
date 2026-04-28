---
kind: method
id: M:Autodesk.Revit.DB.ColumnAttachment.RemoveColumnAttachment(Autodesk.Revit.DB.FamilyInstance,Autodesk.Revit.DB.ElementId)
source: html/685266c2-e945-6769-80fc-a674bb874615.htm
---
# Autodesk.Revit.DB.ColumnAttachment.RemoveColumnAttachment Method

Removes any attachment of the column to the specified target.

## Syntax (C#)
```csharp
public static void RemoveColumnAttachment(
	FamilyInstance column,
	ElementId targetId
)
```

## Parameters
- **column** (`Autodesk.Revit.DB.FamilyInstance`) - A column.
- **targetId** (`Autodesk.Revit.DB.ElementId`) - Id of a target element.

## Remarks
This method modifies both column and target elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

