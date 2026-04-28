---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.SetAdditionalRevisionIds(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
zh: 图纸
source: html/376a4009-17f7-af8e-8c32-d95243ad8e9e.htm
---
# Autodesk.Revit.DB.ViewSheet.SetAdditionalRevisionIds Method

**中文**: 图纸

Sets the Revisions to additionally include in the sheet's revision schedules.

## Syntax (C#)
```csharp
public void SetAdditionalRevisionIds(
	ICollection<ElementId> projectRevisionIds
)
```

## Parameters
- **projectRevisionIds** (`System.Collections.Generic.ICollection < ElementId >`) - The ids of Revisions to explicitly include in the sheet's revision schedules.

## Remarks
Additionally included Revisions will always participate in the sheet's revision schedules.
 Normally a Revision is scheduled in the revision schedule because one of its associated RevisionClouds
 is present on the sheet.
 The additional project revision ids setting corresponds to the sheet's Revisions On Sheet parameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One or more ElementIds in projectRevisionIds do not correspond to a Revision element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

