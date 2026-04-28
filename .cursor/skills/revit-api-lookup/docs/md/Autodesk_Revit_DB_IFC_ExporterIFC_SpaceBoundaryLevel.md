---
kind: property
id: P:Autodesk.Revit.DB.IFC.ExporterIFC.SpaceBoundaryLevel
source: html/0beb0795-6270-5141-16df-e51e95acfa73.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFC.SpaceBoundaryLevel Property

Identifies the level of space boundaries being exported.

## Syntax (C#)
```csharp
public int SpaceBoundaryLevel { get; }
```

## Remarks
There are three valid values for this integer:
 0 = export no space boundaries. This can save space if the receiving application doesn't use them.
 1 = export 1st level space boundaries. This is the default.
 2 = export 2nd level space boundaries. This is primarily for use in energy analysis programs, and the GSA.

