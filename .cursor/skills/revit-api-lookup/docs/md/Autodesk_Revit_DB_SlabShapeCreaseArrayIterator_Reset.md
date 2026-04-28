---
kind: method
id: M:Autodesk.Revit.DB.SlabShapeCreaseArrayIterator.Reset
source: html/b397cded-1987-1a92-0330-9253fbfba435.htm
---
# Autodesk.Revit.DB.SlabShapeCreaseArrayIterator.Reset Method

Bring the iterator back to the start of the array.

## Syntax (C#)
```csharp
public virtual void Reset()
```

## Remarks
The Reset method will return the iterator back to the start of the array in line with the definition of IEnumerator. Note that you must call MoveNext before the first item can be accessed via the Current property.

