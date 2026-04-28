---
kind: property
id: P:Autodesk.Revit.DB.IFC.IFCImportOptions.CreateLinkInstanceOnly
source: html/47219405-9a1f-3e60-1c1c-bc88586d487e.htm
---
# Autodesk.Revit.DB.IFC.IFCImportOptions.CreateLinkInstanceOnly Property

Determines whether to create a linked symbol element or not.

## Syntax (C#)
```csharp
public bool CreateLinkInstanceOnly { get; set; }
```

## Remarks
If this value is false (default), we will create a linked symbol and instance.
 If this value is true, then we will re-use an existing linked symbol file and create an instance only.
 The intention is for CreateLinkInstanceOnly to be true when we are trying to create a new link, when the link already exists in the host file.

