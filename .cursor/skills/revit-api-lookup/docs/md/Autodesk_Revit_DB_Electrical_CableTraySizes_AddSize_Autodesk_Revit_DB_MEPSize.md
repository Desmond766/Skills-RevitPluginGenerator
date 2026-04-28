---
kind: method
id: M:Autodesk.Revit.DB.Electrical.CableTraySizes.AddSize(Autodesk.Revit.DB.MEPSize)
source: html/3911b16c-b0e0-7730-0190-53b89974d697.htm
---
# Autodesk.Revit.DB.Electrical.CableTraySizes.AddSize Method

Inserts a new MEPSize into the cable tray sizes.
 For cable tray, the nominal diameter of MEPSize is used .

## Syntax (C#)
```csharp
public void AddSize(
	MEPSize sizeInfo
)
```

## Parameters
- **sizeInfo** (`Autodesk.Revit.DB.MEPSize`) - The new MEPSize to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There is already the same size in the size set.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The function is called during iterating the size set.

