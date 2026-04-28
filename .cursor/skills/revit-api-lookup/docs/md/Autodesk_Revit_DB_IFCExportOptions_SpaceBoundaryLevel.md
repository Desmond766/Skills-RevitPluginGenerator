---
kind: property
id: P:Autodesk.Revit.DB.IFCExportOptions.SpaceBoundaryLevel
source: html/d9076483-6224-f329-c2e2-a0ea87e7a6fe.htm
---
# Autodesk.Revit.DB.IFCExportOptions.SpaceBoundaryLevel Property

Level of space boundaries exported in IFC file.

## Syntax (C#)
```csharp
public int SpaceBoundaryLevel { get; set; }
```

## Remarks
There are three valid values for this integer:
 0 = export no space boundaries. This can save space if the receiving application doesn't use them.
 1 = export 1st level space boundaries. This is the default.
 2 = export 2nd level space boundaries. This is primarily for use in energy analysis programs, and the GSA.
 Default is 1.

