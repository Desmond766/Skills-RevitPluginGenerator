---
kind: method
id: M:Autodesk.Revit.DB.ExportUtils.GetExportId(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/f410a32a-f9dd-32b3-b640-3cfa90e8b168.htm
---
# Autodesk.Revit.DB.ExportUtils.GetExportId Method

Retrieves the GUID representing this element in DWF and IFC export.

## Syntax (C#)
```csharp
public static Guid GetExportId(
	Document document,
	ElementId elementId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **elementId** (`Autodesk.Revit.DB.ElementId`) - The id of the element.

## Returns
The value of the GUID representing the element in the export context.

## Remarks
This id is used in the contents of DWF export and IFC export and it should be used
 only when cross-referencing to the contents of these export formats.
 When storing Ids that will need to be mapped back to elements in future sessions,
 UniqueId must be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

