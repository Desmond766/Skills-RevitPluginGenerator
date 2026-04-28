---
kind: property
id: P:Autodesk.Revit.DB.Opening.IsTransparentIn3D
source: html/e467d103-7db0-b6c6-efe7-e231ffcf1b07.htm
---
# Autodesk.Revit.DB.Opening.IsTransparentIn3D Property

Indicates if the opening is transparent in 3D view when loaded into the project.

## Syntax (C#)
```csharp
public bool IsTransparentIn3D { get; set; }
```

## Remarks
This property is only valid in Revit family documents.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when access this property in an opening belonging to a Revit project document.

