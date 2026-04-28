---
kind: method
id: M:Autodesk.Revit.DB.ElementType.GetSimilarTypes
source: html/2719ca23-11c7-dda4-6291-9a4f0cebfb21.htm
---
# Autodesk.Revit.DB.ElementType.GetSimilarTypes Method

Obtains a set of types that are similar to this type.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetSimilarTypes()
```

## Returns
A set of element IDs of types that are similar to this type.

## Remarks
Two types are similar if elements that have one type could be assigned the other type.

