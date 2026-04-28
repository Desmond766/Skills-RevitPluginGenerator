---
kind: property
id: P:Autodesk.Revit.DB.Steel.SteelElementProperties.UniqueID
source: html/dea64fd4-0ab0-e45b-3814-c1d4c68f22f6.htm
---
# Autodesk.Revit.DB.Steel.SteelElementProperties.UniqueID Property

This method will return the fabrication id. This represents the link between the Revit and the Steel Core element.

## Syntax (C#)
```csharp
public Guid UniqueID { get; internal set; }
```

## Remarks
This id should not be confused with the guid returned by ExportUtils.GetExportId().

