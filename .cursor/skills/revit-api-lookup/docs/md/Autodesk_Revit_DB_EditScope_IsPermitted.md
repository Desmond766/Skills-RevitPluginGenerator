---
kind: property
id: P:Autodesk.Revit.DB.EditScope.IsPermitted
source: html/addcb3c7-f761-723c-de17-d9abbefde247.htm
---
# Autodesk.Revit.DB.EditScope.IsPermitted Property

Tells if the edit scope is permitted to start.

## Syntax (C#)
```csharp
public bool IsPermitted { get; }
```

## Remarks
The edit scope is not permitted to start for one of the following possible reasons:
 The document is in read-only state, or the document is currently modifiable,
 or there already is another edit mode active in the document.

