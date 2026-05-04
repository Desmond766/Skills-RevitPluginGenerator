---
kind: method
id: M:Autodesk.Revit.DB.Electrical.TemperatureRatingTypeSetIterator.Reset
source: html/974fd440-63a4-d808-e1cd-b7f743df7375.htm
---
# Autodesk.Revit.DB.Electrical.TemperatureRatingTypeSetIterator.Reset Method

Bring the iterator back to the start of the set.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the set in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

