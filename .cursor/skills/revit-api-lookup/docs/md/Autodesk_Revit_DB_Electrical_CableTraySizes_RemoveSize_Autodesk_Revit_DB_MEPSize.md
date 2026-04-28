---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CableTraySizes.RemoveSize(Autodesk.Revit.DB.MEPSize)
source: html/06e0062d-fe6d-84dc-839b-ed50b8054eb4.htm
---
# Autodesk.Revit.DB.Electrical.CableTraySizes.RemoveSize Method

Erases the existing MEPSize.
 For cable tray, the nominal diameter is used in MEPSize.

## Syntax (C#)
```csharp
public void RemoveSize(
	MEPSize sizeInfo
)
```

## Parameters
- **sizeInfo** (`Autodesk.Revit.DB.MEPSize`) - The MEPSize to be removed..

## Remarks
Does nothing if there is no existing MEPSize with the specified nominal diameter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Throws if the function is called during iterating the size set.

