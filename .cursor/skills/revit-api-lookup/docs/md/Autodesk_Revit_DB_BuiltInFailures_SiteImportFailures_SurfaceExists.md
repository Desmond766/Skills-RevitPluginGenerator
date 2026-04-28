---
kind: property
id: P:Autodesk.Revit.DB.BuiltInFailures.SiteImportFailures.SurfaceExists
source: html/3e47440a-9d7f-5ca8-4773-3851d8efa999.htm
---
# Autodesk.Revit.DB.BuiltInFailures.SiteImportFailures.SurfaceExists Property

You are importing data into a surface that already contains points. You may want to go back, create a new surface, and import the data into that instead. You can continue, and Revit will sew the meshes together, but the boundary may be larger than you want.

## Syntax (C#)
```csharp
public static FailureDefinitionId SurfaceExists { get; }
```

