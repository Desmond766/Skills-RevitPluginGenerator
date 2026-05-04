---
kind: property
id: P:Autodesk.Revit.UI.UIApplication.ActiveUIDocument
source: html/3488133d-60c2-aa7c-ab72-0d9360ff122a.htm
---
# Autodesk.Revit.UI.UIApplication.ActiveUIDocument Property

Provides access to an object that represents the currently active project.

## Syntax (C#)
```csharp
public virtual UIDocument ActiveUIDocument { get; }
```

## Remarks
External API commands can access this property in read-only mode only!
The ability to modify the property is reserved for future implementations.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when attempting to modify the property.

