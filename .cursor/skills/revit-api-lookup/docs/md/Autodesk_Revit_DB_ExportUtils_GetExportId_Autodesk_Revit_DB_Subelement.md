---
kind: method
id: M:Autodesk.Revit.DB.ExportUtils.GetExportId(Autodesk.Revit.DB.Subelement)
source: html/bfc97625-03ef-ee26-4a54-b625294bb426.htm
---
# Autodesk.Revit.DB.ExportUtils.GetExportId Method

Retrieves the GUID representing the subelement in DWF and IFC export.

## Syntax (C#)
```csharp
public static Guid GetExportId(
	Subelement subelement
)
```

## Parameters
- **subelement** (`Autodesk.Revit.DB.Subelement`) - The subelement.

## Returns
The value of the GUID representing the subelement in the export context.

## Remarks
This id is used in the contents of DWF export and IFC export and it should be used
 only when cross-referencing to the contents of these export formats.
 When storing Ids that will need to be mapped back to subelements in future sessions,
 UniqueId must be used.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

