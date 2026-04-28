---
kind: method
id: M:Autodesk.Revit.DB.ReferenceArrayArrayIterator.Reset
source: html/848ba4bf-e54d-6e02-ac9f-c0de1e4b6f89.htm
---
# Autodesk.Revit.DB.ReferenceArrayArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

