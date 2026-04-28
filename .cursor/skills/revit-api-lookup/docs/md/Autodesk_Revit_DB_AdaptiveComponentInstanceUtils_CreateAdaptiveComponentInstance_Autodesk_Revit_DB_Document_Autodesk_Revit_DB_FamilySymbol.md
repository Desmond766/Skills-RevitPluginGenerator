---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.CreateAdaptiveComponentInstance(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.FamilySymbol)
source: html/a31f0276-f8e6-4a51-9394-379039e14bb0.htm
---
# Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.CreateAdaptiveComponentInstance Method

Creates a FamilyInstance of Adaptive Component Family.

## Syntax (C#)
```csharp
public static FamilyInstance CreateAdaptiveComponentInstance(
	Document doc,
	FamilySymbol famSymb
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - The Document
- **famSymb** (`Autodesk.Revit.DB.FamilySymbol`) - The FamilySymbol

## Returns
The Family Instance

## Remarks
This method creates an Adaptive FamilyInstance and its PointElement references.
 The references can be accessed by methods like GetInstancePointElementRefIds().
 The PointElement references can be moved, rehosted or manipulated just like any
 other PointElements. The FamilyInstance would then 'adapt' to these references.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element famSymb was not found in the given document.
 -or-
 The Symbol famSymb is not an Adaptive Family Symbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Unable to create adaptive component instance.

