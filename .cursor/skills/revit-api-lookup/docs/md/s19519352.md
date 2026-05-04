---
kind: property
id: P:Autodesk.Revit.DB.Element.Name
zh: 构件、图元、元素
source: html/e372092e-ff47-71c2-1272-50ab08e5a41d.htm
---
# Autodesk.Revit.DB.Element.Name Property

**中文**: 构件、图元、元素

A human readable name for the Element.

## Syntax (C#)
```csharp
public virtual string Name { get; set; }
```

## Remarks
The Name property is a human readable name for the element, such as Wall.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the name of the element cannot be changed.
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the element requires a unique name and a non-unique name is set.

