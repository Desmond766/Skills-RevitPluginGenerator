---
kind: property
id: P:Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.EnableAssistedAssociation
source: html/d829b828-282c-406e-b89e-a6f7cf5a84ec.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalToPhysicalAssociationManager.EnableAssistedAssociation Property

Indicates if associations between Analytical and Physical Elements should be created automatically.

## Syntax (C#)
```csharp
public static bool EnableAssistedAssociation { get; set; }
```

## Remarks
If this flag is set to true, the associations are made on creation of an analytical element over a physical element.
 If it's set to false, then the associations between analytical and physical elements have to be made manually.

