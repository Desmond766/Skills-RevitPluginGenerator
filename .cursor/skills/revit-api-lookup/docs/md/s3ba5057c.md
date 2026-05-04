---
kind: property
id: P:Autodesk.Revit.DB.SpatialElement.Name
source: html/861a3f2f-53a8-7312-b775-e264ed4c46ef.htm
---
# Autodesk.Revit.DB.SpatialElement.Name Property

A human readable name for the Element.

## Syntax (C#)
```csharp
public override string Name { set; }
```

## Remarks
The Name property is a human readable name for the element, such as Wall.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the name of the element cannot be changed.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the element requires a unique name and a non-unique name is set.

