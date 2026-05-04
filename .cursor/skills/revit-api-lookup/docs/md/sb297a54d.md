---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.GetRevisionNumberOnSheet(Autodesk.Revit.DB.ElementId)
zh: 图纸
source: html/cf2ea568-81ba-40e6-c29c-e0c0138ffbe7.htm
---
# Autodesk.Revit.DB.ViewSheet.GetRevisionNumberOnSheet Method

**中文**: 图纸

Gets the Revision Number for a particular Revision as it will appear on this sheet.

## Syntax (C#)
```csharp
public string GetRevisionNumberOnSheet(
	ElementId revisionId
)
```

## Parameters
- **revisionId** (`Autodesk.Revit.DB.ElementId`) - The id of the Revision.

## Returns
Returns the Revision Number as it will appear on this sheet or Nothing nullptr a null reference ( Nothing in Visual Basic) if the Revision does not appear on this sheet.

## Remarks
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the Revision does not appear on this sheet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - revisionId is not a valid Revision.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

