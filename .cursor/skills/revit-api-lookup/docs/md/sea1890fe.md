---
kind: property
id: P:Autodesk.Revit.DB.ElementId.IntegerValue
source: html/f7074647-9521-0f64-d2e2-eb2401aace85.htm
---
# Autodesk.Revit.DB.ElementId.IntegerValue Property

Provides the value of the element id as a 32-bit integer.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This property is deprecated in Revit 2024 and may be removed in a future version of Revit. Please use the Value property instead.")]
public int IntegerValue { get; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the value of the element id is too large to be represented as a 32-bit integer.

