---
kind: method
id: M:Autodesk.Revit.DB.SolidSolidCutUtils.CanElementCutElement(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.CutFailureReason@)
source: html/c5628c5f-d01a-8934-fc8f-fa3e73bea59d.htm
---
# Autodesk.Revit.DB.SolidSolidCutUtils.CanElementCutElement Method

Verifies if the cutting element can add a solid cut to the target element.

## Syntax (C#)
```csharp
public static bool CanElementCutElement(
	Element cuttingElement,
	Element cutElement,
	out CutFailureReason reason
)
```

## Parameters
- **cuttingElement** (`Autodesk.Revit.DB.Element`) - The cutting element.
- **cutElement** (`Autodesk.Revit.DB.Element`) - The element to be cut.
- **reason** (`Autodesk.Revit.DB.CutFailureReason %`) - The reason that the cutting element cannot add a solid cut to the cut element.

## Returns
True if the cutting element can add a solid cut to the target element, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

