---
kind: property
id: P:Autodesk.Revit.DB.Options.DetailLevel
source: html/887c4c25-fe14-2633-b84c-09d2f1279c9e.htm
---
# Autodesk.Revit.DB.Options.DetailLevel Property

The detail level for the geometry extracted with these options.

## Syntax (C#)
```csharp
public ViewDetailLevel DetailLevel { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when setting this property, 
if View is already set. When View is set the detail level of the view is used.

