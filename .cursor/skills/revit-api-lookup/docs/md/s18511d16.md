---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.GetRevisionCloudNumberOnSheet(Autodesk.Revit.DB.ElementId)
zh: 图纸
source: html/677a2864-349f-42e6-481a-2c3cd55f8081.htm
---
# Autodesk.Revit.DB.ViewSheet.GetRevisionCloudNumberOnSheet Method

**中文**: 图纸

Gets the Revision Number for a RevisionCloud on this sheet.

## Syntax (C#)
```csharp
public string GetRevisionCloudNumberOnSheet(
	ElementId revisionCloudId
)
```

## Parameters
- **revisionCloudId** (`Autodesk.Revit.DB.ElementId`) - The id of the RevisionCLoud.

## Returns
Returns the Revision Number as it will appear on this sheet or Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no Revision Number assigned on this sheet.

## Remarks
Returns Nothing nullptr a null reference ( Nothing in Visual Basic) if the RevisionCloud or its associated Revision do not appear on this sheet. The Revision Number for
 a RevisionCloud will always be the same as the Revision Number of the associated Revision.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - revisionCloudId is not the Id of a RevisionCloud.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

