---
kind: property
id: P:Autodesk.Revit.DB.ImageInstance.EnableSnaps
source: html/73df0a9a-d0d6-33fe-0fd9-ce2c1f77255e.htm
---
# Autodesk.Revit.DB.ImageInstance.EnableSnaps Property

When true the ImageInstance will have its snaps enabled, but only if CanHaveSnaps is true

## Syntax (C#)
```csharp
public bool EnableSnaps { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The image does not have snaps

