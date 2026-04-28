---
kind: method
id: M:Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.IsInstanceFlipped(Autodesk.Revit.DB.FamilyInstance)
source: html/64d00f70-6761-bc18-166d-f6ea722ef51e.htm
---
# Autodesk.Revit.DB.AdaptiveComponentInstanceUtils.IsInstanceFlipped Method

Gets the value of the flip parameter on the adaptive instance.

## Syntax (C#)
```csharp
public static bool IsInstanceFlipped(
	FamilyInstance famInst
)
```

## Parameters
- **famInst** (`Autodesk.Revit.DB.FamilyInstance`) - The FamilyInstance

## Returns
True if the instance is flipped.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The FamilyInstance famInst is not an Adaptive Family Instance.
 -or-
 The FamilyInstance famInst does not have an Adaptive Family Symbol.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

